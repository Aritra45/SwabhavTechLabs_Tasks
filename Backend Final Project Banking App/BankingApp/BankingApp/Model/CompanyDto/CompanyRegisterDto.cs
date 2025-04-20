using Microsoft.AspNetCore.Http;

namespace BankingApp.Model.CompanyDto
{
    public class CompanyRegisterDto
    {
        public string CompanyEmail { get; set; }
        public string CompanyName { get; set; }
        public string CompanyContactNumber { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyAccountNumber { get; set; }
        public string IFSCNumber { get; set; }
        public string Password { get; set; }
        public IFormFile AadharFile { get; set; }
        public IFormFile PanFile { get; set; }
    }
}
