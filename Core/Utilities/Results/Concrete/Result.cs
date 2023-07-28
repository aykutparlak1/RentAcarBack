using Core.Utilities.Results.Abstract;

namespace Core.Utilities.Results.Concrete
{
    public class Result : IResult
    {

        public Result(bool isSuccess, string message):this(isSuccess)
        {
                IsSuccess = isSuccess;
                Message = message;
        }
        public Result(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }
        public bool IsSuccess { get; }

        public string Message { get; }
    }
}
