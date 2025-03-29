using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactApp.Database;
using ContactApp.Model;

namespace ContactApp.Repository
{
    internal class ContactDetailsRepository
    {
        public int AddContactDetails(int contactId)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Select Contact Detail Type:");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("1. Number");
            Console.WriteLine("2. Email");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            int choice = Convert.ToInt32(Console.ReadLine());
            Console.ResetColor();

            if (!Enum.IsDefined(typeof(ContactDetailsTypeEnum), choice))
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Invalid selection. Only 'Number' or 'Email' are allowed.");
                Console.ResetColor();
                return 0;
            }

            ContactDetailsTypeEnum selectedType = (ContactDetailsTypeEnum)choice;
            Console.Write("You selected: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{selectedType}");
            Console.ResetColor();

            Console.WriteLine("Enter Contact Detail Value (e.g., Phone Number or Email Address):");
            Console.ForegroundColor = ConsoleColor.Red;
            string detailValue = Console.ReadLine();
            Console.ResetColor();

            if (string.IsNullOrWhiteSpace(detailValue))
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Contact Detail Value cannot be empty. Please try again.");
                Console.ResetColor();
                return 0;
            }

            using (var context = new MyContext())
            {
                ContactDetails newContactDetails = new ContactDetails
                {
                    Type = selectedType.ToString(),
                    Value = detailValue,
                    ContactId = contactId
                };

                context.ContactDetails.Add(newContactDetails);
                context.SaveChanges();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Contact detail added successfully.");
                Console.ResetColor();
                return newContactDetails.ContactDetailsID;
            }
        }

        public void RemoveContactDetails(int contactDetailsId)
        {
            using (var context = new MyContext())
            {
                ContactDetails contactDetailsToRemove = context.ContactDetails.FirstOrDefault(cd => cd.ContactDetailsID == contactDetailsId);

                if (contactDetailsToRemove != null)
                {
                    context.ContactDetails.Remove(contactDetailsToRemove);
                    context.SaveChanges();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"ContactDetailsID {contactDetailsId} removed successfully!");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"ContactDetailsID {contactDetailsId} not found.");
                    Console.ResetColor();
                }
            }
        }

        public void UpdateContactDetails(int contactId)
        {
            using (var context = new MyContext())
            {
                var contactDetailsList = context.ContactDetails.Where(cd => cd.ContactId == contactId).ToList();

                if (contactDetailsList.Any())
                {
                    Console.WriteLine("The following contact details are associated with the contact:");
                    foreach (var detail in contactDetailsList)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"ContactDetailsID: {detail.ContactDetailsID}, Type: {detail.Type}, Value: {detail.Value}");
                        Console.ResetColor();
                    }

                    Console.WriteLine("Enter the ContactDetailsID you want to update:");
                    Console.ForegroundColor = ConsoleColor.Red;
                    int contactDetailsID = Convert.ToInt32(Console.ReadLine());
                    Console.ResetColor();

                    ContactDetails contactDetailsToUpdate = contactDetailsList.FirstOrDefault(cd => cd.ContactDetailsID == contactDetailsID);

                    if (contactDetailsToUpdate != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Select Contact Detail Type:");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("1. Number");
                        Console.WriteLine("2. Email");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Red;
                        int choice = Convert.ToInt32(Console.ReadLine());
                        Console.ResetColor();
                        if (Enum.IsDefined(typeof(ContactDetailsTypeEnum), choice))
                        {
                            ContactDetailsTypeEnum type = (ContactDetailsTypeEnum)choice;
                            contactDetailsToUpdate.Type = type.ToString();

                            Console.WriteLine("Enter New Contact Detail Value (leave blank to keep unchanged):");
                            Console.ForegroundColor = ConsoleColor.Red;
                            string newValue = Console.ReadLine();
                            Console.ResetColor();
                            if (!string.IsNullOrWhiteSpace(newValue))
                            {
                                contactDetailsToUpdate.Value = newValue;
                            }

                            context.ContactDetails.Update(contactDetailsToUpdate);
                            context.SaveChanges();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Contact detail updated successfully!");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("Invalid type selection.");
                            Console.ResetColor();
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("The specified ContactDetailsID was not found.");
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("No contact details found for this contact.");
                    Console.ResetColor();
                }
            }
        }
    }
}

