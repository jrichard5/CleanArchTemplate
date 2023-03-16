using ApplicationLayer.CQRS.Queries;
using ApplicationLayer.DTO_or_Interface;
using ApplicationLayer.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TemplateASPNETCoreWebAPI.Controllers
{
    [ApiController]
    [Route("api/cats")]
    public class CatsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CatsController(IMediator mediator)
        {
            this._mediator = mediator;

        }
        [HttpGet (Name = "GetCats")]
        public async Task<List<CatDTO>> GetAllCatsAsync()
        {
            var Cats = await _mediator.Send(new GetAllCatsQuery());
            return Cats;
        }
  
    }
}
