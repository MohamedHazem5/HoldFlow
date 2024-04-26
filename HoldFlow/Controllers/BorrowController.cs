using Microsoft.AspNetCore.Mvc;

namespace HoldFlow.Controllers
{
    public class BorrowController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
