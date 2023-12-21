/*using Heksa.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Heksa.Models.Account
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> RegisterAsync(RegisterViewModel model)
        {
            // Validasi panjang password minimal 8 karakter
            if (model.Password.Length < 8)
            {
                return false;
            }

            // Validasi mengandung setidaknya satu huruf kapital, satu huruf kecil, dan satu angka
            if (!model.Password.Any(char.IsUpper) || !model.Password.Any(char.IsLower) || !model.Password.Any(char.IsDigit))
            {
                return false;
            }

            // Validasi tidak mengandung karakter khusus
            if (model.Password.Any(char.IsPunctuation) || model.Password.Any(char.IsSymbol))
            {
                return false;
            }

            var user = new IdentityUser { UserName = model.Username };

            var result = await _userManager.CreateAsync(user, model.Password);

            return result.Succeeded;
        }

        public async Task<bool> LoginAsync(LoginViewModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, lockoutOnFailure: false);

            return result.Succeeded;
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityUser> GetUserAsync(string username)
        {
            return await _userManager.FindByNameAsync(username);
        }

        public async Task<bool> CreateDefaultUserAsync()
        {
            var defaultUsername = "diossyaban";
            var defaultPassword = "Diossyaban17";

            var existingUser = await _userManager.FindByNameAsync(defaultUsername);
            if (existingUser == null)
            {
                var newUser = new IdentityUser { UserName = defaultUsername };

                var result = await _userManager.CreateAsync(newUser, defaultPassword);

                return result.Succeeded;
            }

            return false;
        }
    }
}
*/