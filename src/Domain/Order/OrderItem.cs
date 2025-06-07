namespace Domain.Order
{
    public record OrderItem
    {
        public Guid Id { get; }
        public Guid ProductId { get; }
        public int Quantity { get; }
        public decimal Price { get; }
        public decimal Total => Price * Quantity;

        private OrderItem(Guid productId, int quantity, decimal price)
        {
            Id = Guid.NewGuid();
            ProductId = productId;
            Quantity = quantity;
            Price = price;
        }

        public static Result<OrderItem> Create(Guid productId, int quantity, decimal price)
        {
            if (productId == Guid.Empty)
            {
                return Result<OrderItem>.Failure("ProductId not valid");
            }
            if (quantity <= 0)
            {
                return Result<OrderItem>.Failure("Quantity must be greater than zero.");
            }

            if (price <= 0)
            {
                return Result<OrderItem>.Failure("Price must be greater than zero.");
            }

            return Result<OrderItem>.Success(new OrderItem(productId, quantity, price));
        }


    }
}