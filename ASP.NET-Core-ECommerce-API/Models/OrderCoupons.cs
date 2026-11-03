namespace ASP.NET_Core_ECommerce_API.Models;

public class OrderCoupons
{
    public int OrderCouponId { get; set; }
    public int OrderId { get; set; }
    public int CouponId { get; set; }
    public decimal DiscountAmount { get; set; }

    public Orders? Order { get; set; }
    public Coupons? Coupon { get; set; }
}