using ApplicationLayer.CQRS.Commands;
using ApplicationLayer.DTO_or_Interface;
using ApplicationLayer.Entities;
using ApplicationLayer.InterfaceRepositories;
using AutoMapper;
using MediatR;

namespace ApplicationLayer.CQRSHandlers.CommandHandlers
{
    public class UpdateCatCommandHandler : IRequestHandler<UpdateCatCommand, int>
    {
        private readonly ICatRepository _catRepository;
        private readonly IMapper _mapper;

        public UpdateCatCommandHandler(ICatRepository catRepository, IMapper mapper)
        {
            _catRepository = catRepository;
            _mapper = mapper;
        }


        //Using Automapper to update values  https://stackoverflow.com/questions/2374689/automapper-update-property-values-without-creating-a-new-object
        public async Task<int> Handle(UpdateCatCommand request, CancellationToken cancellationToken)
        {
            var catEntity = await _catRepository.FindByIdAsync(request.CatId) ;

            if (catEntity != null)
            {
                catEntity = _mapper.Map<CreateCatDto, Cat>(request.CreateCatDto, catEntity);
                await _catRepository.UpdateAsync(catEntity);

                return catEntity.CatId;
            }
            else
            {
                //TODO: Maybe there is better way to handle if id didn't exist
                return -1;
            }
        }
    }
}


/* 
 * For more info about this error https://stackoverflow.com/questions/62934010/the-instance-of-the-entity-type-cannot-be-tracked-because-another-instance-with
 * 
 * System.InvalidOperationException: The instance of entity type 'Cat' cannot be tracked because another instance with the same key value for {'CatId'} is already being tracked.
 * var catEntity = _mapper.Map<Cat>(request.CreateCatDto);
                catEntity.CatId = request.CatId;
                await _catRepository.UpdateAsync(catEntity);

                return catEntity.CatId;
*/
