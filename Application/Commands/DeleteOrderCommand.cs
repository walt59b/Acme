using AcmeCorp.Application.Interfaces;
using MediatR;

namespace AcmeCorp.Application.Orders.Commands;

public class DeleteOrderCommand : IRequest
{
    public int OrderId { get; set; }
}

public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
{
    private readonly IOrderRepository _orderRepository;

    public DeleteOrderCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        await _orderRepository.DeleteAsync(request.OrderId);        
    }
}
