using ApplicationLayer.CQRS.Commands;
using ApplicationLayer.CQRSHandlers.CommandHandlers;
using ApplicationLayer.DTO_or_Interface;
using ApplicationLayer.Entities;
using ApplicationLayer.InterfaceRepositories;
using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xUnitTestProject.mediatrHandlerTests
{
    public class CatCreateHandlerTest
    {
        [Fact]
        public async Task CreateNewCatCommandHandler_Valid_Success()
        {
            //Doesn't really feel like I'm testing anything, but this can be a code snippet for future tests

            var createCatCommand = new CreateNewCatCommand
            {
                CreateCatDto = new CreateCatDto { CatName = "Test", CatOwner = "OwnerTest" }
            };

            var cat = new Cat
            {
                CatName = "Test",
                CatOwner = "OwnerTeset"
            };

            var cat2 = new Cat
            {
                CatId = 10981241,
                CatName = "Test",
                CatOwner = "OwnerTeset"
            };

            var mockRepo = new Mock<ICatRepository>();
            var mockMapper = new Mock<IMapper>();

            mockMapper.Setup(m => m.Map<Cat>(It.IsAny<CreateCatDto>()))
                .Returns(cat);

            mockRepo.Setup(repo => repo.AddAsync(cat))
                .ReturnsAsync(cat2);

            var createHandler = new CreateNewCatCommandHandler(mockRepo.Object, mockMapper.Object);

            var result = createHandler.Handle(createCatCommand, It.IsAny<CancellationToken>()).Result;

            Assert.Equal(10981241, result);
            mockRepo.Verify(repo => repo.AddAsync(cat), Times.Exactly(1));
        }
    }
}
