using System.Diagnostics.CodeAnalysis;

namespace ContactAppUsingWebApi.Model.UserDto
{
    public class LoginSuccessDto
    {
        public string Name { get; set; }
        
        public bool IsAdmin { get; set; }
        
        public bool IsActive { get; set; }
    }
}
