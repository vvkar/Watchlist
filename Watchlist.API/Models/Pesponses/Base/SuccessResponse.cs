namespace Watchlist.API.Models.Pesponses.Base
{
    public record SuccessResponse<T> : BaseResponse<T>
    {
        public SuccessResponse()
        {
            IsSuccess = true;
        }
    }
}
