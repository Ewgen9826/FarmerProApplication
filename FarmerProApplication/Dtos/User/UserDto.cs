using FarmerProApplication.Enums;

namespace FarmerProApplication.Dtos.User
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public RoleEnum Role { get; set; }
    }
}
