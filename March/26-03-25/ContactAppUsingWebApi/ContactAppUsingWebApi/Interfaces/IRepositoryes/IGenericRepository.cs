using ContactAppUsingWebApi.Model.Entity;
using ContactAppUsingWebApi.Model.UserDto;

namespace ContactAppUsingWebApi.Interfaces.IRepositoryes
{
    public interface IGenericRepository<T> where T : class
    {
        public List<T> GetAllAsync();
        Task AddAsync(T t);
        void Update(T t);
        public T GetByID(int id);
        void Delete(T t);
    }
}
