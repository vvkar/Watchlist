namespace Neobank.Test.API.Models.Pesponses.Base
{
    public record ErrorResponse<T> : BaseResponse<T>
    {
        public ErrorResponse()
        {
            IsSuccess = false;
        }
        public string Message { get; init; }
    }
}
