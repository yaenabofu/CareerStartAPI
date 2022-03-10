using System;

namespace WebApi.Models
{
    public class Login
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
