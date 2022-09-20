namespace Neobank.Test.API.Models.Pesponses.Base
{
    public record ErrorResponse : BaseResponse
    {
        public ErrorResponse(object body = null) : base(body)
        {
            IsSuccess = false;
        }
    }
}
