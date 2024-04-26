using Microsoft.AspNetCore.Mvc;

namespace HoldFlow.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
