using Microsoft.AspNetCore.Mvc;

namespace HoldFlow.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
