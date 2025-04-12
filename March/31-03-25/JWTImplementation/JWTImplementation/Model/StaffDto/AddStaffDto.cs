using System.Diagnostics.CodeAnalysis;

namespace JWTImplementation.Model.StaffDto
{
    public class AddStaffDto
    {

        public string Name { get; set; }

        public string Password { get; set; }

        public int RoleId { get; set; }
    }
}
