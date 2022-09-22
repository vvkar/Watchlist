using Neobank.Test.Domain.Core.Models;

namespace Neobank.Test.Domain.Interfaces.Repositories.Read
{
    public interface IWatchlistItemReadRepository
    {
        Task<IEnumerable<WatchlistItemModel>> GetAllAsync();
        Task<IEnumerable<WatchlistItemModel>> GetByUserId(Guid userId);
        Task<WatchlistItemModel> GetAsync(Guid userId, string itemId);
    }
}