using HoldFlow.BL.Interfaces;
using HoldFlow.Models.DTOs;


namespace HoldFlow.Controllers
{
    public class UserController : Controller
    {
        private readonly IAccountManager _accountManager;

        public UserController(IAccountManager accountManager)
        {
            _accountManager = accountManager;
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterUser(RegisterDto registerDto)
        {
            var result = await _accountManager.RegisterUser(registerDto);

            if (result.Success)
                return RedirectToAction(nameof(Login));
            else
            {
                ModelState.AddModelError("", result.ErrorMessage);
                return View(registerDto);
            }
        }
        [HttpPost("LoginProcess")]
        public async Task<IActionResult> LoginProcess(LoginDto loginDto)
        {
            var loginResult = await _accountManager.LoginUser(loginDto);
            if (loginResult.Success)
                return RedirectToAction("Index","Home");
            else
                return Unauthorized(loginResult.ErrorMessage);
        }

        [HttpPost("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            var result = await _accountManager.ConfirmEmail(token, email);

            if (result.Success)
            {
                return RedirectToAction("EmailConfirmationSuccess");
            }
            else
            {
                // Handle email confirmation failure
                ModelState.AddModelError("", result.ErrorMessage);
                return View();
            }
        }

        public IActionResult EmailConfirmationSuccess()
        {
            return View();
        }
    }
}
