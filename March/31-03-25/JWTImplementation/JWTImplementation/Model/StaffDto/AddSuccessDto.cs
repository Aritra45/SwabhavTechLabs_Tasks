using System.Diagnostics.CodeAnalysis;

namespace JWTImplementation.Model.StaffDto
{
    public class AddSuccessDto
    {
        public string Name { get; set; }

        public bool IsActive { get; set; }

        public int RoleId { get; set; }
    }
}
