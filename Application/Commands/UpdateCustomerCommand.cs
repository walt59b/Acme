using MediatR;
using AcmeCorp.Application.DTOs;

namespace AcmeCorp.Application.Customers.Commands;

public class UpdateCustomerCommand : IRequest<CustomerDto>
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }    
}
