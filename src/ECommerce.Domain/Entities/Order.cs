using ECommerce.Domain.Constants;
using ECommerce.Domain.Enums;
using ECommerce.Domain.ValueObjects;

namespace ECommerce.Domain.Entities;
public class Order
{
    public Guid Id { get; init; }
    public Guid CustomerId { get; init; }
    public DateTime OrderDate { get; init; }
    public OrderStatus OrderStatus { get; set; }
    public Money TotalAmount { get; init; }
    public Address ShippingAddress { get; set; }
    public List<OrderItem> OrderItems { get; set; }

    public Order(Guid customerId, DateTime orderDate, OrderStatus orderStatus, Address shippingAddress, List<OrderItem> orderItems)
    {
        if (customerId == Guid.Empty)
            throw new ArgumentException("Customer ID cannot be empty.", nameof(customerId));

        if (orderDate == default)
            throw new ArgumentException("Order date cannot be default.", nameof(orderDate));

        if (shippingAddress == null)
            throw new ArgumentNullException(nameof(shippingAddress), "Shipping address cannot be null.");
        
        if (orderItems.Any(item => item.UnitPrice == null || item.UnitPrice.Value <= 0 || item.UnitPrice.Currency == null))
            throw new ArgumentException("Order items must have a valid unit price with a value greater than zero and a valid currency.", nameof(orderItems));


        Id = Guid.NewGuid();
        CustomerId = customerId;
        OrderDate = orderDate;
        OrderStatus = orderStatus;
        ShippingAddress = shippingAddress;
        OrderItems = orderItems;
        TotalAmount = CalculateTotalAmount(orderItems);
    }

    private Money CalculateTotalAmount(List<OrderItem> orderItems)
    {
        var total = orderItems.Count > 0 ? orderItems.Sum(item => item.TotalPrice) : 0.00m;
        var currency = orderItems.Count > 0 ? orderItems.First().TotalPrice.Currency : MoneyConstants.DefaultCurrency;
        return (total, currency);
    }
}
