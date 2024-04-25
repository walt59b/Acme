using AcmeCorp.Application.DTOs;

namespace AcmeCorp.Application.Interfaces;

public interface IOrderRepository
{
    Task<OrderDto> GetByIdAsync(int orderId);
    Task<IEnumerable<OrderDto>> GetAllAsync();
    Task<int> CreateAsync(OrderDto orderDto);
    Task UpdateAsync(OrderDto orderDto);
    Task DeleteAsync(int orderId);
}