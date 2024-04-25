using AcmeCorp.Domain.Entities;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AcmeCorp.Infrastructure.Persistence.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly ApplicationDbContext _context;

    public CustomerRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        return await _context.Customers
            .Include(c => c.ContactInfo)
            .ToListAsync();
    }

    public async Task<Customer> GetByIdAsync(int id)
    {
        return await _context.Customers
            .Include(c => c.ContactInfo)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Customer> CreateAsync(Customer customer)
    {
        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();
        return customer;
    }

    public async Task<Customer> UpdateAsync(Customer customer)
    {
        _context.Customers.Update(customer);
        await _context.SaveChangesAsync();
        return customer;
    }

    public async Task DeleteAsync(int id)
    {
        var customerToDelete = await _context.Customers.FindAsync(id);
        if (customerToDelete != null)
        {
            _context.Customers.Remove(customerToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
