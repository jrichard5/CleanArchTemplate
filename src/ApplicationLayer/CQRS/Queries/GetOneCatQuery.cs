using ApplicationLayer.DTO_or_Interface;
using MediatR;

namespace ApplicationLayer.CQRS.Queries
{
    public class GetOneCatQuery : IRequest<CatDTO>
    {
        public int Id { get; set; }
    }
}
