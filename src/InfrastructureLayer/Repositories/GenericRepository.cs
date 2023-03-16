using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLayer.Entities;
using ApplicationLayer.InterfaceRepositories;
using AutoMapper;
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


        public async Task AddAsync(T entity)
        {
            await this._dbContext.Set<T>().AddAsync(entity);
            await this._dbContext.SaveChangesAsync();
        }

        public void DeleteAsync()
        {
            throw new NotImplementedException();
        }

        public T FindById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> GetAll()
        {
            var entities = await this._dbContext.Set<T>().ToListAsync();
            return entities;
        }

        public void UpdateAsync()
        {
            throw new NotImplementedException();
        }
    }

}
