namespace Neobank.Test.API.Models.Pesponses.Base
{
    public abstract record BaseResponse<T>
    {
        public bool IsSuccess { get; init; }
        public T? Body { get; init; }
    }
}
