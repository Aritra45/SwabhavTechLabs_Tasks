using ContactAppUsingWebApi.Model.ContactDetailsDto;
using ContactAppUsingWebApi.Model.Entity;

namespace ContactAppUsingWebApi.Interface.IRepositoryes
{
    public interface IContactDetailsRepository
    {
        public List<ContactDetails> GetAllContactDetails();
        public ContactDetails AddContactDetails(AddContactDetailsDto addContactDetailsDto);
        public ContactDetails UpdateContactDetailsType(int contactDetailsId, UpdateContactDetailsTypeDto updateContactDetailsTypeDto);
        public ContactDetails UpdateContactDetailsValue(int contactDetailsId, UpdateContactDetailsValueDto updateContactDetailsValueDto);
        public ContactDetails UpdateContactDetailsActivation(int contactDetailsId, UpdateContactDetailsActivationDto updateContactDetailsActivationDto);
        public ContactDetails DeleteContactDetails(int contactDetailsId);
    }
}
