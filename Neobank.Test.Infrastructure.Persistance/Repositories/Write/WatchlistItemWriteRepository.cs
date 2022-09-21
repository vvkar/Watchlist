using AutoMapper;
using Microsoft.Extensions.Logging;
using Neobank.Test.Domain.Core.Models;
using Neobank.Test.Domain.Interfaces.Repositories.Write;
using Neobank.Test.Infrastructure.Persistance.Entities;
using Neobank.Test.Infrastructure.Persistance.Repositories.Base;

namespace Neobank.Test.Infrastructure.Persistance.Repositories.Write
{
    public class WatchlistItemWriteRepository
        : BaseWriteRepository<WatchlistItemModel, WatchlistItemEntity>, IWatchlistItemWriteRepository
    {
        public WatchlistItemWriteRepository(IMapper mapper, AppDbContext context, ILogger logger) 
            : base(mapper, context, logger)
        {
        }
    }
}
