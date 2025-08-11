using ECommerce.Domain.ValueObjects;
namespace ECommerce.Domain.Entities;
public class OrderItem
{
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public required Money UnitPrice { get; set; }
    public required Money TotalPrice { get; init; }

    public OrderItem(Guid orderId, Guid productId, int quantity, Money unitPrice)
    {
        if (quantity <= 0)
            throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be greater than zero.");
        
        if (unitPrice == null)
            throw new ArgumentNullException(nameof(unitPrice), "Unit price cannot be null.");
        
        if (unitPrice.Value <= 0)
            throw new ArgumentOutOfRangeException(nameof(unitPrice), "Unit price must be greater than zero.");
       
        if (unitPrice.Currency == null)
            throw new ArgumentNullException(nameof(unitPrice), "Unit price currency cannot be null.");

        Id = Guid.NewGuid();
        OrderId = orderId;
        ProductId = productId;
        Quantity = quantity;
        UnitPrice = unitPrice;
        TotalPrice = (unitPrice.Value * quantity,unitPrice.Currency);
    }
}
