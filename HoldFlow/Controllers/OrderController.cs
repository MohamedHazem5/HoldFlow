using Microsoft.AspNetCore.Mvc;

namespace HoldFlow.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
