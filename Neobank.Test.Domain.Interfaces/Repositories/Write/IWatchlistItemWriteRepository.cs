using Neobank.Test.Domain.Core.Models;

namespace Neobank.Test.Domain.Interfaces.Repositories.Write
{
    public interface IWatchlistItemWriteRepository
    {
        Task<WatchlistItemModel> CreateAsync(WatchlistItemModel model);
        Task<WatchlistItemModel> UpdateFullAsync(WatchlistItemModel model);
    }
}
