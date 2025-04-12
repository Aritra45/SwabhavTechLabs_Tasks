using ContactAppUsingWebApi.Model.ContactDto;
using ContactAppUsingWebApi.Model.Entity;

namespace ContactAppUsingWebApi.Interface.IRepositoryes
{
    public interface IContactRepository
    {
        public List<Contact> GetAllContacts();
        public Contact AddContact(AddContactDto addContactDto);
        public Contact UpdateContactFirstName(int contactId, UpdateContactFirstNameDto updateContactFirstNameDto);
        public Contact UpdateContactLastName(int contactId, UpdateContactLastNameDto updateContactLastNameDto);
        public Contact UpdateContactActivation(int contactId, UpdateContactActivationDto updateContactActivationDto);
        public Contact DeleteContact(int contactId);
    }
}
