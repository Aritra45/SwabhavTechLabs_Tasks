using ContactAppUsingWebApi.Model.Entity;
using ContactAppUsingWebApi.Model.UserDto;
using Microsoft.AspNetCore.Mvc;

namespace ContactAppUsingWebApi.Interface.IServices
{
    public interface IUserServices
    {
        public List<User> GetAllUsers();
        public User LoginUser(int userId, string password);
        public Task<User> AddStaff(User user);
        public User UpdateStaffName(int userId, UpdateUserNameDto updateUserNameDto);
        public User UpdateStaffActivation(int userId, UpdateUserActivationDto updateUserActivationDto);
        public User GetByID(int userId);
        public Task DeleteEmployees(int userId);

    }
}
