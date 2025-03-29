using System.Diagnostics.CodeAnalysis;

namespace ContactAppUsingWebApi.Model.UserDto
{
    public class GetAllUserDto
    {

        public string Name { get; }

        public bool IsAdmin { get; }

        public bool IsActive { get; }
    }
}
