using Microsoft.EntityFrameworkCore;
using Bangazon.Models;
using System.Runtime.CompilerServices;

public class BangazonDbContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderProduct> OrderProducts { get; set; }
    public DbSet<PaymentType> PaymentTypes { get; set; }
    public DbSet<Product> Products { get; set; }

    public DbSet<ProductType> ProductTypes { get; set; }
    public DbSet<User> Users { get; set; }


    public BangazonDbContext(DbContextOptions<BangazonDbContext> context) : base(context)
    {

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(new User[]
        {
        new User { Id = 1, FirebaseKey = "firebase_key_1", FirstName = "John", LastName = "Saniat", UserName = "TalkingLunchbox", Address = "123 Main St", Email = "jsaniat2155@astound.com", IsSeller = false },
        new User { Id = 2, FirebaseKey = "firebase_key_2", FirstName = "Jayne", LastName = "Saniat", UserName = "WildthornBerry", Address = "456 Elm St", Email = "scribblejayne@example.com", IsSeller = true }
        });

        modelBuilder.Entity<OrderProduct>().HasData(new OrderProduct[]
        {
    new OrderProduct { Id = 1, OrderId = 1, ProductId = 1},
    new OrderProduct { Id = 2, OrderId = 1, ProductId = 2 }
        });

        modelBuilder.Entity<Order>().HasData(new Order[]
        {
        new Order { Id = 1, CustomerId = 1, SellerId = 2, IsComplete = false, PaymentTypeId = DateTime.Now }
        });

        modelBuilder.Entity<PaymentType>().HasData(new PaymentType[]
        {
        new PaymentType { Id = 1, Category = "Credit Card" },
        new PaymentType { Id = 2, Category = "PayPal" }
        });

        modelBuilder.Entity<ProductType>().HasData(new ProductType[]
        {
        new ProductType { Id = 1, Type = "Electronics" },
        new ProductType { Id = 2, Type = "Clothing" }
        });

        modelBuilder.Entity<Product>().HasData(new Product[]
        {
        new Product { Id = 1, ProductName = "Laptop", TypeId = 1, Price = 999.99M, Quantity = 10, SellerId = 2 },
        new Product { Id = 2, ProductName = "T-shirt", TypeId = 2, Price = 19.99M, Quantity = 20, SellerId = 2 }
        });

    }

}