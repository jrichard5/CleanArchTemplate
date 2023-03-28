using ApplicationLayer.CQRS.Commands;
using ApplicationLayer.Entities;
using ApplicationLayer.FluentValidators;
using ApplicationLayer.InterfaceRepositories;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ApplicationLayer.CQRSHandlers.CommandHandlers
{
    public class CreateNewCatCommandHandler : IRequestHandler<CreateNewCatCommand, int>
    {
        private readonly ICatRepository _catRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateNewCatCommandHandler> _logger;

        public CreateNewCatCommandHandler(ICatRepository catRepository, IMapper mapper, ILogger<CreateNewCatCommandHandler> logger)
        {
            _catRepository = catRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(CreateNewCatCommand request, CancellationToken cancellationToken)
        {
            CreateCatDtoValidator validator = new CreateCatDtoValidator();
            validator.ValidateOrThrowInfoException(request.CreateCatDto);


            var catEntity = _mapper.Map<Cat>(request.CreateCatDto);
            _logger.LogInformation("Right before adding");
            var catEntityPlusId = await _catRepository.AddAsync(catEntity);
            _logger.LogInformation("Added a new cat");
            return catEntityPlusId.CatId;
        }
    }
}
