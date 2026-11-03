namespace ASP.NET_Core_ECommerce_API.Models;

public class Coupons
{
    public int CouponId { get; set; }
    public string CouponCode { get; set; } = string.Empty;
    public decimal DiscountPercentage { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsActive { get; set; }

    public OrderCoupons? OrderCoupon { get; set; }
}