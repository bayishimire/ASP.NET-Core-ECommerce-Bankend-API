namespace ASP.NET_Core_ECommerce_API.Models;

public class Products
{
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public int CategoryId { get; set; }
    public DateTime CreatedAt { get; set; }

    public Categories? Category { get; set; }
    public ICollection<OrderItems> OrderItems { get; set; } = new List<OrderItems>();
    public ICollection<CartItems> CartItems { get; set; } = new List<CartItems>();
    public ICollection<Reviews> Reviews { get; set; } = new List<Reviews>();
}