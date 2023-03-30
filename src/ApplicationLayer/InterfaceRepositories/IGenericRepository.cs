namespace ApplicationLayer.InterfaceRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<List<T>> GetAll();
        public Task<T> FindByIdAsync(int id);
        public Task<T> AddAsync(T entity);
        public Task UpdateAsync(T entity);
        public Task DeleteAsync(T entity);
        public Task<int> AddManyFromCSV(IEnumerable<T> entities);
        public Task AddButNoSave(T entity);
        public Task SaveAllChanges();
    }
}
