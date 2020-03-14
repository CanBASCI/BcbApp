
namespace Core.Utilities.Results.Impl
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult() : base(default, true)
        {

        }
        public SuccessDataResult(string message) : base(default, true, message)
        {

        }
        public SuccessDataResult(T data) : base(data, true)
        {

        }

        public SuccessDataResult(T data, bool isSuccess, string message) : base(data, true, message)
        {

        }
    }
}
