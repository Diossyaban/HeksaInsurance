using Heksa.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Heksa.Controllers
{
    public class DuaDanTiga : Controller
    {
        private readonly HeksaContext _context;

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult SoalTiga()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SoalTiga(int[] numbers, int target)
        {
            if (numbers != null)
            {
                ViewData["ResultIndices"] = FindPairIndices(numbers, target);
                SetResultDescription();
            }

            return View();
        }

        private int[] FindPairIndices(int[] nums, int target)
        {
            Dictionary<int, int> numIndices = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];

                if (numIndices.ContainsKey(complement))
                {
                    return new int[] { numIndices[complement], i };
                }

                numIndices[nums[i]] = i;
            }

            return new int[] { -1, -1 };
        }

        private void SetResultDescription()
        {
            var resultIndices = (int[])ViewData["ResultIndices"];
            if (resultIndices[0] == -1)
            {
                ViewData["ResultDescription"] = "No pair found.";
            }
            else
            {
                ViewData["ResultDescription"] = $"Indices: {resultIndices[0]}, {resultIndices[1]}";
            }
        }





        [HttpGet]
        public IActionResult PasswordValidation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PasswordValidation(string password)
        {
            bool isValid = ValidatePassword(password);
            ViewData["IsValidPassword"] = isValid;
            ViewData["Password"] = password;
            return View();
        }

        private bool ValidatePassword(string password)
        {
            if (password.Length < 8)
            {
                return false;
            }

            if (!Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$"))
            {
                return false;
            }

            if (Regex.IsMatch(password, @"[!@#$%^&*(),.?\""{}|<>]"))
            {
                return false;
            }

            return true;
        }

    }
}
