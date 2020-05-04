using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Portfolio.ViewModels;

namespace Portfolio.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;

        public AdminController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AdminViewModel adminModel)
        {
            if (!ModelState.IsValid)
            {
                return View(adminModel);
            }

            // Find user
            var user = await userManager.FindByNameAsync(adminModel.UserName);
            // If not null and hashed password macthes
            if (user != null &&
                await userManager.CheckPasswordAsync(user, adminModel.Password))
            {
                // Create claim and login
                var identity = new ClaimsIdentity(IdentityConstants.ApplicationScheme);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id));
                identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));

                await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme,
                    new ClaimsPrincipal(identity));

                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            else
            {
                ModelState.AddModelError("", "Invalid UserName or Password");
                return View();
            }
        }
    }
}