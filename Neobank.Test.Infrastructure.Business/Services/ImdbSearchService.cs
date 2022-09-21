using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Neobank.Test.Domain.Core.DTO;
using Neobank.Test.Domain.Core.Exceptions;
using Neobank.Test.Domain.Interfaces.Services;
using Neobank.Test.Infrastructure.Business.Options;
using Newtonsoft.Json;
using System.Net;

namespace Neobank.Test.Infrastructure.Business.Services
{
    public class ImdbSearchService : IFilmSearchService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly FilmSearchServiceOptions _options;

        public ImdbSearchService(IHttpClientFactory clientFactory, IOptionsSnapshot<FilmSearchServiceOptions> namedOptions)
        {
            _clientFactory = clientFactory;
            _options = namedOptions.Get(FilmSearchServiceOptions.IMDB);
        }

        public async Task<IEnumerable<FilmDto>> GetFilmByTitleAsync(string title)
        {
            var client = _clientFactory.CreateClient();
            var baseUri = _options.BaseUri;
            var apiKey = _options.ApiKey;    

            var response = await client.GetAsync($"{baseUri}Search/{apiKey}/{title}");

            if (response.StatusCode != HttpStatusCode.OK)
                throw new BadRequestException("Something went wrong.");

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<FilmDtoHttpResponse>(content);

            if (!string.IsNullOrEmpty(result!.ErrorMessage))
                throw new BadRequestException(result.ErrorMessage);

            if (!result.Results.Any())
                throw new NotFoundException($"Haven't found anything with search parameter: {result.Expression}");

            return result.Results;
        }
    }
}
