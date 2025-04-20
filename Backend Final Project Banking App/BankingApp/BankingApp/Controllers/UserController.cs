using AutoMapper;
using BankingApp.Interfaces.IService;
using BankingApp.Mapper;
using BankingApp.Model.Entity;
using BankingApp.Model.UserDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserServices userServices;
        IMapper mapper;
        public UserController(IUserServices userServices)
        {
            this.userServices = userServices;
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            mapper = config.CreateMapper();
            this.mapper = mapper;
        }

        [HttpGet("all-admins")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllUsers()
        {
            var allUsers = userServices.GetAllUsers();
            var getUsers = mapper.Map<List<GetAllUsersDto>>(allUsers);
            return Ok(getUsers);
        }

        [HttpPost("add-admin")]
        [Authorize(Roles = "Admin")]
        public IActionResult AddUsers([FromForm] AddUserDto addUserDto)
        {
            //var users = mapper.Map<User>(addUserDto);
            //var newUser = userServices.AddUser(users);
            string passwd = BCrypt.Net.BCrypt.EnhancedHashPassword(addUserDto.UserPassword);
            addUserDto.UserPassword = passwd;
            var user = mapper.Map<User>(addUserDto);
            var userEntity = userServices.AddUser(user);
            if (userEntity.Status.ToString() != "Faulted")
            {
                return Ok("User Added Successfully");
            }
            else
            {
                return UnprocessableEntity("Email Already Used");
            }
        }

        [HttpDelete("remove-admin-access/{UserEmail}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteEmployees(string UserEmail)
        {
            userServices.DeleteUsers(UserEmail);
            return Ok("User Deleted Successfully");
        }
    }
}
