using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        readonly ApplicationContext applicationContext;
        readonly ITokenService tokenService;
        public TokenController(ApplicationContext ApplicationContext, ITokenService tokenService)
        {
            this.applicationContext = ApplicationContext ?? throw new ArgumentNullException(nameof(ApplicationContext));
            this.tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
        }
        [HttpPost]
        [Route("Refresh")]
        public async Task<IActionResult> Refresh(TokenApiModel tokenApiModel)
        {
            if (tokenApiModel is null)
            {
                return BadRequest("Invalid client request");
            }
            string accessToken = tokenApiModel.AccessToken;
            string refreshToken = tokenApiModel.RefreshToken;
            var principal = tokenService.GetPrincipalFromExpiredToken(accessToken);
            var email = principal.Identity.Name; //this is mapped to the Name claim by default
            var user = await applicationContext.Users.SingleOrDefaultAsync(u => u.Email == email);
            if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
            {
                return BadRequest("Invalid client request");
            }
            var newAccessToken = tokenService.GenerateAccessToken(principal.Claims);
            var newRefreshToken = tokenService.GenerateRefreshToken();
            user.RefreshToken = newRefreshToken;
            await applicationContext.SaveChangesAsync();
            return new ObjectResult(new
            {
                accessToken = newAccessToken,
                refreshToken = newRefreshToken
            });
        }
        [HttpPost, Authorize]
        [Route("Revoke")]
        public async Task<IActionResult> Revoke()
        {
            var email = User.Identity.Name;
            var user = await applicationContext.Users.SingleOrDefaultAsync(u => u.Email == email);
            if (user == null) return BadRequest();
            user.RefreshToken = null;
            await applicationContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
