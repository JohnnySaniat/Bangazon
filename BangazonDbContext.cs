using Microsoft.EntityFrameworkCore;
using Bangazon.Models;
using System.Runtime.CompilerServices;

public class BangazonDbContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<PaymentType> PaymentTypes { get; set; }
    public DbSet<Product> Products { get; set; }

    public DbSet<ProductType> ProductTypes { get; set; }
    public DbSet<User> Users { get; set; }


    public BangazonDbContext(DbContextOptions<BangazonDbContext> context) : base(context)
    {

    }
}