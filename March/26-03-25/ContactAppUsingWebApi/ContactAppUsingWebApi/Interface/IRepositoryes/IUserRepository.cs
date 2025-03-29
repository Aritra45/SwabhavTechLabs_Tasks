using ContactAppUsingWebApi.Model.Entity;
using ContactAppUsingWebApi.Model.UserDto;

namespace ContactAppUsingWebApi.Interface.IRepositoryes
{
    public interface IUserRepository
    {
        public List<User> GetAllUsers();
        public User AddStaff(User user);
        public User UpdateStaffName(int userId, UpdateUserNameDto updateUserNameDto);
        public User UpdateStaffActivation(int userId, UpdateUserActivationDto updateUserActivationDto);
        public User GetByID(int userId);
        public User DeleteEmployees(int userId);
    }
}
