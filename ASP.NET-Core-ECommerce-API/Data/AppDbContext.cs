using Microsoft.EntityFrameworkCore;
using ASP.NET_Core_ECommerce_API.Models;

namespace ASP.NET_Core_ECommerce_API.Data;

public class AppDbContext:DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    
    public DbSet<Customers> Customers { get; set; }
    public DbSet<Categories> Categories { get; set; }
    public DbSet<Products> Products { get; set; }
    public DbSet<Addresses> Addresses { get; set; }
    public DbSet<Orders> Orders { get; set; }
    public DbSet<OrderItems> OrderItems { get; set; }
    public DbSet<Payments> Payments { get; set; }
    public DbSet<Carts> Carts { get; set; }
    public DbSet<CartItems> CartItems { get; set; }
    public DbSet<Reviews> Reviews { get; set; }
    public DbSet<Coupons> Coupons { get; set; }
    public DbSet<OrderCoupons> OrderCoupons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure Primary Keys
        modelBuilder.Entity<Addresses>().HasKey(a => a.AddressId);
        modelBuilder.Entity<CartItems>().HasKey(ci => ci.CartItemId);
        modelBuilder.Entity<Carts>().HasKey(c => c.CartId);
        modelBuilder.Entity<Categories>().HasKey(c => c.CategoryId);
        modelBuilder.Entity<Coupons>().HasKey(c => c.CouponId);
        modelBuilder.Entity<Customers>().HasKey(c => c.CustomerId);
        modelBuilder.Entity<OrderCoupons>().HasKey(oc => oc.OrderCouponId);
        modelBuilder.Entity<OrderItems>().HasKey(oi => oi.OrderItemId);
        modelBuilder.Entity<Orders>().HasKey(o => o.OrderId);
        modelBuilder.Entity<Payments>().HasKey(p => p.PaymentId);
        modelBuilder.Entity<Products>().HasKey(p => p.ProductId);
        modelBuilder.Entity<Reviews>().HasKey(r => r.ReviewId);

        // 1. Configure Carts -> Customers (One-to-One)
        modelBuilder.Entity<Carts>()
            .HasOne(c => c.Customer)
            .WithOne(cu => cu.Cart)
            .HasForeignKey<Carts>(c => c.CustomerId)
            .HasPrincipalKey<Customers>(cu => cu.CustomerId);

        // 2. Configure OrderCoupons -> Orders (One-to-One)
        modelBuilder.Entity<OrderCoupons>()
            .HasOne(oc => oc.Order)
            .WithOne(o => o.OrderCoupon)
            .HasForeignKey<OrderCoupons>(oc => oc.OrderId)
            .HasPrincipalKey<Orders>(o => o.OrderId);

        // 3. Configure OrderCoupons -> Coupons (One-to-One)
        modelBuilder.Entity<OrderCoupons>()
            .HasOne(oc => oc.Coupon)
            .WithOne(c => c.OrderCoupon)
            .HasForeignKey<OrderCoupons>(oc => oc.CouponId)
            .HasPrincipalKey<Coupons>(c => c.CouponId);

        // 4. Precision configurations for decimals
        modelBuilder.Entity<Products>()
            .Property(p => p.Price).HasPrecision(18, 2);

        modelBuilder.Entity<Orders>()
            .Property(o => o.TotalAmount).HasPrecision(18, 2);

        modelBuilder.Entity<OrderItems>()
            .Property(oi => oi.UnitPrice).HasPrecision(18, 2);

        modelBuilder.Entity<Payments>()
            .Property(p => p.Amount).HasPrecision(18, 2);
    }


}
