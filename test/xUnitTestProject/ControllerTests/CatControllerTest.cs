using ApplicationLayer.CQRS.Queries;
using ApplicationLayer.DTO_or_Interface;
using MediatR;
using Moq;
using TemplateASPNETCoreWebAPI.Controllers;

namespace xUnitTestProject.ControllerTests
{
    public class CatControllerTest
    {
        [Fact]
        public async Task CatController_GetAllCats_Success()
        {
            GetAllCatsQuery query = new GetAllCatsQuery();
            List<CatDTO> cats = new List<CatDTO>
            {
                new CatDTO{ CatId = 1, CatName = "Mr.Mewos"},
                new CatDTO{ CatId = 2, CatName = "chhese"}
            };

            var mediator = new Mock<IMediator>();
            mediator.Setup(med => med.Send(It.IsAny<GetAllCatsQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(cats);

            var controller = new CatsController(mediator.Object);

            var actual = controller.GetAllCatsAsync().Result;
            Assert.Equal(2, actual.Count);
            Assert.Equal("Mr.Mewos", actual[0].CatName);
            Assert.Equal(2, actual[1].CatId);
        }
    }
}
