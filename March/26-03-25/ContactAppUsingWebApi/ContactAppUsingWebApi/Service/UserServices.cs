using ContactAppUsingWebApi.Interfaces.IRepositoryes;
using ContactAppUsingWebApi.Interface.IServices;
using ContactAppUsingWebApi.Model.Entity;
using ContactAppUsingWebApi.Model.UserDto;
using BCrypt.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactAppUsingWebApi.Exception;

namespace ContactAppUsingWebApi.Service
{
    public class UserServices : IUserServices
    {
        private readonly IGenericRepository<User> repository;

        public UserServices(IGenericRepository<User> userRepository)
        {
            this.repository = userRepository;
        }

        public List<User> GetAllUsers()
        {
            var users = repository.GetAllAsync();
            return users.Where(user => user.IsActive==true).ToList();
        }

        public User LoginUser(int userId, string password)
        {
            var user = repository.GetByID(userId);
            if (user == null || !BCrypt.Net.BCrypt.EnhancedVerify(password, user.Password))
                return null;

            return user;
        }

        public async Task<User> AddStaff(User user)
        {
            var userEntity = new User
            {
                Name = user.Name,
                IsAdmin = false,
                IsActive = true,
                Password = user.Password,
                RoleId = 2,
            };

            await repository.AddAsync(userEntity);
            return userEntity;
        }

        public User UpdateStaffName(int userId, UpdateUserNameDto updateUserNameDto)
        {
            var user = repository.GetByID(userId);
            if (user != null)
            {
                user.Name = updateUserNameDto.Name;
                repository.Update(user);
                return user;
            }
            else
            {
                throw new MyNotFoundException("Not Found");
            }
        }

        public User UpdateStaffActivation(int userId, UpdateUserActivationDto updateUserActivationDto)
        {
            var user = repository.GetByID(userId);
            if (user != null)
            {
                user.IsActive = updateUserActivationDto.IsActive;
                repository.Update(user);
                return user;
            }
            else
            {
                throw new MyNotFoundException("Not Found");
            }
        }

        public User GetByID(int userId)
        {
            return repository.GetByID(userId);
        }

        public async Task DeleteEmployees(int userId)
        {
            var user = repository.GetByID(userId);
            if (user != null)
            {
                user.IsActive = false;
            }
            else
            {
                throw new MyNotFoundException("Not Found");
            }
        }

       
    }
}