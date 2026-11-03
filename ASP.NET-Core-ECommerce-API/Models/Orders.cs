namespace ASP.NET_Core_ECommerce_API.Models;

public class Orders
{
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public string OrderStatus { get; set; } = "Pending";
    public int? ShippingAddressId { get; set; }

    public Customers? Customer { get; set; }
    public Addresses? ShippingAddress { get; set; }
    public ICollection<OrderItems> OrderItems { get; set; } = new List<OrderItems>();
    public ICollection<Payments> Payments { get; set; } = new List<Payments>();
    public OrderCoupons? OrderCoupon { get; set; }
}