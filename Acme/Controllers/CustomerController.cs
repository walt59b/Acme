using Microsoft.AspNetCore.Mvc;
using MediatR;
using AcmeCorp.Application.Customers.Queries;
using AcmeCorp.Application.DTOs;
using AcmeCorp.Application.Customers.Commands;

namespace AcmeCorp.WebApi.Controllers;

[Route("api/customers")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly IMediator _mediator;

    public CustomerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerDto>>> GetAllCustomers()
    {
        var query = new GetAllCustomersQuery();
        var customers = await _mediator.Send(query);
        return Ok(customers);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerDto>> GetCustomerById(int id)
    {
        var query = new GetCustomerByIdQuery { Id = id };
        var customer = await _mediator.Send(query);

        if (customer == null)
        {
            return NotFound();
        }

        return Ok(customer);
    }

    [HttpPost]
    public async Task<ActionResult<CustomerDto>> CreateCustomer(CreateCustomerCommand command)
    {
        var customer = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetCustomerById), new { id = customer.Id }, customer);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCustomer(int id, UpdateCustomerCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await _mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomer(int id)
    {
        var command = new DeleteCustomerCommand { Id = id };
        await _mediator.Send(command);

        return NoContent();
    }
}
