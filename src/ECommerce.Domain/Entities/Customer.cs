using ECommerce.Domain.ValueObjects;

namespace ECommerce.Domain.Entities;
public class Customer
{
    public Guid Id { get; private set; }
    public required Email Email { get; set; }
    public required PersonName FirstName { get; set; }
    public required PersonName LastName { get; set; }
    public DateTime DateCreated { get; private set; }
    public DateTime Modified { get; private set; }
    public bool IsActive { get; set; }

    public Customer(Email email, PersonName firstName, PersonName lastName)
    {
        Id = Guid.NewGuid();
        Email = email ?? throw new ArgumentNullException(nameof(email));
        FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
        LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
        DateCreated = DateTime.UtcNow;
        IsActive = true;
    }

    public void UpdateEmail(Email newEmail)
    {
        if (newEmail == null) throw new ArgumentNullException(nameof(newEmail));
        Email = newEmail;
        Modified = DateTime.UtcNow;
    }

    public void Deactivate()
    {
        IsActive = false;
        Modified = DateTime.UtcNow;
    }
}