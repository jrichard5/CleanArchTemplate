using ApplicationLayer.Entities;
using InfrrastructureLayer;
using InfrrastructureLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace xUnitTestProject.RepoTests
{
    public class CatRepoTests
    {
        [Fact]
        public async Task GetAllCats_Valid_Success()
        {
            var catList = new List<Cat>
            {
                new Cat {CatId = 0, CatName = "Mr.Test", CatOwner = "OwnerTest"},
                new Cat {CatId = 1, CatName = "Mr.Pizza", CatOwner = "PizzeTest"},
                new Cat {CatId = 2, CatName = "Mr.Cookie", CatOwner = "CookieTest"},
                new Cat {CatId = 3, CatName = "Mr.Cheese", CatOwner = "CheeseTest"},
                new Cat {CatId = 4, CatName = "Mr.Bread", CatOwner = "BreadTest"},
            }.AsQueryable();

            var mockSet = catList.ToAsyncDbSetMock();
            
            var dbContextMock = new Mock<EntityContext>(new DbContextOptions<EntityContext>());
            dbContextMock.Setup(x => x.Set<Cat>()).Returns(mockSet.Object);

            var catRepo = new CatRepository(dbContextMock.Object);

            var results = catRepo.GetAll().Result;
            Assert.Equal(5, results.Count);
            Assert.Equal(4, results[4].CatId);
            Assert.Equal("Mr.Test", results[0].CatName);
            Assert.Contains(results, cat => cat.CatOwner == "CookieTest");
        }
    }
}
