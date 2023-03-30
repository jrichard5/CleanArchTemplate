using ApplicationLayer.CQRS.Commands;
using ApplicationLayer.Entities;
using ApplicationLayer.FluentValidators;
using ApplicationLayer.InterfaceRepositories;
using AutoMapper;
using MediatR;

namespace ApplicationLayer.CQRSHandlers.CommandHandlers
{
    public class CreateManyCatsCSVCommandHandler : IRequestHandler<CreateManyCatsCSVCommand, int>
    {
        private readonly ICatRepository _catRepository;
        private readonly IMapper _mapper;

        public CreateManyCatsCSVCommandHandler(ICatRepository catRepository, IMapper mapper)
        {
            _catRepository = catRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateManyCatsCSVCommand request, CancellationToken cancellationToken)
        {
            //TODO:  I wonder if I can get a code review on this somehow....
            //CSV Injection:  Website write a CSV that has cells starting with =.  When CSV is ran with Excel or LibreOffice Calc, it can execute malicious forumulas
            var catCount = 0;
            CreateCatDtoValidator validator = new CreateCatDtoValidator();
            Cat catEntity;

            foreach (var catDto in request.CreateCatDtos)
            {
                validator.ValidateOrThrowInfoException(catDto);
                catEntity = _mapper.Map<Cat>(catDto);
                await _catRepository.AddButNoSave(catEntity);
                catCount++;
            }
            await _catRepository.SaveAllChanges();

            return catCount;
        }
    }
}
