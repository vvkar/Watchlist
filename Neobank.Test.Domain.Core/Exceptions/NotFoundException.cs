using Neobank.Test.Domain.Core.Exceptions.Base;

namespace Neobank.Test.Domain.Core.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
