using ApplicationLayer.CQRS.Queries;
using ApplicationLayer.DTO_or_Interface;
using ApplicationLayer.Entities;
using ApplicationLayer.InterfaceRepositories;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Web;

namespace ApplicationLayer.CQRSHandlers.QueryHandlers
{
    public class GetAllCatsQueryHandler : IRequestHandler<GetAllCatsQuery, List<CatDTO>>
    {
        private readonly ICatRepository _catRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetAllCatsQueryHandler> _logger; // Unable to resolve service for type 'Microsoft.Extensions.Logging.ILogger'  error appears if you don't have <GetAllCatsQueryHandler>

        public GetAllCatsQueryHandler(ICatRepository catRepository, IMapper mapper, ILogger<GetAllCatsQueryHandler> logger)
        {
            _catRepository = catRepository;
            _mapper = mapper;
            _logger = logger;

        }

        public async Task<List<CatDTO>> Handle(GetAllCatsQuery request, CancellationToken cancellationToken)
        {
            var catList = await _catRepository.GetAll();
            var catDtoList = _mapper.Map<List<Cat>, List<CatDTO>>(catList);
            foreach (var cat in catDtoList)
            {
                cat.CatName = HttpUtility.HtmlEncode(cat.CatName);
            }

            _logger.LogInformation("\n\n a log message appears in both console and Debug Output");

            return catDtoList;
        }
    }
}
