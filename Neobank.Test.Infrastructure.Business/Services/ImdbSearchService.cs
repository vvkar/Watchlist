using Microsoft.Extensions.Configuration;
using Neobank.Test.Domain.Core.DTO;
using Neobank.Test.Domain.Interfaces.Services;
using Newtonsoft.Json;
using System.Net;

namespace Neobank.Test.Infrastructure.Business.Services
{
    public class ImdbSearchService : IFilmSearchService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public ImdbSearchService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<IEnumerable<FilmDto>> GetFilmByNameAsync(string name)
        {
            var apiKey = _configuration["FilmSearchServices:IMDB:ApiKey"];    

            var response = await _httpClient.GetAsync($"Search/{apiKey}/{name}");

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception();

            var content = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<FilmDtoAggregate>(content);

            return result.Results;
        }
    }
}
