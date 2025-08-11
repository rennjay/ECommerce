using ECommerce.Domain.ValueObjects;

namespace ECommerce.Domain.Entities;

public class Product
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required Price Price { get; set; }
    public int StockQuantity { get; set; }
    public Guid CategoryId { get; set; }
    public DateTime DateCreated { get; set; }
    public bool IsActive { get; set; }
}
