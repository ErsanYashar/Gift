using myPosGift.Core.ViewModel.User;
using myPosGift.Infrastructure.Data.DateModels;

namespace myPosGift.Core.Services.Interfaces
{
    public interface IUsersService
    {
        User GetUserById(string userId);
        IEnumerable<UsersViewModel> GetAllUsers();

        User GetUserPhoneNumber(string phoneNumb);
    }
}
