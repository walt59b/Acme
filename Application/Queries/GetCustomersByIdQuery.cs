using MediatR;
using AcmeCorp.Application.DTOs;
using Application.Interfaces;
using AutoMapper;

namespace AcmeCorp.Application.Customers.Queries;

public class GetCustomerByIdQuery : IRequest<CustomerDto>
{
    public int Id { get; set; }
}