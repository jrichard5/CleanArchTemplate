using ApplicationLayer.Entities;

namespace ApplicationLayer.InterfaceRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<List<T>> GetAll();
        public T FindById(int id);
        public Task AddAsync(T entity);
        public void UpdateAsync();
        public void DeleteAsync();
    }
}
