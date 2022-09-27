using Watchlist.Domain.Core.Exceptions.Base;

namespace Watchlist.Domain.Core.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException()
            :base("Nothing was found!")
        {
        }

        public NotFoundException(string message) : base(message)
        {
        }
    }
}
