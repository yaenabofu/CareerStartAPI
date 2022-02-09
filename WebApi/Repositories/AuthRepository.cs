using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebApi.Interfaces;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Repositories
{
    public class AuthRepository : IAuth<object>
    {
        private readonly ApplicationContext context;
        private readonly ITokenService tokenService;
        private readonly IRepository<User> userContext;
        public AuthRepository(ApplicationContext Context, ITokenService TokenService, IRepository<User> UserContext)
        {
            userContext = UserContext;
            context = Context;
            tokenService = TokenService;
        }
        public string HashPassword(string password)
        {
            const string SALT = "CGYzqeN4plZekNC88Umm1Q==";

            string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
               password: password,
               salt: Encoding.UTF8.GetBytes(SALT),
               prf: KeyDerivationPrf.HMACSHA256,
               iterationCount: 100000,
               numBytesRequested: 256 / 8));

            return hashedPassword;
        }
        public async Task<object> Login(Login loginModel)
        {
            if (loginModel == null)
            {
                return null;
            }

            var user = await context.Users.SingleOrDefaultAsync(u => (u.Email == loginModel.Email) &&
                                        (u.Password == HashPassword(loginModel.Password)));
            if (user == null)
            {
                return null;
            }

            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, loginModel.Email),
            new Claim(ClaimTypes.Role, "Manager")
        };
            var accessToken = tokenService.GenerateAccessToken(claims);
            var refreshToken = tokenService.GenerateRefreshToken();
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);

            await userContext.Update(user);

            UserExtraInfo userOnReturn = new UserExtraInfo()
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                Email = user.Email,
                FirstName = user.FirstName,
                SecondName = user.SecondName,
                ThirdName = user.ThirdName,
                Password = user.Password,
                RefreshTokenExpiryTime = user.RefreshTokenExpiryTime,
            };

            return userOnReturn;
        }

        public async Task<object> Register(Register registerModel)
        {
            if (registerModel == null)
            {
                return null;
            }

            var user = await context.Users.SingleOrDefaultAsync(u => (u.Email == registerModel.Email));

            if (user != null)
            {
                return null;
            }

            //func Send_Email_With_Code()
            //func Get_Code_From_Client()
            //func Hash_Password()
            //func Save_In_Db()

            //Role role = await userContext.Roles.SingleOrDefaultAsync(r => r.Id == registerModel.RoleId);

            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, registerModel.Email),
            new Claim(ClaimTypes.Role, "Manager")
        };

            var accessToken = tokenService.GenerateAccessToken(claims);
            var refreshToken = tokenService.GenerateRefreshToken();

            User userToAdd = new User()
            {
                Email = registerModel.Email,
                FirstName = registerModel.Firstname,
                Password = HashPassword(registerModel.Password),
                SecondName = registerModel.Secondname,
                ThirdName = registerModel.Thirdname,
                RoleId = registerModel.RoleId,
                RefreshToken = refreshToken,
                RefreshTokenExpiryTime = DateTime.Now.AddDays(7)
            };

            await userContext.Create(userToAdd);

            return userToAdd;
        }
    }
}
