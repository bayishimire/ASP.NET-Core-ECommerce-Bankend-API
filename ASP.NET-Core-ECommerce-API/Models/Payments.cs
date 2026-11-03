namespace ASP.NET_Core_ECommerce_API.Models;

public class Payments
{
    public int PaymentId { get; set; }
    public int OrderId { get; set; }
    public string PaymentMethod { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public string PaymentStatus { get; set; } = "Pending";
    public string? TransactionReference { get; set; }
    public DateTime PaymentDate { get; set; }

    public Orders? Order { get; set; }
}