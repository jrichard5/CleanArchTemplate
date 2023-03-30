using MediatR;

namespace ApplicationLayer.CQRS.Queries
{
    public class GetAllCatsCSV : IRequest<byte[]>
    {
    }
}
