using ApplicationLayer.CQRS.Queries;
using ApplicationLayer.CQRS.Commands;
using ApplicationLayer.DTO_or_Interface;
using ApplicationLayer.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace TemplateASPNETCoreWebAPI.Controllers
{
    /*
     * TODO: Questions
     * -Should I return a simple type like an Task<int>  or use Task<IActionResult> so that I can return things such as "Badrequest()" "NoContent()" "Content()"
     * 
     */


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

        [HttpGet ("{id}", Name = "GetSingleCat")]
        public async Task<IActionResult> GetOneCatAsync(int id)
        {
            var Cat = await _mediator.Send(new GetOneCatQuery { Id = id });
            if (Cat == null)
            {
                return NotFound();
            }
            return Content(JsonSerializer.Serialize(Cat));
        }

        [HttpPost (Name = "CreateEntryForNewCat")]
        public async Task<IActionResult> PostNewCatAsync([FromBody] CreateCatDto newCatDto)
        {
            var id = await _mediator.Send(new CreateNewCatCommand { CreateCatDto = newCatDto });
            return Content(JsonSerializer.Serialize(id));
        }

        [HttpPut ("{id}", Name = "UpdateCat")]
        public async Task<IActionResult> UpdateCatInfo( int id, [FromBody] CreateCatDto newCatDto)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            var catId = await _mediator.Send(new UpdateCatCommand { CatId = id, CreateCatDto = newCatDto }) ;
            return Ok(catId);
        }

        [HttpDelete("{id}", Name = "DeleteCat")]
        public async Task<IActionResult> DeleteACat(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            var catId = await _mediator.Send(new DeleteCatCommand { CatId = id });
            return Ok(catId);
        }
    }
}
