namespace ASP.NET_Core_ECommerce_API.Models;

public class CartItems
{
    public int CartItemId { get; set; }
    public int CartId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; } = 1;

    public Carts? Cart { get; set; }
    public Products? Product { get; set; }
}