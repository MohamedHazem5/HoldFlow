using Microsoft.AspNetCore.Mvc;

namespace HoldFlow.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
