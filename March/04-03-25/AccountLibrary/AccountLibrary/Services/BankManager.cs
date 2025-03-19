using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AccountLibrary.Model;
using System.Security;
using AccountLibrary.Exceptions;
namespace AccountLibrary.Services
{
    public class BankManager
    {
        public List<BankDetails> bank;
        DataSerializer serializer;
        public BankManager() 
        {
            bank = new List<BankDetails>();
            serializer = new DataSerializer();
            bank = serializer.DeSerializer();
        }

        public void AddBankAccount()
        {
            string[] range = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            Console.Write("Select Bank Account Type Number According The List: \n");
            int number = 1;
            foreach (var typeOfAccount in Enum.GetValues(typeof(AccountType)).Cast<AccountType>())
            {
                Console.WriteLine($"{number} {typeOfAccount}");
                number++;
            }
            int typeAccount = Convert.ToInt32(Console.ReadLine());
            var accountType = (AccountType)typeAccount;
            Console.WriteLine($"You Select {accountType}");

            bool isInvalidStringForFirstName = true;
            string firstName = "";
            while (isInvalidStringForFirstName)
            {
                Console.Write("Enter Your First Name: ");
                firstName = Console.ReadLine().ToUpper();
                foreach(char c in firstName)
                {
                    for (int i = 0; i < range.Length; i++)
                    {
                        if (range[i] == c.ToString())
                        {
                            isInvalidStringForFirstName = false;
                            break;
                        }
                        else
                        {
                            isInvalidStringForFirstName = true;
                        }
                    }
                    if (isInvalidStringForFirstName)
                    {
                        Console.WriteLine("!!!Invalid First Name!!!");
                        break;
                    }
                }
            }

            bool isInvalidStringForMiddleName = true;
            string middleName = "";
            while (isInvalidStringForMiddleName)
            {
                Console.Write("Enter Your Middle Name: ");
                middleName = Console.ReadLine().ToUpper();
                if (middleName == "")
                {
                    isInvalidStringForFirstName = false;
                    break;
                }
                else
                {
                    foreach (char c in middleName)
                    {
                        for (int i = 0; i < range.Length; i++)
                        {
                            if (range[i] == c.ToString())
                            {
                                isInvalidStringForMiddleName = false;
                                break;
                            }
                            else
                            {
                                isInvalidStringForMiddleName = true;
                            }
                        }
                        if (isInvalidStringForMiddleName)
                        {
                            Console.WriteLine("!!!Invalid Middle Name!!!");
                            break;
                        }
                    }
                }
            }

            bool isInvalidStringForLastName = true;
            string lastName = "";
            while (isInvalidStringForLastName)
            {
                Console.Write("Enter Your Last Name: ");
                lastName = Console.ReadLine().ToUpper();
                foreach (char c in lastName)
                {
                    for (int i = 0; i < range.Length; i++)
                    {
                        if (range[i] == c.ToString())
                        {
                            isInvalidStringForLastName = false;
                            break;
                        }
                        else
                        {
                            isInvalidStringForLastName = true;
                        }
                    }
                    if (isInvalidStringForLastName)
                    {
                        Console.WriteLine("!!!Invalid Last Name!!!");
                        break;
                    }
                }
            }

            bool isValidAadhar = false;
            string[] rangeForAadhar = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            string aadhar = "";
            long aadharNumber = 0;
            while (!isValidAadhar)
            {
                try
                {
                    bool isinvalidInput = true;
                    while (isinvalidInput)
                    {
                        Console.Write("Enter Aadhar Number: ");
                        aadhar = Console.ReadLine();
                        foreach (char c in aadhar)
                        {
                            for (int i = 0; i < rangeForAadhar.Length; i++)
                            {
                                if (rangeForAadhar[i] == c.ToString())
                                {
                                    isinvalidInput = false;
                                    break;
                                }
                                else
                                {
                                    isinvalidInput = true;
                                }
                            }
                            if (isinvalidInput)
                            {
                                Console.WriteLine("Invalid Aadhar Number");
                                break;
                            }
                        }
                    }
                    if (aadhar.Length == 12)
                    {
                        isValidAadhar = true;
                        aadharNumber = Convert.ToInt64(aadhar);
                    }
                    else
                    {
                        throw new InvalidAadharException("Invalid Aadhar Number"); 
                    }
                }
                catch (Exception ex) {
                    isValidAadhar = false;
                    Console.WriteLine(ex.Message);
                    
                }
            }

            bool isValidPan = false;
            string panNumber = "";
            while (!isValidPan)
            {
                try
                {
                    Console.Write("Enter PanCard Number: ");
                    panNumber = Console.ReadLine().ToUpper();

                    string firstPartOfPan = panNumber.Substring(0, 5);
                    foreach (char c in firstPartOfPan)
                    {
                        for (int i = 0; i < range.Length; i++)
                        {
                            if (range[i] == c.ToString())
                            {
                                isValidPan = true;
                                break;
                            }
                            else
                            {
                                isValidPan = false;
                            }
                        }
                        if (!isValidPan)
                        {
                            throw new InvalidPanException("!!!Invalid Pan Number!!!");
                        }
                    }

                    isValidPan = false;
                    string secondPartOfPan = panNumber.Substring(5, 4);
                    foreach (char c in secondPartOfPan)
                    {
                        for (int i = 0; i < rangeForAadhar.Length; i++)
                        {
                            if (rangeForAadhar[i] == c.ToString())
                            {
                                isValidPan = true;
                                break;
                            }
                            else
                            {
                                isValidPan = false;
                            }
                        }
                        if (!isValidPan)
                        {
                            throw new InvalidPanException("Invalid Pan Number");
                        }
                    }

                    isValidPan = false;
                    string lastPartOfPan = panNumber.Substring(9, 1);
                    foreach (char c in lastPartOfPan)
                    {
                        for (int i = 0; i < range.Length; i++)
                        {
                            if (range[i] == c.ToString())
                            {
                                isValidPan = true;
                                break;
                            }
                            else
                            {
                                isValidPan = false;
                            }
                        }
                        if (!isValidPan)
                        {
                            throw new InvalidPanException("!!!Invalid Pan Number!!!");
                        }
                    }

                    isValidPan = false;
                    if (panNumber.Length == 10)
                    {
                        isValidPan = true;
                    }

                    else
                    {
                        throw new InvalidPanException("Invalid Pan Number");
                    }

                }
                catch (Exception ex)
                {
                    isValidPan = false;
                    Console.WriteLine(ex.Message);
                }
            }

            bool isAccountNumberExist = true;
            string accountNumber = "";
            System.Random r = new System.Random();
            while (isAccountNumberExist)
            {
                accountNumber = r.Next(100000, 999999).ToString() + r.Next(100000, 999999).ToString();
                if (bank.Count == 0)
                {
                    isAccountNumberExist = false;
                }
                else
                {
                    foreach (BankDetails account in bank)
                    {
                        isAccountNumberExist = false;
                        if (account != null && account.AccountNumber == accountNumber)
                        {
                            isAccountNumberExist = true;
                            break;
                        }
                    }
                }
            }

            BankDetails newDetails = new BankDetails(firstName, middleName, lastName, accountNumber, accountType, aadharNumber, panNumber);
            bank.Add(newDetails);
            serializer.Serializer(bank);
            Console.WriteLine("Account Added Successfully");
        }
        public void DisplayAllAccount()
        {
            try
            {
                if (bank.Count == 0)
                {
                    throw new ListEmptyException("No Bank Accounts to display.");
                }

                foreach (BankDetails account in bank)
                {
                    if (account == null)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Account Type: {account.AccountType}");
                        Console.WriteLine($"User Name: {account.FirstName} {account.MiddleName} {account.LastName}");
                        Console.WriteLine($"Account Number: {account.AccountNumber}");
                        Console.WriteLine($"Aadhar Number: {account.AadharNumber}");
                        Console.WriteLine($"Pan Number: {account.PanNumber}");
                        Console.WriteLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void RemoveAccountByAccountNumber()
        {
            try
            {
                Console.Write("Enter Bank Account Number to remove: ");
                string id = Console.ReadLine();
                for (int i = 0; i < bank.Count; i++)
                {
                    if (bank[i].AccountNumber == id)
                    {
                        bank.RemoveAt(i);
                        Console.WriteLine($"Bank Account {id} removed successfully.");
                        serializer.Serializer(bank);
                        return;
                    }
                }
                throw new BankAccountNotFoundException($"Bank Account {id} not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine (ex.Message);
            }
        }
        public void FindAccountByAccountNumber()
        {
            try
            {
                Console.Write("Enter Bank Account Number: ");
                string id = Console.ReadLine();
                bool isValidMovieId = false;

                foreach (BankDetails account in bank)
                {
                    if (account != null && account.AccountNumber == id)
                    {
                        isValidMovieId = true;
                        Console.WriteLine($"Account Type: {account.AccountType}");
                        Console.WriteLine($"User Name: {account.FirstName} {account.MiddleName} {account.LastName}");
                        Console.WriteLine($"Account Number: {account.AccountNumber}");
                        Console.WriteLine($"Aadhar Number: {account.AadharNumber}");
                        Console.WriteLine($"Pan Number: {account.PanNumber}");
                        break;
                    }
                }

                if (!isValidMovieId)
                {
                    throw new BankAccountNotFoundException($"Bank Account {id} not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine (ex.Message);
            }
        }
        public void ClearAllAccount()
        {
            try
            {
                if (bank.Count == 0)
                {
                    throw new ListEmptyException("Storage is already cleared.");
                }
                else
                {
                    bank.Clear();
                    serializer.Serializer(bank);
                    Console.WriteLine("All Bank Accounts cleared.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine (ex.Message);
            }
        }
    }
}
