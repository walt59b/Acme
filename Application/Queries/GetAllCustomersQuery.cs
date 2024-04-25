using AcmeCorp.Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace AcmeCorp.Application.Customers.Queries;

public class GetAllCustomersQuery : IRequest<IEnumerable<CustomerDto>>
{

}
