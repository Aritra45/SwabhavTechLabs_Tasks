using System.Diagnostics.CodeAnalysis;

namespace JWTImplementation.Model.StaffDto
{
    public class GetAllStaffsDto
    {

        public string Name { get; set; }

        public bool IsActive { get; set; }

        public int RoleId { get; set; }
    }
}
