using Microsoft.EntityFrameworkCore;
using Bangazon.Models;
using System.Runtime.CompilerServices;

public class BangazonDbContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
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
        new User { Id = 1, Uid = "firebase_key_1", FirstName = "John", LastName = "Saniat", UserName = "TalkingLunchbox", Address = "123 Main St", Email = "jsaniat2155@astound.com", IsSeller = false },
        new User { Id = 2, Uid = "firebase_key_2", FirstName = "Jayne", LastName = "Saniat", UserName = "WildthornBerry", Address = "456 Elm St", Email = "scribblejayne@example.com", IsSeller = true }
        });

        modelBuilder.Entity<Order>().HasData(new Order[]
        {
    new Order { Id = 1, Uid = "UddDl9yg9Nhq28kdu0SQyjjstkr2", IsComplete = true, PaymentTypeId = 1 },
    new Order { Id = 2, Uid = "UddDl9yg9Nhq28kdu0SQyjjstkr2", IsComplete = false, PaymentTypeId = 2 },
    new Order { Id = 3, Uid = "UddDl9yg9Nhq28kdu0SQyjjstkr2", IsComplete = true, PaymentTypeId = 2 }
        });

        modelBuilder.Entity<PaymentType>().HasData(new PaymentType[]
        {
        new PaymentType { Id = 1, Category = "Credit Card" },
        new PaymentType { Id = 2, Category = "PayPal" }
        });

        modelBuilder.Entity<ProductType>().HasData(new ProductType[]
        {
        new ProductType { Id = 1, Type = "Accessories" },
        new ProductType { Id = 2, Type = "Tops" },
        new ProductType { Id = 3, Type = "Shoes" },
        new ProductType { Id = 4, Type = "Bottoms" }
        });

        modelBuilder.Entity<Product>().HasData(new Product[]
        {
        new Product { Id = 1, ProductName = "Laptop", Image = "https://img-prod-cms-rt-microsoft-com.akamaized.net/cms/api/am/imageFileData/RW16TLP?ver=5c8b&q=90&m=6&h=705&w=1253&b=%23FFFFFFFF&f=jpg&o=f&p=140&aim=true", ProductTypeId = 1, Price = 999.99M, Quantity = 10, SellerId = 2 },
        new Product { Id = 2, ProductName = "T-shirt", Image = "https://images.squarespace-cdn.com/content/v1/60749d2bc6ea077ef59f25bb/1668559020652-VH40D8P9YVPWO6MJKDA0/Butterfly+Shirt+1+Front.jpg", ProductTypeId = 2, Price = 19.99M, Quantity = 20, SellerId = 2 }
        });


        modelBuilder.Entity<Order>()
             .HasMany(o => o.Products)
             .WithMany(p => p.Orders)
             .UsingEntity(j => j.ToTable("OrderProduct"));

    }
}