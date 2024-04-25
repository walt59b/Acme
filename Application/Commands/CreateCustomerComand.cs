using AcmeCorp.Domain.Entities;
using AcmeCorp.Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace AcmeCorp.Application.Customers.Commands;

public class CreateCustomerCommand : IRequest<CustomerDto>
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Phone { get; set; }        
}
