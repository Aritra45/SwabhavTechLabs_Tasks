using System;
using System.Collections.Generic;
using System.Linq;
using ContactApp.Database;
using ContactApp.Model;
using Microsoft.EntityFrameworkCore;

namespace ContactApp.Repository
{
    internal class ContactRepository
    {
        private ContactDetailsRepository contactDetailsRepository = new ContactDetailsRepository();

        public void AddContact(int userId)
        {
            Console.WriteLine("Enter Contact First Name: ");
            Console.ForegroundColor = ConsoleColor.Red;
            string firstName = Console.ReadLine();
            Console.ResetColor();
            Console.WriteLine("Enter Contact Last Name: ");
            Console.ForegroundColor = ConsoleColor.Red;
            string lastName = Console.ReadLine();
            Console.ResetColor();

            using (var context = new MyContext())
            {
                User user = context.User.FirstOrDefault(u => u.UserId == userId);
                Contact newContact = new Contact
                {
                    FirstName = firstName,
                    LastName = lastName,
                    UserId = userId
                };

                context.Contact.Add(newContact);
                context.SaveChanges();

                int contactId = newContact.ContactId;
                int contactDetailsId = contactDetailsRepository.AddContactDetails(contactId);
                if (contactDetailsId == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Failed to add contact details");
                    Console.ResetColor();
                    return;
                }


                var contactDetails = context.ContactDetails.FirstOrDefault(cd => cd.ContactDetailsID == contactDetailsId);

                if (contactDetails == null)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Failed to retrieve the contact details");
                    Console.ResetColor();
                    return;
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Contact '{firstName} {lastName}' added successfully with ContactDetailsID: {contactDetailsId}.");
                Console.ResetColor();
            }
        }

        public void RemoveContact()
        {
            Console.WriteLine("Enter Contact ID to remove: ");
            Console.ForegroundColor = ConsoleColor.Red;
            int id = Convert.ToInt32(Console.ReadLine());
            Console.ResetColor();

            using (var context = new MyContext())
            {
                var contactToRemove = context.Contact.FirstOrDefault(c => c.ContactId == id);

                if (contactToRemove != null)
                {

                    var contactDetailsToRemove = context.ContactDetails.Where(cd => cd.ContactId == id).ToList();
                    if (contactDetailsToRemove.Any())
                    {
                        context.ContactDetails.RemoveRange(contactDetailsToRemove);
                    }


                    context.Contact.Remove(contactToRemove);

                    context.SaveChanges();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Contact and all associated contact details removed successfully!");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Contact not found.");
                    Console.ResetColor();
                }
            }
        }


        public void UpdateContact()
        {
            Console.WriteLine("Enter Contact ID to update: ");
            Console.ForegroundColor = ConsoleColor.Red;
            int id = Convert.ToInt32(Console.ReadLine());
            Console.ResetColor();

            using (var context = new MyContext())
            {
                Contact contactToUpdate = context.Contact.FirstOrDefault(c => c.ContactId == id);

                if (contactToUpdate != null)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Current First Name: {contactToUpdate.FirstName}");
                    Console.WriteLine($"Current Last Name: {contactToUpdate.LastName}");
                    Console.ResetColor();
                    Console.WriteLine("Enter New First Name (leave blank to keep unchanged):");
                    Console.ForegroundColor = ConsoleColor.Red;
                    string newFirstName = Console.ReadLine();
                    Console.ResetColor();
                    if (!string.IsNullOrWhiteSpace(newFirstName))
                    {
                        contactToUpdate.FirstName = newFirstName;
                    }

                    Console.WriteLine("Enter New Last Name (leave blank to keep unchanged):");
                    Console.ForegroundColor = ConsoleColor.Red;
                    string newLastName = Console.ReadLine();
                    Console.ResetColor();
                    if (!string.IsNullOrWhiteSpace(newLastName))
                    {
                        contactToUpdate.LastName = newLastName;
                    }

                    Console.WriteLine("Do you want to update the associated contact details? (yes/no): ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    string updateDetailsChoice = Console.ReadLine().ToLower();
                    Console.ResetColor();

                    if (updateDetailsChoice == "yes")
                    {
                        contactDetailsRepository.UpdateContactDetails(id);
                    }
                    Console.WriteLine("Do you want to add new contact details? (yes/no): ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    string AddNewContactDetails = Console.ReadLine().ToLower();
                    Console.ResetColor();
                    if (AddNewContactDetails == "yes")
                    {
                        contactDetailsRepository.AddContactDetails(id);
                    }

                    context.Contact.Update(contactToUpdate);
                    context.SaveChanges();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Contact updated successfully!");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Contact not found.");
                    Console.ResetColor();
                }
            }
        }

        public void ViewContactByID()
        {
            Console.WriteLine("Enter Contact ID to view: ");
            Console.ForegroundColor = ConsoleColor.Red;
            int id = Convert.ToInt32(Console.ReadLine());
            Console.ResetColor();

            using (var context = new MyContext())
            {
                Contact contact = context.Contact.FirstOrDefault(c => c.ContactId == id);

                if (contact != null)
                {
                    Console.WriteLine("Contact Details:");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Contact ID: {contact.ContactId}");
                    Console.WriteLine($"First Name: {contact.FirstName}");
                    Console.WriteLine($"Last Name: {contact.LastName}");
                    Console.ResetColor();
                    var viewById = context.ContactDetails.Where(cd => cd.ContactId == id).ToList();
                    if (viewById != null && viewById.Any())
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Associated Contact Details:");
                        Console.ResetColor();
                        foreach (var detail in viewById)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"- ContactDetailsID: {detail.ContactDetailsID}, Type: {detail.Type}, Value: {detail.Value}");
                            Console.ResetColor();
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("No associated contact details found.");
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Contact not found.");
                    Console.ResetColor();
                }
            }
        }


        public void ViewAllContact()
        {
            using (var context = new MyContext())
            {
                var contacts = context.Contact.ToList();

                if (contacts.Any())
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("List of All Contacts:");
                    Console.ResetColor();
                    foreach (var contact in contacts)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Contact ID: {contact.ContactId}");
                        Console.WriteLine($"First Name: {contact.FirstName}");
                        Console.WriteLine($"Last Name: {contact.LastName}");
                        Console.ResetColor();
                        var contactDetailsList = context.ContactDetails.Where(cd => cd.ContactId == contact.ContactId).ToList();
                        if (contactDetailsList.Any())
                        {
                            Console.WriteLine("Associated Contact Details:");
                            foreach (var detail in contactDetailsList)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"- ContactDetailsID: {detail.ContactDetailsID}, Type: {detail.Type}, Value: {detail.Value}");
                                Console.ResetColor();
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("No associated contact details found.");
                            Console.ResetColor();
                        }

                        Console.WriteLine("----------------------");
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("No contacts found.");
                    Console.ResetColor();
                }
            }
        }
    }
}