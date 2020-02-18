using FarmerProApplication.Dtos.User;
using System.Collections.Generic;

namespace FarmerProApplication.Services.Contracts
{
    public interface IUsersService
    {
        List<UserDto> GetAll();
        UserDto Get(int userId);
        void Add(CreateUserDto createUser);
        void Update(int userId, CreateUserDto updateUser);
        void Remove(int userId);
    }
}
