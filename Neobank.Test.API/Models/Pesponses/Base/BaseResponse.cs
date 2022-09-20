namespace Neobank.Test.API.Models.Pesponses.Base
{
    public abstract record BaseResponse
    {
        public BaseResponse()
        {

        }

        public BaseResponse(object body)
        {
            Body = body;
        }

        public bool IsSuccess { get; init; }
        public object Body { get; init; }
    }
}
