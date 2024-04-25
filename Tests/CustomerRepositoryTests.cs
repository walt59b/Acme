using AcmeCorp.Domain.Entities;
using AcmeCorp.Infrastructure.Persistence;
using AcmeCorp.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AcmeCorp.Infrastructure.Tests.Persistence.Repositories;

public class CustomerRepositoryTests
{
    [Fact]
    public async Task GetAllAsync_ReturnsAllCustomers()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        using var context = new ApplicationDbContext(options);
        var repository = new CustomerRepository(context);

        var customers = new List<Customer>
        {
            new Customer { Name = "Customer 1", ContactInfo = new ContactInfo { Email = "email1@example.com", Phone = "1234567890" } },
            new Customer { Name = "Customer 2", ContactInfo = new ContactInfo { Email = "email2@example.com", Phone = "0987654321" } }
        };
        await context.Customers.AddRangeAsync(customers);
        await context.SaveChangesAsync();

        // Act
        var result = await repository.GetAllAsync();

        // Assert
        Assert.Equal(customers.Count, result.Count());
    }

    [Fact]
    public async Task GetByIdAsync_ReturnsCorrectCustomer()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        using var context = new ApplicationDbContext(options);
        var repository = new CustomerRepository(context);

        var customer = new Customer { Name = "Customer", ContactInfo = new ContactInfo { Email = "email@example.com", Phone = "1234567890" } };
        await context.Customers.AddAsync(customer);
        await context.SaveChangesAsync();

        // Act
        var result = await repository.GetByIdAsync(customer.Id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(customer.Name, result.Name);
        Assert.Equal(customer.ContactInfo.Email, result.ContactInfo.Email);
        Assert.Equal(customer.ContactInfo.Phone, result.ContactInfo.Phone);
    }
}
