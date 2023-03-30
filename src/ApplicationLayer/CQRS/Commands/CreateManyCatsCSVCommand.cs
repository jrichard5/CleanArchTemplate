using ApplicationLayer.DTO_or_Interface;
using ApplicationLayer.Entities;
using MediatR;

namespace ApplicationLayer.CQRS.Commands
{
    public class CreateManyCatsCSVCommand : IRequest<int>
    {
        public IEnumerable<CreateCatDto> CreateCatDtos { get; set; }
    }
}
