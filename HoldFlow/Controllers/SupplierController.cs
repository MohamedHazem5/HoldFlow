using Microsoft.AspNetCore.Mvc;

namespace HoldFlow.Controllers
{
    public class SupplierController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
