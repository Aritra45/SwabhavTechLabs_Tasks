using BankingApp.Model.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

public class Beneficiary
{
    [Key]
    public string BeneficiaryCompanyEmail { get; set; }
    [NotNull]
    public string BeneficiaryCompanyName { get; set; }

    [NotNull]
    public string BankAccountNumber { get; set; }

    [NotNull]
    public string IFSCNumber { get; set; }

    [NotNull]
    public string BeneficiaryType { get; set; }
    [NotNull]
    public bool IsApproved { get; set; }

    [NotNull]
    public string CompanyEmail { get; set; }

}
