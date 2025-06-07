namespace Domain.Order
{
    public class Result<T>
    {

        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public string? ErrorMessage { get; }
        public T? Value { get; }

        private Result(bool isSuccess, T? value, string? errorMessage = null)
        {
            IsSuccess = isSuccess;
            Value = value;
            ErrorMessage = errorMessage;
        }

        public static Result<T> Success(T value) => value is not null
            ? new Result<T>(true, value, null)
            : throw new ArgumentNullException(nameof(value), "Value cannot be null.");

        public static Result<T> Failure(string ErrorMessage) => new(false, default, ErrorMessage);
    }
}