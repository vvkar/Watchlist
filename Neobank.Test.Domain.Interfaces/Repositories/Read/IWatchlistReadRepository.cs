using Neobank.Test.Domain.Core.Models;

namespace Neobank.Test.Domain.Interfaces.Repositories.Read
{
    public interface IWatchlistReadRepository
    {
        Task<WatchlistModel> GetAsync(Guid Id);
    }
}