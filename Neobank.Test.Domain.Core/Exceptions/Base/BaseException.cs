namespace Neobank.Test.Domain.Core.Exceptions.Base
{
    public abstract class BaseException : Exception
    {
        public BaseException(string message) : base(message)
        {
        }
    }
}
