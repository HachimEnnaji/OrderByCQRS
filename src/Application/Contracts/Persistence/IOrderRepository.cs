using Domain.Order;

namespace Application.Contracts.Persistence;

public interface IOrderRepository
{
    void Add(Order order);
}
