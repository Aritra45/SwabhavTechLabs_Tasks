using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountApp.Model
{
    internal class BankDetails
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string AccountNumber { get; }
        public AccountType AccountType { get; set; }
        public long AadharNumber { get; set; }
        public string PanNumber { get; set; }

        public BankDetails(string firstName, string middleName, string lastName, string accountNumber, AccountType accountType, long aadharNumber, string panNumber)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            AccountNumber = accountNumber;
            AccountType = accountType;
            AadharNumber = aadharNumber;
            PanNumber = panNumber;
        }
    }
}
