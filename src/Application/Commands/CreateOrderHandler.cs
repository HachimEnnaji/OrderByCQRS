using Application.Contracts.Persistence;
using Domain.Order;

namespace Application.Commands;

public class CreateOrderHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
{
    private readonly IOrderRepository _orderRepository = orderRepository;

    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Guid> Handle(CreateOrderCommand command)
    {
        var order = new Order();

        foreach (var item in command.Items)
        {
            var result = OrderItem.Create(item.ProductId, item.Quantity, item.Price);
            if (result.IsSuccess && result.Value is not null)
            {
                order.AddItem(result.Value);
            }
            else
            {
                throw new Exception(result.ErrorMessage);
            }

        }
        _orderRepository.Add(order);
        await _unitOfWork.SaveChangesAsync();
        return order.Id;
    }
}
