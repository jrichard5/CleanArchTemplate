
using ApplicationLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace InfrrastructureLayer
{
    public class EntityContext : DbContext
    {
        
        public EntityContext(DbContextOptions<EntityContext> options) : base(options)
        {

        }
        /*
         public EntityContext() : base()
         {

         }
        */

        //Need virtual for Unit test (CatRepoTests.  Otherwise System.NotSupportedException : Unsupported expression: x => x.Cats)
        public virtual DbSet<Cat> Cats { get; set; }

        //TODO: delete this from final
        //from https://learn.microsoft.com/en-us/ef/core/dbcontext-configuration/
        //Tried to figure out how to implement dependency injection
        
        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("");
        }
        */

    }
}
