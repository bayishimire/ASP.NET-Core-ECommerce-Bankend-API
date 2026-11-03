namespace ASP.NET_Core_ECommerce_API.Models;

public class Addresses
{
    public int AddressId { get; set; }
    public int CustomerId { get; set; }
    public string AddressLine { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string? PostalCode { get; set; }
    public bool IsDefault { get; set; }

    public Customers? Customer { get; set; }
}
