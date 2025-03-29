using ContactAppUsingWebApi.Data;
using ContactAppUsingWebApi.Interface.IRepositoryes;
using ContactAppUsingWebApi.Model.ContactDto;
using ContactAppUsingWebApi.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace ContactAppUsingWebApi.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly MyContext context;

        DbSet<Contact> dbSet;
        public ContactRepository(MyContext context)
        {
            this.context = context;
            dbSet = context.Set<Contact>();
        }


        public List<Contact> GetAllContacts()
        {
            return dbSet.ToList();
        }


        public Contact AddContact(AddContactDto addContactDto)
        {
            var contactEntity = new Contact
            {
                FirstName = addContactDto.FirstName,
                LastName = addContactDto.LastName,
                IsActive = true,
                UserId = addContactDto.UserId
            };

            dbSet.Add(contactEntity);
            context.SaveChanges();
            return contactEntity;
        }


        public Contact UpdateContactFirstName(int contactId, UpdateContactFirstNameDto updateContactFirstNameDto)
        {
            var contactEntity = dbSet.Find(contactId);
            if (contactEntity == null)
            {
                throw new KeyNotFoundException($"Contact with ID {contactId} not found.");
            }

            contactEntity.FirstName = updateContactFirstNameDto.FirstName;
            context.SaveChanges();
            return contactEntity;
        }


        public Contact UpdateContactLastName(int contactId, UpdateContactLastNameDto updateContactLastNameDto)
        {
            var contactEntity = dbSet.Find(contactId);
            if (contactEntity == null)
            {
                throw new KeyNotFoundException($"Contact with ID {contactId} not found.");
            }

            contactEntity.LastName = updateContactLastNameDto.LastName;
            context.SaveChanges();
            return contactEntity;
        }


        public Contact UpdateContactActivation(int contactId, UpdateContactActivationDto updateContactActivationDto)
        {
            var contactEntity = dbSet.Find(contactId);
            if (contactEntity == null)
            {
                throw new KeyNotFoundException($"Contact with ID {contactId} not found.");
            }

            contactEntity.IsActive = updateContactActivationDto.IsActive;
            context.SaveChanges();
            return contactEntity;
        }


        public Contact DeleteContact(int contactId)
        {
            var contactEntity = dbSet.Find(contactId);
            if (contactEntity == null)
            {
                throw new KeyNotFoundException($"Contact with ID {contactId} not found.");
            }

            contactEntity.IsActive = false;
            context.SaveChanges();
            return contactEntity;
        }
    }
}