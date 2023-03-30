using ApplicationLayer.DTO_or_Interface;
using MediatR;

namespace ApplicationLayer.CQRS.Commands
{
    public class CreateNewCatCommand : IRequest<int>
    {
        public CreateCatDto CreateCatDto { get; set; }
    }
}
