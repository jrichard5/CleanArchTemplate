using ApplicationLayer.CQRS.Commands;
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
    public class DeleteCatCommandHandler : IRequestHandler<DeleteCatCommand, int>
    {
        private readonly ICatRepository _catRepository;
        private readonly IMapper _mapper;

        public DeleteCatCommandHandler(ICatRepository catRepository, IMapper mapper)
        {
            _catRepository = catRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(DeleteCatCommand request, CancellationToken cancellationToken)
        {
            var catEntity = await _catRepository.FindByIdAsync(request.CatId);
            if (catEntity != null)
            {
                await _catRepository.DeleteAsync(catEntity);
                return request.CatId;
            }
            else
            {
                //TODO: Maybe there is better way to handle if id didn't exist
                return -1;
            }
        }
    }
}
