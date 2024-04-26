using Microsoft.AspNetCore.Mvc;

namespace HoldFlow.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
