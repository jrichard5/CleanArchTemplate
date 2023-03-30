using ApplicationLayer.CQRS.Queries;
using ApplicationLayer.InterfaceRepositories;
using CsvHelper;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Globalization;

namespace ApplicationLayer.CQRSHandlers.QueryHandlers
{
    public class GetAllCatsCSVHandler : IRequestHandler<GetAllCatsCSV, byte[]>
    {
        private readonly ICatRepository _catRepository;
        private readonly ILogger<GetAllCatsCSVHandler> _logger;

        public GetAllCatsCSVHandler(ICatRepository catRepository, ILogger<GetAllCatsCSVHandler> logger)
        {
            _catRepository = catRepository;
            _logger = logger;
        }

        public async Task<byte[]> Handle(GetAllCatsCSV request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Staring the CSV file Handle method");
            var cats = await _catRepository.GetAll();

            byte[] bin;
            using (MemoryStream stream = new MemoryStream())
            {
                using(TextWriter textwriter = new StreamWriter(stream))
                using(CsvWriter csv = new CsvWriter(textwriter, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(cats);
                }
                bin = stream.ToArray();
            }

            return bin;

        }
    }
}
