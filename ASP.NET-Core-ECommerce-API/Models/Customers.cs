namespace ASP.NET_Core_ECommerce_API.Models;

public class Customers
{
    public int CustomerId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? Phone { get; set; }
    public string PasswordHash { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public bool IsActive { get; set; }

    public ICollection<Orders> Orders { get; set; } = new List<Orders>();
    public ICollection<Addresses> Addresses { get; set; } = new List<Addresses>();
    public Carts? Cart { get; set; }
    public ICollection<Reviews> Reviews { get; set; } = new List<Reviews>();
}