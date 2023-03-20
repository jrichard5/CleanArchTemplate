using ApplicationLayer.DTO_or_Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.CQRS.Commands
{
    public class CreateNewCatCommand : IRequest<int>
    {
        public CreateCatDto CreateCatDto { get; set; }
    }
}
