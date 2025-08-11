namespace ECommerce.Domain.Constants;
public class MoneyConstants
{
    public const string DefaultCurrency = "USD";
    public const decimal MinValue = 0.00m;
    public const decimal MaxValue = 1_000_000_000.00m;
    public const int DecimalPlaces = 2;
    public static readonly string[] SupportedCurrencies = { "USD", "EUR", "PHP", "SGD", "AUD" };
}
