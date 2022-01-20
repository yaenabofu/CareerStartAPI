using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Repositories;
using WebApi.Repository;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OAuthController : Controller
    {
        private readonly IOAuth oauthRepo;
        public OAuthController(IOAuth OAuthRepo)
        {
            this.oauthRepo = OAuthRepo;
        }

        [HttpPost("/Login")]
        public async Task<IActionResult> Login([FromQuery] string email, [FromQuery] string password)
        {
            User user = await oauthRepo.GetUser(email, password);

            if (user == null)
            {
                return BadRequest(new { errorText = "Invalid username or password." });
            }

            return Json(oauthRepo.CreateAccessToken(oauthRepo.GetIdentity(email, password)));
        }
    }
}
