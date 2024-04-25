using MediatR;
using Microsoft.AspNetCore.Mvc;
using AcmeCorp.Application.Orders.Commands;
using AcmeCorp.Application.Orders.Queries;
using AcmeCorp.Application.DTOs;

namespace AcmeCorp.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrderController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OrderDto>> GetOrderById(int id)
    {
        var query = new GetOrderByIdQuery { OrderId = id };
        var result = await _mediator.Send(query);
        if (result == null)
            return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<int>> CreateOrder(OrderDto order)
    {
        var command = new CreateOrderCommand { Order = order };
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetOrderById), new { id = result }, null);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateOrder(int id, OrderDto order)
    {
        if (id != order.Id)
            return BadRequest();

        var command = new UpdateOrderCommand { Order = order };
        await _mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrder(int id)
    {
        var command = new DeleteOrderCommand { OrderId = id };
        await _mediator.Send(command);

        return NoContent();
    }
}
