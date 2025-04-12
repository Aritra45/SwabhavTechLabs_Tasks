using AutoMapper;
using ContactAppUsingWebApi.Model.ContactDetailsDto;
using ContactAppUsingWebApi.Model.ContactDto;
using ContactAppUsingWebApi.Model.Entity;
using ContactAppUsingWebApi.Model.RoleDto;
using ContactAppUsingWebApi.Model.UserDto;
namespace ContactAppUsingWebApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Role, AddRoleDto>();
            CreateMap<AddRoleDto, Role>();

            CreateMap<User, LoginSuccessDto>();
            CreateMap<LoginSuccessDto, User>();

            CreateMap<User, LogingUserDto>();
            CreateMap<LogingUserDto, User>();

            CreateMap<User, GetAllUserDto>();
            CreateMap<GetAllUserDto, User>();

            CreateMap<User, AddUserDto>();
            CreateMap<AddUserDto, User>();

            CreateMap<User, UpdateUserActivationDto>();
            CreateMap<UpdateUserActivationDto, User>();

            CreateMap<User, UpdateUserNameDto>();
            CreateMap<UpdateUserNameDto, User>();

            CreateMap<Contact, GetAllContactDto>();
            CreateMap<GetAllContactDto, Contact>();

            CreateMap<Contact, AddContactDto>();
            CreateMap<AddContactDto, Contact>();

            CreateMap<Contact, UpdateContactActivationDto>();
            CreateMap<UpdateContactActivationDto, Contact>();

            CreateMap<Contact, UpdateContactFirstNameDto>();
            CreateMap<UpdateContactFirstNameDto, Contact>();

            CreateMap<Contact, UpdateContactLastNameDto>();
            CreateMap<UpdateContactLastNameDto, Contact>();

            CreateMap<ContactDetails, GetAllContactDetailsDto>();
            CreateMap<GetAllContactDetailsDto, ContactDetails>();

            CreateMap<ContactDetails, AddContactDetailsDto>();
            CreateMap<AddContactDetailsDto, ContactDetails>();

            CreateMap<ContactDetails, UpdateContactDetailsActivationDto>();
            CreateMap<UpdateContactDetailsActivationDto, ContactDetails>();

            CreateMap<ContactDetails, UpdateContactDetailsTypeDto>();
            CreateMap<UpdateContactDetailsTypeDto, ContactDetails>();

            CreateMap<ContactDetails, UpdateContactDetailsValueDto>();
            CreateMap<UpdateContactDetailsValueDto, ContactDetails>();

        }
    }
}
