using System.Diagnostics.CodeAnalysis;

namespace BankingApp.Model.UserDtos
{
    public class AddUserDto
    {
        public string UserEmail { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
    }
}
