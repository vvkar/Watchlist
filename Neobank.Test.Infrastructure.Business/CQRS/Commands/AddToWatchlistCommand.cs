using MediatR;

namespace Neobank.Test.Infrastructure.Business.CQRS.Commands
{
    public record AddToWatchlistCommand : IRequest<bool>
    {
        public Guid UserId { get; init; }
        public string FilmId { get; init; }
        public AddToWatchlistCommand(Guid userId, string filmId)
        {
            UserId = userId;
            FilmId = filmId;
        }
    }

    public class AddToWatchlistCommandHandler : IRequestHandler<AddToWatchlistCommand, bool>
    {
        public AddToWatchlistCommandHandler()
        {

        }
        public Task<bool> Handle(AddToWatchlistCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
