using AcmeCorp.Application.DTOs;
using AcmeCorp.Application.Interfaces;
using MediatR;

namespace AcmeCorp.Application.Orders.Commands;

public class UpdateOrderCommand : IRequest
{
    public required OrderDto Order { get; set; }
}

public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
{
    private readonly IOrderRepository _orderRepository;

    public UpdateOrderCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        await _orderRepository.UpdateAsync(request.Order);        
    }
}