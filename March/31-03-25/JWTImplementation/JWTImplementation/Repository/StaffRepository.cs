using JWTImplementation.Data;
using JWTImplementation.Interfaces.IRepository;
using JWTImplementation.Model.Entity;
using JWTImplementation.Model.StaffDto;
using Microsoft.EntityFrameworkCore;

namespace JWTImplementation.Repository
{
    public class StaffRepository : IStaffRepository
    {
        private readonly MyContext context;

        DbSet<Staff> dbSet;
        public StaffRepository(MyContext context)
        {
            this.context = context;
            dbSet = context.Set<Staff>();
        }
        public Staff AddStaff(Staff staff)
        {
            var staffs = new Staff
            {
                Name = staff.Name,
                IsActive = true,
                IsAdmin = false,
                Password = staff.Password,
                RoleId = staff.RoleId
            };
            dbSet.Add(staffs);
            context.SaveChanges();
            return staffs;   
        }

        public List<Staff> GetAllStaffs()
        {
            return dbSet.ToList();
        }

        
    }
}
