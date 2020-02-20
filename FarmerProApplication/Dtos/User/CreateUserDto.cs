using FarmerProApplication.Enums;
using System.ComponentModel.DataAnnotations;

namespace FarmerProApplication.Dtos.User
{
    public class CreateUserDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public RoleEnum Role { get; set; }
    }
}
