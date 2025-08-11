namespace ECommerce.Domain.ValueObjects;
public record PersonName
{
    public string Value { get; }

    public PersonName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Person name cannot be null, empty, or whitespace.", nameof(value));

        if (value.Length < 1)
            throw new ArgumentException("Person name must be at least 1 character long.", nameof(value));

        if (value.Length > 50)
            throw new ArgumentException("Person name cannot exceed 50 characters.", nameof(value));

        if (ContainsInvalidCharacters(value))
            throw new ArgumentException("Person name contains invalid characters.", nameof(value));

        Value = value.Trim();
    }

    private static bool ContainsInvalidCharacters(string name)
    {
        foreach (char c in name)
        {
            if (!char.IsLetter(c) && c != ' ' && c != '-' && c != '\'' && c != '.')
                return true;
        }
        return false;
    }

    public static implicit operator string(PersonName personName) => personName.Value;
    public static implicit operator PersonName(string value) => new(value);

    public override string ToString() => Value;
}