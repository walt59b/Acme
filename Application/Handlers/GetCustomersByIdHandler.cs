using AcmeCorp.Application.Customers.Queries;
using AcmeCorp.Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace AcmeCorp.Application.Customers.Handlers;

public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDto>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public GetCustomerByIdQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<CustomerDto> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByIdAsync(request.Id);

        return _mapper.Map<CustomerDto>(customer);
    }
}
