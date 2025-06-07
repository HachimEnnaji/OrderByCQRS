using Domain.BaseEntity;

namespace Domain.Order;

public class Order : Entity
{
    private readonly List<OrderItem> _items = [];
    public IReadOnlyCollection<OrderItem> Items => _items;

    public void AddItem(OrderItem item)
    {
        ArgumentNullException.ThrowIfNull(item);
        ArgumentNullException.ThrowIfNull(item.Quantity);

        _items.Add(item);
    }
}
