using System.Threading;
using System.Threading.Tasks;
using AcmeCorp.Application.Customers.Commands;
using AcmeCorp.Application.Customers.Handlers;
using AcmeCorp.Application.DTOs;
using AcmeCorp.Domain.Entities;
using Application.Interfaces;
using AutoMapper;
using Moq;
using Xunit;

namespace AcmeCorp.Application.Tests.Customers.Handlers
{
    public class CreateCustomerHandlerTests
    {
        [Fact]
        public async Task Handle_ValidRequest_ReturnsCustomerDto()
        {
            // Arrange
            var command = new CreateCustomerCommand
            {
                Name = "John Doe",
                Email = "john.doe@example.com",
                Phone = "1234567890"
            };

            var mockRepository = new Mock<ICustomerRepository>();
            mockRepository.Setup(repo => repo.CreateAsync(It.IsAny<Customer>()))
                .ReturnsAsync(new Customer { ContactInfo = new ContactInfo { Email = "john.doe@example.com", Phone = "1234567890" }, Name = "John Doe" });

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Customer, CustomerDto>();
            });
            IMapper mapper = mapperConfig.CreateMapper();

            var handler = new CreateCustomerHandler(mockRepository.Object, mapper);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<CustomerDto>(result);
            Assert.Equal(command.Name, result.Name);
            Assert.Equal(command.Email, result.ContactInfo.Email);
            Assert.Equal(command.Phone, result.ContactInfo.Phone);
        }
    }
}
