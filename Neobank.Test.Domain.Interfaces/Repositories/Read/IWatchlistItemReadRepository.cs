using Neobank.Test.Domain.Core.Models;

namespace Neobank.Test.Domain.Interfaces.Repositories.Read
{
    public interface IWatchlistItemReadRepository
    {
        Task<WatchlistItemModel> GetAsync(Guid watchlistId, string itemId);
    }
}