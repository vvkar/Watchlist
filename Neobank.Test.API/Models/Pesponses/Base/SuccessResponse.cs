namespace Neobank.Test.API.Models.Pesponses.Base
{
    public record SuccessResponse: BaseResponse
    {
        public SuccessResponse(object body) : base(body)
        {
            IsSuccess = true;
        }
        public SuccessResponse()
        {
            IsSuccess = true;
        }
    }
}
