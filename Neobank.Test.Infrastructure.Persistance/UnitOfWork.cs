using AutoMapper;
using Microsoft.Extensions.Logging;
using Neobank.Test.Domain.Interfaces.Repositories.Write;

namespace Neobank.Test.Infrastructure.Persistance
{
    public class UnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly ILogger<UnitOfWork> _logger;
        private readonly IMapper _mapper;
        private readonly Lazy<IWatchlistWriteRepository> _writeVerificationRepository;
        private readonly Lazy<IWatchlistItemWriteRepository> _writeUserRepository;

        public UnitOfWork(AppDbContext context, ILogger<UnitOfWork> logger, IMapper mapper)
        {

        }

        //UNDONE: fill UoW
    }
}
