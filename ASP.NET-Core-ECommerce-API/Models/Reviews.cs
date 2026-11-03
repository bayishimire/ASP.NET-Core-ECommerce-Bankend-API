namespace ASP.NET_Core_ECommerce_API.Models;

public class Reviews
{
    public int ReviewId { get; set; }
    public int CustomerId { get; set; }
    public int ProductId { get; set; }
    public int Rating { get; set; }
    public string? Comment { get; set; }
    public DateTime ReviewDate { get; set; }

    public Customers? Customer { get; set; }
    public Products? Product { get; set; }
}