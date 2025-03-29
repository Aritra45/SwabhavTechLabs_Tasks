using System.Diagnostics.CodeAnalysis;

namespace ContactAppUsingWebApi.Model.UserDto
{
    public class UpdateUserActivationDto
    {
        [NotNull]
        public bool IsActive { get; set; }
    }
}
