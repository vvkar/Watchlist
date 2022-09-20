namespace Neobank.Test.API.Models.Pesponses.Base
{
    public record ErrorResponse : BaseResponse
    {
        public ErrorResponse(object body) : base(body)
        {
            IsSuccess = false;
        }

        public ErrorResponse()
        {
            IsSuccess = false;
        }
    }
}
