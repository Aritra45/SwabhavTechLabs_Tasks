using JWTImplementation.Model.Entity;
using JWTImplementation.Model.StaffDto;

namespace JWTImplementation.Interfaces.IRepository
{
    public interface IStaffRepository
    {
        public List<Staff> GetAllStaffs();
        public Staff AddStaff(Staff staff);
    }
}
