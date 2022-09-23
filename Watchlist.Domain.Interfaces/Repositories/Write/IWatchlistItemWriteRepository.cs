using Watchlist.Domain.Core.Models;

namespace Watchlist.Domain.Interfaces.Repositories.Write
{
    public interface IWatchlistItemWriteRepository
    {
        Task<WatchlistItemModel> CreateAsync(WatchlistItemModel model);
        Task<WatchlistItemModel> UpdateFullAsync(WatchlistItemModel model);
    }
}
