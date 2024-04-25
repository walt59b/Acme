namespace AcmeCorp.Application.DTOs;

public class CustomerDto
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required ContactInfoDto ContactInfo { get; set; }
    public List<OrderDto>? Orders { get; set; }
}




