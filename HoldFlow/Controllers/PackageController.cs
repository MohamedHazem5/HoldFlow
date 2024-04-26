using Microsoft.AspNetCore.Mvc;

namespace HoldFlow.Controllers
{
    public class PackageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
