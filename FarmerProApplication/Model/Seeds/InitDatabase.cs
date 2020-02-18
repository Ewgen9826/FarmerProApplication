using FarmerProApplication.Cryptography;
using FarmerProApplication.Enums;
using FarmerProApplication.Models.DatabaseModels;
using System.Linq;

namespace FarmerProApplication.Model.Seeds
{
    public class InitDataBase
    {
        public static void Seed(ApplicationDatabaseContext context)
        {
            if (context.Users.Count() != 0) return;
            var user = new User();
            user.FirstName = "Super";
            user.LastName = "Admin";
            user.Login = "admin";
            user.Role = RoleEnum.ADMIN;
            user.PasswordHash = PasswordHasher.HashPassword("admin");
            context.Users.Add(user);
            context.SaveChanges();
        }
    }
}
