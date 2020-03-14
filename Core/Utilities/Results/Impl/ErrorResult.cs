
namespace Core.Utilities.Results.Impl
{
    public class ErrorResult : Result
    {
        public ErrorResult(bool isSuccess) : base(false)
        {
        }

        public ErrorResult(bool isSuccess, string message) : base(false, message)
        {
        }
    }
}
