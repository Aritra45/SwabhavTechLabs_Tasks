using ContactAppUsingWebApi.Data;
using ContactAppUsingWebApi.Interface.IRepositoryes;
using ContactAppUsingWebApi.Model.Entity;
using ContactAppUsingWebApi.Model.UserDto;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ContactAppUsingWebApi.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MyContext context;
        DbSet<User> dbSet;

        public UserRepository(MyContext context)
        {
            this.context = context;
            dbSet = context.Set<User>();
        }


        public List<User> GetAllUsers()
        {
            return dbSet.ToList();
        }

        
        //public void AddAdminStaff()
        //{
        //    var userEntity = new User
        //    {
        //        Name = "Aritra",
        //        IsAdmin = true,
        //        IsActive = true,
        //        Password = BCrypt.Net.BCrypt.EnhancedHashPassword("1234"),
        //        RoleId = 1
        //    };

        //    context.Users.Add(userEntity);
        //    context.SaveChanges();
        //}
        public User AddStaff(User user)
        {
            var userEntity = new User
            {
                Name = user.Name,
                IsAdmin = true,
                IsActive = true,
                Password = user.Password,
                RoleId = 2,
            };

            dbSet.Add(userEntity);
            context.SaveChanges();
            return userEntity;
        }


        public User UpdateStaffName(int userId, UpdateUserNameDto updateUserNameDto)
        {
            var userEntity = dbSet.Find(userId);
            if (userEntity == null)
            {
                throw new KeyNotFoundException($"Staff with ID {userId} not found.");
            }

            userEntity.Name = updateUserNameDto.Name;
            context.SaveChanges();
            return userEntity;
        }


        public User UpdateStaffActivation(int userId, UpdateUserActivationDto updateUserActivationDto)
        {
            var userEntity = dbSet.Find(userId);
            if (userEntity == null)
            {
                throw new KeyNotFoundException($"Staff with ID {userId} not found.");
            }

            userEntity.IsActive = updateUserActivationDto.IsActive;
            context.SaveChanges();
            return userEntity;
        }


        public User GetByID(int userId)
        {
            var userEntity = dbSet.Find(userId);
            if (userEntity == null)
            {
                throw new KeyNotFoundException($"Staff with ID {userId} not found.");
            }

            return userEntity;
        }


        public User DeleteEmployees(int userId)
        {
            var userEntity = dbSet.Find(userId);
            if (userEntity == null)
            {
                throw new KeyNotFoundException($"Staff with ID {userId} not found.");
            }

            userEntity.IsActive = false;
            context.SaveChanges();
            return userEntity;
        }
    }
}