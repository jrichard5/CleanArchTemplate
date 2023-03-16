using ApplicationLayer.Entities;
using ApplicationLayer.InterfaceRepositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrrastructureLayer.Repositories
{
    public class CatRepository: GenericRepository<Cat>, ICatRepository
    {

        public CatRepository(EntityContext entityContext) : base(entityContext)
        {
        }
    }
}
