using BankingApp.Model.Entity;

namespace BankingApp.Interfaces.IService
{
    public interface IUserServices
    {
        public List<User> GetAllUsers();
        public List<User> GetAllsUsers();
        public Task<User> AddUser(User user);
        public Task DeleteUsers(string UserEmail);
    }
}
