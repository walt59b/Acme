﻿namespace AcmeCorp.Domain.Entities;

public class ContactInfo
{
    public int Id { get; set; }
    public required string Email { get; set; }
    public required string Phone { get; set; }    
}