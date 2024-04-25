using MediatR;
using AcmeCorp.Application.DTOs;
using AcmeCorp.Application.Interfaces;

namespace AcmeCorp.Application.Orders.Commands;

public class CreateOrderCommand : IRequest<int>
{
    public required OrderDto Order { get; set; }
}

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
{
    private readonly IOrderRepository _orderRepository;

    public CreateOrderCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        return await _orderRepository.CreateAsync(request.Order);
    }
}   

