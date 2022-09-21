using Neobank.Test.Domain.Core.Exceptions.Base;

namespace Neobank.Test.Domain.Core.Exceptions
{
    public class BadRequestException : BaseException
    {
        public BadRequestException(string message) : base(message)
        {
        }
    }
}
