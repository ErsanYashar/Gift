using myPosGift.Infrastructure.Data.DateModels;

namespace myPosGift.Core.Services.Interfaces
{
    public interface IUsersService
    {
        User GetUserById(string userId);
    }
}
