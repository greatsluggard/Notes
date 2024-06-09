namespace Notes.Domain.Result
{
    public class BaseResult
    {
        public bool IsSuccess => ErrorMessage == null;
        public string ErrorMessage { get; set; }
        public int? ErrorCode { get; set; }
    }

    public class BaseResult<T> : BaseResult
    {
        public T Data { get; set; }
        public BaseResult(int errorCode, string errorMessage, T data)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
            Data = data;
        }

        public BaseResult()
        {
            
        }
    }
}