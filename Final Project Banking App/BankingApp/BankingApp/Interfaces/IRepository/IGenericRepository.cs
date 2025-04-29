namespace BankingApp.Interfaces.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        public List<T> GetAllAsync();
        Task AddAsync(T t);
        void Update(T t);
        public T GetByID(int id);
        public T GetByEmail(string id);
        void Delete(T t);

    }
}
