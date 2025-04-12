using JWTImplementation.Model;
using JWTImplementation.Model.Entity;
using JWTImplementation.Model.StaffDto;

namespace JWTImplementation.Interfaces.IService
{
    public interface IStaffServices
    {
        public List<Staff> GetAllStaffs();
        public Staff AddStaff(Staff staff);
    }
}
