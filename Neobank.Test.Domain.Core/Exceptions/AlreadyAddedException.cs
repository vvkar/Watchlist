using Neobank.Test.Domain.Core.Exceptions.Base;

namespace Neobank.Test.Domain.Core.Exceptions
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
