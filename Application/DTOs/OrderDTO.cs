namespace AcmeCorp.Application.DTOs;

public class OrderDto
{
    public required int Id { get; set; }
    public required int CustomerId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
}