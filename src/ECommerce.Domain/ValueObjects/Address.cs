using ECommerce.Domain.Enums;

namespace ECommerce.Domain.ValueObjects;
public record Address
{
    public string Street1 { get; private set; }
    public string Street2 { get; private set; }
    public string City { get; private set; }
    public string StateProvince { get; private set; }
    public string PostalCode { get; private set; }
    public string Country { get; private set; }
    public AddressType Type { get; private set; }

    public Address(string street1, string city, string stateProvince,
                  string postalCode, string country, AddressType type,
                  string street2 = null)
    {
        if (string.IsNullOrWhiteSpace(street1))
            throw new ArgumentException("Street address is required");
        if (string.IsNullOrWhiteSpace(city))
            throw new ArgumentException("City is required");
        if (string.IsNullOrWhiteSpace(country))
            throw new ArgumentException("Country is required");

        Street1 = street1;
        Street2 = street2;
        City = city;
        StateProvince = stateProvince;
        PostalCode = postalCode;
        Country = country;
        Type = type;
    }

    public override string ToString()
    {
        var parts = new List<string> { Street1 };
        if (!string.IsNullOrWhiteSpace(Street2)) parts.Add(Street2);
        parts.Add(City);
        if (!string.IsNullOrWhiteSpace(StateProvince)) parts.Add(StateProvince);
        if (!string.IsNullOrWhiteSpace(PostalCode)) parts.Add(PostalCode);
        parts.Add(Country);

        return string.Join(", ", parts);
    }
}
