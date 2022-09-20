using MediatR;
using Neobank.Test.Domain.Core.DTO;
using Neobank.Test.Domain.Interfaces.Services;

namespace Neobank.Test.Infrastructure.Business.CQRS.Queries
{
    public record GetFilmQuery : IRequest<IEnumerable<FilmDto>>
    {
        public string Title { get; init; }
        public GetFilmQuery(string title)
        {
            Title = title;
        }
    }

    public class GetFilmQueryHandler : IRequestHandler<GetFilmQuery, IEnumerable<FilmDto>>
    {
        private readonly IFilmSearchService _filmSearchService;
        public GetFilmQueryHandler(IFilmSearchService filmSearchService)
        {
            _filmSearchService = filmSearchService;
        }
        public async Task<IEnumerable<FilmDto>> Handle(GetFilmQuery request, CancellationToken cancellationToken)
        {
            var result = await _filmSearchService.GetFilmByNameAsync(request.Title);

            if (!result.Any())
                throw new Exception("no content");

            return result;
        }
    }
}
