using FarmerProApplication.Dtos.User;

namespace FarmerProApplication.Services.Contracts
{
    public interface IAuthService
    {
        UserDto SignIn(string login, string password);
    }
}
