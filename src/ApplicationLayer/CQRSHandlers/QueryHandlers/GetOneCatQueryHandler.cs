using ApplicationLayer.CQRS.Queries;
using ApplicationLayer.DTO_or_Interface;
using ApplicationLayer.InterfaceRepositories;
using AutoMapper;
using MediatR;

namespace ApplicationLayer.CQRSHandlers.QueryHandlers
{
    public class GetOneCatQueryHandler : IRequestHandler<GetOneCatQuery, CatDTO>
    {
        private readonly ICatRepository _catRepository;
        private readonly IMapper _mapper;

        public GetOneCatQueryHandler(ICatRepository catRepository, IMapper mapper)
        {
            _catRepository = catRepository;
            _mapper = mapper;
        }   

        public async Task<CatDTO> Handle(GetOneCatQuery request, CancellationToken cancellationToken)
        {
            var nonDtoCat =  await _catRepository.FindByIdAsync(request.Id);
            var dtoCat = _mapper.Map<CatDTO>(nonDtoCat);
            return dtoCat;

        }
    }
}
