using AutoMapper;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net;
using Watchlist.Domain.Core.Exceptions;
using Watchlist.Domain.Core.Models;
using Watchlist.Domain.Core.Options;
using Watchlist.Domain.Interfaces.Services;
using Watchlist.Infrastructure.Business.DTO;
using Watchlist.Infrastructure.Business.DTO.Base;
using Watchlist.Infrastructure.Business.Extensions;

namespace Watchlist.Infrastructure.Business.Services
{
    public class ImdbSearchService : IFilmSearchService
    {
        private readonly IMapper _mapper;
        private readonly HttpClient _client;
        private readonly FilmSearchServiceOptions _options;
        private const string Title = "Title";
        private const string Posters = "Posters";
        private const string Wikipedia = "Wikipedia";
        private const string Search = "Search";


        public ImdbSearchService(IMapper mapper, 
                                 HttpClient client, 
                                 IOptionsSnapshot<FilmSearchServiceOptions> namedOptions)
        {
            _mapper = mapper;
            _client = client;
            _options = namedOptions.Get(FilmSearchServiceOptions.IMDB);
            _client.BaseAddress = new Uri(_options.BaseUri);
        }

        public async Task<FilmEmailModel> GetFilmEmailModelByIdAsync(string filmId)
        {
            var filmTask = GetFilmByIdAsync(filmId);
            var posterTask = GetPosterByIdAsync(filmId);
            var wikiTask = GetWikiByIdAsync(filmId);

            await Task.WhenAll(filmTask, posterTask, wikiTask);

            var model = new FilmEmailModel()
            {
                Film = filmTask.Result,
                Poster = posterTask.Result,
                Wiki = wikiTask.Result,
            };

            return model;
        }

        public async Task<FullFilmModel> GetFilmByIdAsync(string filmId)
        {
            var response = await _client.GetAsync(method: Title, _options.ApiKey, filmId);

            var result = await CheckAndDeserialize<FullFilmResponseDto>(response);

            var model = _mapper.Map<FullFilmModel>(result);

            return model;
        }

        public async Task<PosterModel> GetPosterByIdAsync(string filmId)
        {
            var response = await _client.GetAsync(method: Posters, _options.ApiKey, filmId);

            var result = await CheckAndDeserialize<PostersResponseDto>(response);

            var model = _mapper.Map<PosterModel>(result.Posters.FirstOrDefault());

            return model;
        }

        public async Task<WikiModel> GetWikiByIdAsync(string filmId)
        {
            var response = await _client.GetAsync(method: Wikipedia, _options.ApiKey, filmId);

            var result = await CheckAndDeserialize<WikiResponseDto>(response);

            var model = _mapper.Map<WikiModel>(result.Result);

            return model;
        }

        public async Task<IEnumerable<ShortFilmModel>> GetFilmListByTitleAsync(string title)
        {
            var response = await _client.GetAsync(method: Search, _options.ApiKey, title);

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
