using Application;
using Application.Contracts.Persistence;
using Domain.Order;

namespace Infrastructure;

public class OrderRepository(AppDbContext context) : IOrderRepository
{
    private readonly AppDbContext _context = context;
    public void Add(Order order)
    {
        _context.Orders.Add(order);
    }
}
