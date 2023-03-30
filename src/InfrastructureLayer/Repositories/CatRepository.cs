using ApplicationLayer.Entities;
using ApplicationLayer.InterfaceRepositories;

namespace InfrrastructureLayer.Repositories
{
    public class CatRepository: GenericRepository<Cat>, ICatRepository
    {
        public CatRepository(EntityContext entityContext) : base(entityContext)
        {
        }
    }
}
