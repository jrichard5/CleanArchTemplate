using ApplicationLayer.CQRS.Commands;
using ApplicationLayer.Entities;
using ApplicationLayer.InterfaceRepositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.CQRSHandlers.CommandHandlers
{
    public class CreateNewCatCommandHandler : IRequestHandler<CreateNewCatCommand, int>
    {
        private readonly ICatRepository _catRepository;
        private readonly IMapper _mapper;

        public CreateNewCatCommandHandler(ICatRepository catRepository, IMapper mapper)
        {
            _catRepository = catRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateNewCatCommand request, CancellationToken cancellationToken)
        {
            var catEntity = _mapper.Map<Cat>(request.CreateCatDto);
            var catEntityPlusId = await _catRepository.AddAsync(catEntity);
            return catEntityPlusId.CatId;
        }
    }
}
