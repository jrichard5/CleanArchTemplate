using ApplicationLayer.DTO_or_Interface;
using MediatR;

namespace ApplicationLayer.CQRS.Queries
{
    public class GetAllCatsQuery : IRequest<List<CatDTO>>
    {
    }
}
