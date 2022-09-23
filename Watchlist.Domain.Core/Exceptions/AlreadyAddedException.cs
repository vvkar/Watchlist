using Watchlist.Domain.Core.Exceptions.Base;

namespace Watchlist.Domain.Core.Exceptions
{
    public class AlreadyAddedException : BaseException
    {
        public AlreadyAddedException()
            : base("Already added!")
        {
        }

        public AlreadyAddedException(string message)
            : base(message)
        {
        }
    }
}
