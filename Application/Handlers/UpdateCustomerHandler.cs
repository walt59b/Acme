using AcmeCorp.Application.Customers.Commands;
using AcmeCorp.Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace AcmeCorp.Application.Customers.Handlers;

public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, CustomerDto>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public UpdateCustomerHandler(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<CustomerDto> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var existingCustomer = await _customerRepository.GetByIdAsync(request.Id);

        if (existingCustomer == null)
        {
            throw new Exception($"nameof(Customer)_{request.Id}");
        }

        if (request.Name != null)
        {
            existingCustomer.Name = request.Name;
        }

        if (request.Email != null)
        {
            existingCustomer.ContactInfo.Email = request.Email;
        }

        if (request.Phone != null)
        {
            existingCustomer.ContactInfo.Phone = request.Phone;
        }


        await _customerRepository.UpdateAsync(existingCustomer);
        return _mapper.Map<CustomerDto>(existingCustomer);
    }
}
