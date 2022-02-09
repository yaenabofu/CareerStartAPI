using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebApi.Interfaces;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly IAuth<object> userAuth;
        public AuthController(IAuth<object> UserAuth)
        {
            this.userAuth = UserAuth ?? throw new ArgumentNullException(nameof(UserAuth));
        }
        [HttpPost, Route("Register")]
        public async Task<IActionResult> Register([FromBody] Register registerModel)
        {
            User user = await userAuth.Register(registerModel) as User;

            if (user == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(new
                {
                    user
                });
            }
        }

        [HttpPost, Route("Login")]
        public async Task<IActionResult> Login([FromBody] Login loginModel)
        {
            UserExtraInfo user = await userAuth.Login(loginModel) as UserExtraInfo;

            if (user == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(new
                {
                    Token = user.AccessToken,
                    RefreshToken = user.RefreshToken
                });
            }
        }
    }
}
