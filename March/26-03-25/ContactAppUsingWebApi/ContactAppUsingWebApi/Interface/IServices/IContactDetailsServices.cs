using ContactAppUsingWebApi.Model.ContactDetailsDto;
using ContactAppUsingWebApi.Model.Entity;
using Microsoft.AspNetCore.Mvc;

namespace ContactAppUsingWebApi.Interface.IServices
{
    public interface IContactDetailsServices
    {
        public List<ContactDetails> GetAllContactDetails();
        public ContactDetails AddContactDetails(AddContactDetailsDto addContactDetailsDto);
        public ContactDetails UpdateContactDetailsType(int contactDetailsId, UpdateContactDetailsTypeDto updateContactDetailsTypeDto);
        public ContactDetails UpdateContactDetailsValue(int contactDetailsId, UpdateContactDetailsValueDto updateContactDetailsValueDto);
        public ContactDetails UpdateContactDetailsActivation(int contactDetailsId, UpdateContactDetailsActivationDto updateContactDetailsActivationDto);
        public ContactDetails DeleteContactDetails(int contactDetailsId);
    }
}
