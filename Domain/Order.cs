namespace AcmeCorp.Domain.Entities;

public class Order
{
    public required int Id { get; set; }
    public required int CustomerId { get; set; }
    public required Customer Customer { get; set; }
    public required DateTime OrderDate { get; set; }
    public required decimal TotalAmount { get; set; }
}