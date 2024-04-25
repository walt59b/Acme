using AcmeCorp.Domain.Entities;
using Application.Interfaces;
using MediatR;

namespace AcmeCorp.Application.Customers.Commands;

public class DeleteCustomerCommand : IRequest
{
    public int Id { get; set; }
}

public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
{
    private readonly ICustomerRepository _customerRepository;

    public DeleteCustomerCommandHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var existingCustomer = await _customerRepository.GetByIdAsync(request.Id);

        if (existingCustomer == null)
        {
            throw new Exception($"nameof(Customer)_{request.Id}");
        }

        await _customerRepository.DeleteAsync(request.Id);
    }
}
