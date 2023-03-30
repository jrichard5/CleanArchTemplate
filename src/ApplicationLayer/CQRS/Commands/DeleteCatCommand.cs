using MediatR;

namespace ApplicationLayer.CQRS.Commands
{
    public class DeleteCatCommand : IRequest<int>
    {
        public int CatId { get; set; }
    }
}
