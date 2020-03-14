
namespace Core.Utilities.Results.Impl
{
    public class Result : IResult
    {
        public bool IsSuccess { get; }
        public string Message { get; }
        public Result(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }
        public Result(bool isSuccess, string message) : this(isSuccess)
        {
            Message = message;
        }
    }
}
