using System.Linq.Expressions;
using Watchlist.Domain.Core.Models;

namespace Watchlist.Domain.Interfaces.Repositories
{
    public interface IWatchlistItemRepository
    {
        Task<IEnumerable<WatchlistItemModel>> GetAllAsync();
        Task<IEnumerable<WatchlistItemModel>> GetByUserId(Guid userId);
        Task<WatchlistItemModel> GetAsync(Guid userId, string itemId);
        Task<IEnumerable<Guid>> GetUsersAsync();
        Task<WatchlistItemModel> CreateAsync(WatchlistItemModel model);
        Task<WatchlistItemModel> UpdateFullAsync(WatchlistItemModel model);
        Task<IEnumerable<WatchlistItemModel>> GetUnwatchedListByUserId(Guid userId);
    }
}
