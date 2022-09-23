using Watchlist.Domain.Core.Exceptions.Base;

namespace Watchlist.Domain.Core.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
