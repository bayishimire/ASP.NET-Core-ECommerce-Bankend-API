namespace ASP.NET_Core_ECommerce_API.Models;

public class Carts
{
    public int CartId { get; set; }
    public int CustomerId { get; set; }
    public DateTime CreatedAt { get; set; }

    public Customers? Customer { get; set; }
    public ICollection<CartItems> CartItems { get; set; } = new List<CartItems>();
}