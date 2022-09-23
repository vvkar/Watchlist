using Watchlist.Domain.Core.Exceptions.Base;

namespace Watchlist.Domain.Core.Exceptions
{
    public class BadRequestException : BaseException
    {
        public BadRequestException(string message) : base(message)
        {
        }
    }
}
