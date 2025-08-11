using System.Data.SqlTypes;

namespace ECommerce.Domain.ValueObjects;
public record Price
{
    public decimal Value { get; }
    public string Currency { get; }
    public Price(decimal value, string currency)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException(nameof(value), "Price cannot be negative.");

        if (string.IsNullOrWhiteSpace(currency))
            throw new ArgumentException("Currency cannot be null or empty.", nameof(currency));

        if (currency.Length != 3)
            throw new ArgumentException("Currency must be a 3-letter ISO code.", nameof(currency));

        Value = value;
        Currency = currency;
    }

    public Price Add(Price other)
    {
        if (other == null) throw new ArgumentNullException(nameof(other));
        if (Currency != other.Currency)
            throw new InvalidOperationException("Cannot add prices with different currencies.");
        return new Price(Value + other.Value, Currency);
    }

    public static implicit operator decimal(Price price) => price.Value;
    public static implicit operator Price((decimal value, string currency) money) => new Price(money.value, money.currency);
};
