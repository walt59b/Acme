using AcmeCorp.Application.DTOs;
using AcmeCorp.Application.Interfaces;
using AcmeCorp.Application.Orders.Queries;
using MediatR;

namespace AcmeCorp.Application.Orders.Handlers;

public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderDto>
{
    private readonly IOrderRepository _orderRepository;

    public GetOrderByIdQueryHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<OrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        return await _orderRepository.GetByIdAsync(request.OrderId);
    }
}