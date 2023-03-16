using ApplicationLayer.DTO_or_Interface;
using ApplicationLayer.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.CQRS.Queries
{
    public class GetAllCatsQuery : IRequest<List<CatDTO>>
    {
    }
}
