namespace ASP.NET_Core_ECommerce_API.Models;

public class Categories
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }

    public ICollection<Products> Products { get; set; } = new List<Products>();

}