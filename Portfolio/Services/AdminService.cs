using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Portfolio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Portfolio.Services
{
    public class AdminService
    {
        private readonly UserManager<IdentityUser> userManager;

        public AdminService(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        //public async Task<bool> loginAdminAsync(AdminViewModel admin)
        //{
        //    var entryAdmin = new IdentityUser()
        //    {
        //        UserName = admin.UserName,
        //        PasswordHash = admin.Password
        //    };

        //    var user = await userManager.FindByEmailAsync(entryAdmin.Email);

        //    if (user != null &&
        //        userManager.CheckPasswordAsync(user, admin.Password))
        //    {
        //        var identity = new ClaimsIdentity(IdentityConstants.ApplicationScheme);
        //        identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.AdminId));
        //        identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));

        //        await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme,
        //            new ClaimsPrincipal(identity));
        //    }
        //}
    }
}
