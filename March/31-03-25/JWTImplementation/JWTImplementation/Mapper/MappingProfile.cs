using AutoMapper;
using JWTImplementation.Model.Entity;
using JWTImplementation.Model.StaffDto;



namespace JWTImplementation.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Staff, AddStaffDto>();
            CreateMap<AddStaffDto, Staff>();

            CreateMap<Staff, AddSuccessDto>();
            CreateMap<AddSuccessDto, Staff>();

            CreateMap<Staff, GetAllStaffsDto>();
            CreateMap<GetAllStaffsDto, Staff>();


        }
    }
}
