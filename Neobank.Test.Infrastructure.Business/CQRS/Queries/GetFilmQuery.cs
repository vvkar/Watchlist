using MediatR;
using Neobank.Test.Domain.Core.Models;
using Neobank.Test.Domain.Interfaces.Services;
using Neobank.Test.Infrastructure.Business.DTO;

namespace Neobank.Test.Infrastructure.Business.CQRS.Queries
{
    public record GetFilmQuery : IRequest<IEnumerable<ShortFilmModel>>
    {
        public string Title { get; init; }
        public GetFilmQuery(string title)
        {
            Title = title;
        }
    }

    public class GetFilmQueryHandler : IRequestHandler<GetFilmQuery, IEnumerable<ShortFilmModel>>
    {
        private readonly IFilmSearchService _filmSearchService;
        public GetFilmQueryHandler(IFilmSearchService filmSearchService)
        {
            _filmSearchService = filmSearchService;
        }
        public async Task<IEnumerable<ShortFilmModel>> Handle(GetFilmQuery request, CancellationToken cancellationToken)
        {
            var result = await _filmSearchService.GetFilmListByTitleAsync(request.Title);

            if (!result.Any())
                throw new Exception("no content");

            return result;
        }
    }
}
