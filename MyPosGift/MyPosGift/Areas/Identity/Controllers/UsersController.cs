using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using myPosGift.Core.Services.Constants;
using myPosGift.Core.Services.Interfaces;
using myPosGift.Core.ViewModel.User;
using myPosGift.Infrastructure.Data;
using myPosGift.Infrastructure.Data.DateModels;
using X.PagedList;

namespace MyPosGift.Areas.Identity.Controllers
{
    [Area("Identity")]
    public class UsersController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ApplicationDbContext dbContex;
        private readonly IUsersService usersService;

        public UsersController(UserManager<User> userManager, ApplicationDbContext dbContex, RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager, IUsersService usersService)
        {
            this.userManager = userManager;
            this.dbContex = dbContex;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
            this.usersService = usersService;
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

            var userEx = usersService.GetUserById(user.Id);

            if (userEx == null  )
            {
                user.Credits = 100;
            }

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

        public IActionResult SignIn()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var signIn = await this.signInManager.PasswordSignInAsync(model.Username, model.Password, true, true);

            if (!signIn.Succeeded)
            {
                this.ViewData["Error"] = ConstCore.UserOrPasInv;
                return this.View(model);
            }

            return this.RedirectToAction("Index", "Home", new { area = "" });
        }

        [Authorize]
        public async Task<IActionResult> SignOut()
        {
            await this.signInManager.SignOutAsync();
            return this.RedirectToAction("Index", "Home", new { area = "" });
        }

        [Authorize(Roles = "Admin")]
        public IActionResult All(int? page)
        {
            var users = this.usersService.GetAllUsers();

            var pageNumber = page ?? 1;
            var usersPage = users.ToPagedList(pageNumber, 15);

            this.ViewData["Users"] = usersPage;

            return this.View();
        }
    }
}
