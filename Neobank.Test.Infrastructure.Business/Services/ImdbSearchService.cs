using AutoMapper;
using Microsoft.Extensions.Options;
using Neobank.Test.Domain.Core.Exceptions;
using Neobank.Test.Domain.Core.Models;
using Neobank.Test.Domain.Core.Options;
using Neobank.Test.Domain.Interfaces.Services;
using Neobank.Test.Infrastructure.Business.DTO;
using Neobank.Test.Infrastructure.Business.DTO.Base;
using Newtonsoft.Json;
using System.Net;

namespace Neobank.Test.Infrastructure.Business.Services
{
    public class ImdbSearchService : IFilmSearchService
    {
        private readonly IMapper _mapper;
        private readonly HttpClient _client;
        private readonly FilmSearchServiceOptions _options;

        public ImdbSearchService(IMapper mapper, HttpClient client, IOptionsSnapshot<FilmSearchServiceOptions> namedOptions)
        {
            _mapper = mapper;
            _client = client;
            _options = namedOptions.Get(FilmSearchServiceOptions.IMDB);
            _client.BaseAddress = new Uri(_options.BaseUri);
            
        }

        public async Task<FullFilmModel> GetFilmByIdAsync(string filmId)
        {
            var response = await _client.GetAsync($"Title/{_options.ApiKey}/{filmId}");

            var result = await CheckAndDeserialize<FullFilmResponseDto>(response);

            var model = _mapper.Map<FullFilmModel>(result);

            return model;
        }

        public async Task<IEnumerable<ShortFilmModel>> GetFilmListByTitleAsync(string title)
        {  
            var response = await _client.GetAsync($"Search/{_options.ApiKey}/{title}");

            var result = await CheckAndDeserialize<FilmListResponseDto>(response);

            var modelList = _mapper.Map<IEnumerable<ShortFilmModel>>(result.Results);

            return modelList;
        }

        private static async Task<T> CheckAndDeserialize<T>(HttpResponseMessage response) where T : BaseResponseDto
        {
            if (response.StatusCode != HttpStatusCode.OK)
                throw new BadRequestException("Something went wrong.");

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(content);

            if (!string.IsNullOrEmpty(result!.ErrorMessage))
                throw new BadRequestException(result.ErrorMessage);

            return result;
        }
    }
}
