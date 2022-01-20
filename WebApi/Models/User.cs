using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public Guid Username { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
