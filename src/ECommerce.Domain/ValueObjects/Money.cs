using ECommerce.Domain.Constants;

namespace ECommerce.Domain.ValueObjects;
public record Money
{
    public decimal Value { get; }
    public string Currency { get; }
    public Money(decimal value, string currency = MoneyConstants.DefaultCurrency)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException(nameof(value), "Price cannot be negative.");

        if (string.IsNullOrWhiteSpace(currency))
            throw new ArgumentException("Currency cannot be null or empty.", nameof(currency));

        if (currency.Length != 3)
            throw new ArgumentException("Currency must be a 3-letter ISO code.", nameof(currency));

        if (!MoneyConstants.SupportedCurrencies.Contains(currency.ToUpperInvariant()))
            throw new ArgumentException($"Currency '{currency}' is not supported.", nameof(currency));

        if (value < MoneyConstants.MinValue || value > MoneyConstants.MaxValue)
            throw new ArgumentOutOfRangeException(nameof(value), $"Price must be between {MoneyConstants.MinValue} and {MoneyConstants.MaxValue}.");

        Value = value;
        Currency = currency;
    }

    public Money Add(Money other)
    {
        if (other == null) throw new ArgumentNullException(nameof(other));
        if (Currency != other.Currency)
            throw new InvalidOperationException("Cannot add prices with different currencies.");
        return new Money(Value + other.Value, Currency);
    }

    public static implicit operator decimal(Money price) => price.Value;
    public static implicit operator Money((decimal value, string currency) money) => new Money(money.value, money.currency ?? MoneyConstants.DefaultCurrency);
};
