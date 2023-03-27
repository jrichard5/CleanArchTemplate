using ApplicationLayer.InterfaceRepositories;
using Microsoft.EntityFrameworkCore;

namespace InfrrastructureLayer.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly EntityContext _dbContext;

        public GenericRepository(EntityContext dbContext)
        {
            this._dbContext = dbContext;
        }


        public async Task<T> AddAsync(T entity)
        {
            var result = await this._dbContext.Set<T>().AddAsync(entity);
            await this._dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteAsync(T entity)
        {
            this._dbContext.Set<T>().Remove(entity);
            await this._dbContext.SaveChangesAsync();
        }

        public async Task<T> FindByIdAsync(int id)
        {
            var entity = await this._dbContext.Set<T>().FindAsync(id);
            return entity;
        }

        public async Task<List<T>> GetAll()
        {
            var entities = await this._dbContext.Set<T>().ToListAsync();
            return entities;
        }

        //TODO:  Wanted to get the return value from update() and then return that back to the handler function to show that it was updated.  But now that seems kinda pointless.
        public async Task UpdateAsync(T entity)
        {
            this._dbContext.Set<T>().Update(entity);
            await this._dbContext.SaveChangesAsync();
        }
    }

}
