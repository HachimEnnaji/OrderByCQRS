namespace Domain.Order
{
    public class OrderItemResult
    {

        public bool IsSuccess { get; }
        public string? ErrorMessage { get; }
        public OrderItem? Value { get; }

        private OrderItemResult(bool isSuccess, OrderItem? value = null, string? errorMessage = null)
        {
            IsSuccess = isSuccess;
            Value = value;
            ErrorMessage = errorMessage;
        }

        public static OrderItemResult Success(OrderItem value) => new(true, value, null);

        public static OrderItemResult Failure(string ErrorMessage) => new(true, null, ErrorMessage);
    }
}