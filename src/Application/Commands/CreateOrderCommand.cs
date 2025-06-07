using Application.DTOs;

namespace Application.Commands;

public record CreateOrderCommand(List<CreateOrderItemDto> Items);
