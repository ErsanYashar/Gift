using Microsoft.AspNetCore.Identity;
using myPosGift.Core.Services.Interfaces;
using myPosGift.Core.ViewModel.User;
using myPosGift.Infrastructure.Data;
using myPosGift.Infrastructure.Data.DateModels;

namespace myPosGift.Core.Services
{
    public class UsersService : BaseService, IUsersService
    {
        public UsersService(UserManager<User> userManager, ApplicationDbContext context)
            : base(userManager, context)
        {
        }

        public IEnumerable<UsersViewModel> GetAllUsers()
        {

            var usersViewModel = this.Context.Users
                .Select(x => new UsersViewModel
                {                  
                    Username = x.UserName,
                    Email = x.Email,
                    Credits = x.Credits,
                    PhoneNumber= x.PhoneNumber,                  
                })
                .OrderBy(x => x.Username)
                .ToList();

            return usersViewModel;
        }

        public User GetUserById(string userId)
        {
            User user =this.Context.Users
                .FirstOrDefault(x => x.Id == userId);

            return user;
        }

        public User GetUserPhoneNumber(string phoneNumb)
        {
            User user = this.Context.Users
                .FirstOrDefault(x => x.PhoneNumber == phoneNumb);

            return user;

        }
    }
}
