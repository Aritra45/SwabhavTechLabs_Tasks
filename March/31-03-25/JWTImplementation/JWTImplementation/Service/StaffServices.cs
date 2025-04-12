using JWTImplementation.Interfaces.IRepository;
using JWTImplementation.Interfaces.IService;
using JWTImplementation.Model.Entity;
using JWTImplementation.Model.StaffDto;
using Microsoft.EntityFrameworkCore;

namespace JWTImplementation.Service
{
    public class StaffServices : IStaffServices
    {
        IStaffRepository staffRepository;
        public StaffServices(IStaffRepository staffRepository)
        {
            this.staffRepository = staffRepository;
        }

        public Staff AddStaff(Staff staff)
        {
            return staffRepository.AddStaff(staff);
        }

        public List<Staff> GetAllStaffs()
        {
            return staffRepository.GetAllStaffs();
        }

        
    }
}
