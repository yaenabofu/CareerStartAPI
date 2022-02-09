using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface IAuth<T>
    {
        Task<T> Login(Login loginModel);
        Task<T> Register(Register registerModel);
    }
}
