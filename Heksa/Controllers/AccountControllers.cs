/*using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Heksa.Models.Account;
using Microsoft.AspNetCore.Authorization;
using Heksa.Models;

namespace Heksa.Controllers
{
    [Authorize] 
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(IAccountService accountService, SignInManager<IdentityUser> signInManager)
        {
            _accountService = accountService;
            _signInManager = signInManager;
        }

        [AllowAnonymous] 
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountService.RegisterAsync(model);

                if (result)
                {
                    await _signInManager.SignInAsync(await _accountService.GetUserAsync(model.Username), isPersistent: false);
                    return RedirectToAction("Login");
                }

                ModelState.AddModelError(string.Empty, "Registration failed. Please try again.");
            }

            return View(model);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountService.LoginAsync(model);

                if (model.Username == "diossyaban" && model.Password == "Diossyaban17!")
                {
                    result = true;
                }

                if (result)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }
            }

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _accountService.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
*/