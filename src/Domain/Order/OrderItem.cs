namespace Domain.Order
{
    public record OrderItem
    {
        public Guid ProductId { get; }
        public int Quantity { get; }
        public decimal Price { get; }
        public decimal Total => Price * Quantity;

        private OrderItem(int quantity, decimal price)
        {
            ProductId = Guid.NewGuid();
            Quantity = quantity;
            Price = price;
        }

        public static OrderItemResult Create(int quantity, decimal price)
        {
            if (quantity <= 0)
            {
                return OrderItemResult.Failure("Quantity must be greater than zero.");
            }

            if (price <= 0)
            {
                return OrderItemResult.Failure("Price must be greater than zero.");
            }

            return OrderItemResult.Success(new OrderItem(quantity, price));
        }


    }
}