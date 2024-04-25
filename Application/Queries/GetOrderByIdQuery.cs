using AcmeCorp.Application.DTOs;
using AcmeCorp.Application.Interfaces;
using MediatR;

namespace AcmeCorp.Application.Orders.Queries;

public class GetOrderByIdQuery : IRequest<OrderDto>
{
    public int OrderId { get; set; }
}