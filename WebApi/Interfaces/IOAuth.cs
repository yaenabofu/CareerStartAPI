using System.Security.Claims;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Repositories
{
    public interface IOAuth
    {
        Task<User> GetUser(string email, string password);
        ClaimsIdentity GetIdentity(string email, string password);
        dynamic CreateAccessToken(ClaimsIdentity claimsIdentity);
        dynamic CreateRefreshToken(ClaimsIdentity claimsIdentity);
    }
}
