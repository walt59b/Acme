namespace AcmeCorp.Domain.Entities;

public class Customer
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required ContactInfo ContactInfo { get; set; }
    public List<Order>? Orders { get; set; }
}

