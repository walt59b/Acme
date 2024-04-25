using AcmeCorp.Application.Customers.Commands;
using AcmeCorp.Application.DTOs;
using AcmeCorp.Domain.Entities;
using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace AcmeCorp.Application.Customers.Handlers;

public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, CustomerDto>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public CreateCustomerHandler(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<CustomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = new Customer
        {
            Name = request.Name,
            ContactInfo = new ContactInfo { Email = request.Email, Phone = request.Phone }
        };

        await _customerRepository.CreateAsync(customer);
        return _mapper.Map<CustomerDto>(customer);
    }
}
