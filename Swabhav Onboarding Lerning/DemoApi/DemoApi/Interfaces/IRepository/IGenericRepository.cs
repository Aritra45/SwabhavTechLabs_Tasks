using DemoApi.Models;


namespace DemoApi.Interfaces.IRepositoryes
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<List<T>> GetAllAsync();
        Task AddAsync(T t);
        public T GetByID(int id);

        public void Update(T t);

        public void Delete(T t);
    }
}
