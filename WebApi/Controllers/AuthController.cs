using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly ApplicationContext userContext;
        readonly ITokenService tokenService;
        public AuthController(ApplicationContext userContext, ITokenService tokenService)
        {
            this.userContext = userContext ?? throw new ArgumentNullException(nameof(userContext));
            this.tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
        }
        [HttpPost, Route("Login")]
        public async Task<IActionResult> Login([FromBody] Login loginModel)
        {
            if (loginModel == null)
            {
                return BadRequest("Invalid client request");
            }
            var user = await userContext.Users.SingleOrDefaultAsync(u => (u.Email == loginModel.Email) &&
                                        (u.Password == loginModel.Password));
            if (user == null)
            {
                return Unauthorized();
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
            await userContext.SaveChangesAsync();
            return Ok(new
            {
                Token = accessToken,
                RefreshToken = refreshToken
            });
        }
    }
}
