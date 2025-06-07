namespace Application.DTOs;

public record CreateOrderItemDto(Guid ProductId, int Quantity, decimal Price, decimal TotalPrice);