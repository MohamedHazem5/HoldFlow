using Microsoft.AspNetCore.Mvc;

namespace HoldFlow.Controllers
{
    public class InventoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
