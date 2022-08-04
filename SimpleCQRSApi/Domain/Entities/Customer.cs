using SimpleCQRSApi.Domain.Common;

namespace SimpleCQRSApi.Domain.Entities;

public class Customer : Entity
{
    public Customer(string email, string name)
    {
        Email = email;
        Name = name;
    }

    public string Email { get; }
    public string Name { get; }
}
