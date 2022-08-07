using Microsoft.AspNetCore.Identity;
using myPosGift.Core.Services.Interfaces;
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

        public User GetUserById(string userId)
        {
            User user = Context.Users
                .FirstOrDefault(x => x.Id == userId);

            return user;
        }
    }
}
