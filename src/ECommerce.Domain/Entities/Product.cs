using ECommerce.Domain.ValueObjects;

namespace ECommerce.Domain.Entities;

public class Product
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required Money Price { get; set; }
    public int StockQuantity { get; set; }
    public Guid CategoryId { get; set; }
    public DateTime DateCreated { get; set; }
    public bool IsActive { get; set; }

    public Product(string name, string description, Money price, int stockQuantity, Guid categoryId)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Product name cannot be empty.", nameof(name));
        
        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Product description cannot be empty.", nameof(description));
        
        if (price == null)
            throw new ArgumentNullException(nameof(price), "Price cannot be null.");
        
        if (price.Value <= 0)
            throw new ArgumentOutOfRangeException(nameof(price), "Price must be greater than zero.");
        
        if (price.Currency == null)
            throw new ArgumentNullException(nameof(price), "Price currency cannot be null.");
        
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        Price = price;
        StockQuantity = stockQuantity;
        CategoryId = categoryId;
        DateCreated = DateTime.UtcNow;
        IsActive = true;
    }
}
