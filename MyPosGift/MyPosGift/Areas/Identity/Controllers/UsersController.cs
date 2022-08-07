using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using myPosGift.Core.Services.Constants;
using myPosGift.Core.ViewModel.User;
using myPosGift.Infrastructure.Data;
using myPosGift.Infrastructure.Data.DateModels;

namespace MyPosGift.Areas.Identity.Controllers
{
    [Area("Identity")]
    public class UsersController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ApplicationDbContext dbContex;

        public UsersController(UserManager<User> userManager, ApplicationDbContext dbContex, RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.dbContex = dbContex;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return this.View();
        }

        //public async Task<IActionResult> AddRole()
        //{
        //    if (!await this.roleManager.RoleExistsAsync("User"))
        //    {
        //        await this.roleManager.CreateAsync(new IdentityRole
        //        {
        //            Name = "User"
        //        });
        //    }

        //    return Ok();
        //}

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {

            var user = new User
            {   

                UserName = model.Username,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
            };


            var result = await this.userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                if (this.userManager.Users.Count() == 1)
                {
                    await this.userManager.AddToRoleAsync(user, "Admin");
                }
                else
                {
                    await this.userManager.AddToRoleAsync(user, "User");
                }

                await this.signInManager.SignInAsync(user, false);
            }
            else
            {
                this.ViewData["Error"] = ConstCore.UsernameEror;
                return this.View(model);
            }

            return this.RedirectToAction("Index", "Home", new { area = "" });
        }

    }
}
