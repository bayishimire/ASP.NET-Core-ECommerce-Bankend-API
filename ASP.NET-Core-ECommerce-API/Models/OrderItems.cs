namespace ASP.NET_Core_ECommerce_API.Models;

public class OrderItems
{
    public int OrderItemId { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }

    public Orders? Order { get; set; }
    public Products? Product { get; set; }
}