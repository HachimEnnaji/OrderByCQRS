using Domain.BaseEntity;

namespace Domain.Order;

public class Order : Entity
{
    private readonly List<OrderItem> _items = [];
    public IReadOnlyCollection<OrderItem> Items => _items;
}
