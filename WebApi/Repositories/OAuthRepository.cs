using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Repositories
{
    public class OAuthRepository : IOAuth
    {
        private readonly ApplicationContext context;
        public OAuthRepository(ApplicationContext Context)
        {
            context = Context;
        }
        public async Task<User> GetUser(string email, string password)
        {
            User user = await context.Employees.Where(c => c.Email == email).FirstOrDefaultAsync();
            if (user == null)
            {
                user = await context.EP_Representatives.Where(c => c.Email == email).FirstOrDefaultAsync();
            }

            if (user == null)
            {
                user = await context.Students.Where(c => c.Email == email).FirstOrDefaultAsync();
            }

            if (user == null)
            {
                user = await context.UNI_Representatives.Where(c => c.Email == email).FirstOrDefaultAsync();
            }

            return user;
        }
        public ClaimsIdentity GetIdentity(string email, string password)
        {
            var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, email),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, password)
                };

            ClaimsIdentity claimsIdentity =
            new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            return claimsIdentity;
        }
        public dynamic CreateAccessToken(ClaimsIdentity claimsIdentity)
        {
            var identity = claimsIdentity;

            if (identity == null)
            {
                return null;
            }

            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
//При использовании валидации токена по умолчанию время испарения токена - 5 минут.
//Поэтому действительное время испарения токена = 5 минут + указанное пользователем время
                    expires: now.Add(TimeSpan.FromSeconds(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };

            return response;
        }
        public dynamic CreateRefreshToken(ClaimsIdentity claimsIdentity)
        {
            var identity = claimsIdentity;

            if (identity == null)
            {
                return null;
            }

            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };

            return response;
        }
    }
}
