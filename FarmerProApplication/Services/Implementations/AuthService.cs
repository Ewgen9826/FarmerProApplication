using FarmerProApplication.Cryptography;
using FarmerProApplication.Dtos.User;
using FarmerProApplication.Model;
using FarmerProApplication.Services.Contracts;
using System.Linq;

namespace FarmerProApplication.Services.Implementations
{
    class AuthService : IAuthService
    {
        private readonly ApplicationDatabaseContext _context;
        public AuthService(ApplicationDatabaseContext context)
        {
            _context = context;
        }
        public UserDto SignIn(string login, string password)
        {
            var user = _context.Users.FirstOrDefault(user => user.Login.Trim().ToLower() == login.Trim().ToLower());
            if(user == null || !PasswordHasher.VerifyPassword(user.PasswordHash,password))
            {
                return null;
            }
            return new UserDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Login = user.Login,
                Role = user.Role
            };
        }
    }
}
