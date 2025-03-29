using System.Diagnostics.CodeAnalysis;

namespace ContactAppUsingWebApi.Model.UserDto
{
    public class UpdateUserNameDto
    {
        [NotNull]
        public string Name { get; set; }
    }
}
