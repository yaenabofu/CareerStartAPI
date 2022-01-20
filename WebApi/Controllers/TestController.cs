using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class TestController : Controller
    {
        [Authorize]
        [Route("/authIndex")]
        [HttpGet]
        public string Index()
        {
            return "Вы авторизованы";
        }
    }
}
