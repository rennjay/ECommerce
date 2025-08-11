namespace ECommerce.Domain.Enums;
public enum OrderStatus
{
    Draft = 0,
    Pending = 1,
    Confirmed = 2,
    Processing = 3,
    Shipped = 4,
    Delivered = 5,
    Cancelled = 6,
    Refunded = 7,
    Failed = 8
}
