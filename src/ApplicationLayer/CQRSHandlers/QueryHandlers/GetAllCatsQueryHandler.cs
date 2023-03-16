using ApplicationLayer.CQRS.Queries;
using ApplicationLayer.DTO_or_Interface;
using ApplicationLayer.Entities;
using ApplicationLayer.InterfaceRepositories;
using AutoMapper;
using MediatR;

namespace ApplicationLayer.CQRSHandlers.QueryHandlers
{
    public class GetAllCatsQueryHandler : IRequestHandler<GetAllCatsQuery, List<CatDTO>>
    {
        private readonly ICatRepository _catRepository;
        private readonly IMapper _mapper;

        public GetAllCatsQueryHandler(ICatRepository catRepository, IMapper mapper)
        {
            _catRepository = catRepository;
            _mapper = mapper;
        }

        public async Task<List<CatDTO>> Handle(GetAllCatsQuery request, CancellationToken cancellationToken)
        {
            var catList = await _catRepository.GetAll();
            var catDtoList = _mapper.Map<List<Cat>, List<CatDTO>>(catList);

            return catDtoList;
        }
    }
}
