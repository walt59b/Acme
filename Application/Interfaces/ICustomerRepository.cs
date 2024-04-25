using AcmeCorp.Domain.Entities;

namespace Application.Interfaces;
  
public interface ICustomerRepository
{
    Task<Customer> GetByIdAsync(int id);
    Task<IEnumerable<Customer>> GetAllAsync();
    Task<Customer> CreateAsync(Customer customer);
    Task<Customer> UpdateAsync(Customer customer);
    Task DeleteAsync(int id);
}            

