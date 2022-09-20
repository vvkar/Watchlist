namespace Neobank.Test.API.Models.Pesponses.Base
{
    public record SuccessResponse: BaseResponse
    {
        public SuccessResponse(object body = null) : base(body)
        {
            IsSuccess = true;
        }
    }
}
