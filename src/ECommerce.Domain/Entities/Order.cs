using ECommerce.Domain.Enums;
using ECommerce.Domain.ValueObjects;

namespace ECommerce.Domain.Entities;
public class Order
{
    public Guid Id { get; init; }
    public Guid CustomerId { get; set; }
    public DateTime OrderDate { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public Money TotalAmount { get; } = (0.00m, "USD");
    public Address ShippingAddress { get; set; }


}
