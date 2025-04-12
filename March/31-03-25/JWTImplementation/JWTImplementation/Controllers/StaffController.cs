using AutoMapper;
using JWTImplementation.Interfaces.IService;
using JWTImplementation.Mapper;
using JWTImplementation.Model.Entity;
using JWTImplementation.Model.StaffDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTImplementation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        IStaffServices staffServices;
        IMapper mapper;
        public StaffController(IStaffServices staffServices)
        {
            this.staffServices = staffServices;
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            mapper = config.CreateMapper();
        }

        [HttpGet("get-all-staffs")]
        [Authorize(Roles = "Staff")]
        public IActionResult GetAllStaffs()
        {
            var staff = staffServices.GetAllStaffs();
            var staffEntity = mapper.Map<List<GetAllStaffsDto>>(staff); ;
            return Ok(staffEntity);
        }


        [HttpPost("add-new-staff")]
        [Authorize(Roles = "Admin")]
        public IActionResult AddStaff(AddStaffDto addStaffDto)
        {
            string passwd = BCrypt.Net.BCrypt.EnhancedHashPassword(addStaffDto.Password);
            addStaffDto.Password = passwd;
            var staff = mapper.Map<Staff>(addStaffDto);
            var staffs = staffServices.AddStaff(staff);
            var staffSuccess = mapper.Map<AddSuccessDto>(staffs);
            return Ok(staffSuccess);
        }
    }
}
