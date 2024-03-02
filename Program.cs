using Bangazon.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using bangazonBE.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("http://localhost:3000",
                                "http://localhost:7040")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<BangazonDbContext>(builder.Configuration["BangazonDbConnectionString"]);

// Set the JSON serializer options
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();

app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//USERS

app.MapGet("/api/users", (BangazonDbContext db) =>
{
    return db.Users.ToList();
});

app.MapPost("/api/users", (BangazonDbContext db, User userInfo) =>
{
    db.Users.Add(userInfo);
    db.SaveChanges();
    return Results.Created($"/api/users/{userInfo.Id}", userInfo);
});

app.MapGet("/api/users/{id}", (BangazonDbContext db, int id) =>
{
    User user = db.Users.SingleOrDefault(u => u.Id == id);
    if (user == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(user);
});

app.MapDelete("/api/users/{id}", (BangazonDbContext db, int id) =>
{
    User userToDelete = db.Users.SingleOrDefault(u => u.Id == id);
    if (userToDelete == null)
    {
        return Results.NotFound();
    }
    db.Users.Remove(userToDelete);
    db.SaveChanges();
    return Results.Ok(db.Users);
});

app.MapGet("/api/users/details/{uid}", (BangazonDbContext db, string uid) =>
{

    User user = db.Users.SingleOrDefault(u => u.Uid == uid);

    if (user == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(user);
});

app.MapPatch("/api/users/sell/{uid}", async (BangazonDbContext db, string uid) =>
{
    User user = db.Users.SingleOrDefault(u => u.Uid == uid);

    if (user == null)
    {
        return Results.NotFound();
    }

    user.IsSeller = true;
    await db.SaveChangesAsync();

    return Results.Ok(user);
});

app.MapPatch("/api/users/{id}", (BangazonDbContext db, int id, User user) =>
{
    User userToUpdate = db.Users.SingleOrDefault(u => u.Id == id);
    if (userToUpdate == null)
    {
        return Results.NotFound();
    }
    userToUpdate.Uid = user.Uid;
    userToUpdate.FirstName = user.FirstName;
    userToUpdate.LastName = user.LastName;
    userToUpdate.UserName = user.UserName;
    userToUpdate.Address = user.Address;
    userToUpdate.Email = user.Email;
    userToUpdate.IsSeller = user.IsSeller;
    db.SaveChanges();
    return Results.Ok(userToUpdate);
});

//PRODUCTS

app.MapGet("/api/products", (BangazonDbContext db) =>
{
    return db.Products.Include(p => p.ProductType).ToList();
});

app.MapGet("/api/products/{id}", (BangazonDbContext db, int id) =>
{
    Product product = db.Products.SingleOrDefault(p => p.Id == id);
    if (product == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(product);
});

app.MapPost("/api/products", (BangazonDbContext db, Product product) =>
{
    db.Products.Add(product);
    db.SaveChanges();
    return Results.Created($"/api/products/{product.Id}", product);
});

//ORDERS

app.MapGet("/api/orders", (BangazonDbContext db) =>
{
    // Include PaymentType to retrieve related information
    return db.Orders.Include(o => o.PaymentType).ToList();
});

app.MapGet("/api/orders/{id}/products", (BangazonDbContext db, int id) =>
{
    var Order = db.Orders.Include(o => o.Products).FirstOrDefault(o => o.Id == id);
    return Order;
});

app.MapDelete("/api/orders/{id}", (BangazonDbContext db, int id) =>
{
    Order orderToDelete = db.Orders.SingleOrDefault(p => p.Id == id);
    if (orderToDelete == null)
    {
        return Results.NotFound();
    }
    db.Orders.Remove(orderToDelete);
    db.SaveChanges();
    return Results.Ok(db.Orders);
});


//ORDERPRODUCT

app.MapPost("api/orders/addProduct", (BangazonDbContext db, addProductDTO newProduct) =>
{
    var order = db.Orders.Include(o => o.Products).FirstOrDefault(o => o.Id == newProduct.OrderId);

    if (order == null)
    {
        return Results.NotFound("Order not found.");
    }

    var product = db.Products.Find(newProduct.ProductId);

    if (product == null)
    {
        return Results.NotFound("Product not found.");
    }

    var existingProduct = order.Products.FirstOrDefault(p => p.Id == newProduct.ProductId);

    if (existingProduct != null)
    {
        existingProduct.Quantity += newProduct.Quantity;
    }
    else
    {
        product.Quantity = newProduct.Quantity;
        order.Products.Add(product);
    }

    db.SaveChanges();

    return Results.Created($"/orders/addProduct", newProduct);
});

app.MapGet("/api/products/{id}/orders", (BangazonDbContext db, int id) =>
{
    var product = db.Products.Include(p => p.Orders).FirstOrDefault(p => p.Id == id);
    return product;
});


//PAYMENT TYPE

app.MapGet("/api/paymenttypes", (BangazonDbContext db) =>
{
    return db.PaymentTypes.ToList();
});

app.MapGet("/api/paymenttypes/{id}", (BangazonDbContext db, int id) =>
{
    PaymentType paymenttype = db.PaymentTypes.SingleOrDefault(pt => pt.Id == id);
    if (paymenttype == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(paymenttype);
});

app.MapDelete("/api/paymenttypes/{id}", (BangazonDbContext db, int id) =>
{
    PaymentType paymentTypeToDelete = db.PaymentTypes.SingleOrDefault(pt => pt.Id == id);
    if (paymentTypeToDelete == null)
    {
        return Results.NotFound();
    }
    db.PaymentTypes.Remove(paymentTypeToDelete);
    db.SaveChanges();
    return Results.Ok(db.PaymentTypes);
});

app.MapPut("/api/paymenttypes/{id}", (BangazonDbContext db, int id, PaymentType paymentType) =>
{
    ProductType paymentTypeToUpdate = db.ProductTypes.SingleOrDefault(pt => pt.Id == id);
    if (paymentTypeToUpdate == null)
    {
        return Results.NotFound();
    }
    paymentTypeToUpdate.Type = paymentType.Category;
    db.SaveChanges();
    return Results.Ok(paymentTypeToUpdate);
});

app.MapPost("/api/paymenttypes", (BangazonDbContext db, PaymentType paymentType) =>
{
    db.PaymentTypes.Add(paymentType);
    db.SaveChanges();
    return Results.Created($"/api/products/{paymentType.Id}", paymentType);
});

//PRODUCT TYPES

app.MapGet("/api/producttypes", (BangazonDbContext db) =>
{
    return db.ProductTypes.ToList();
});

app.MapGet("/api/producttypes/{id}", (BangazonDbContext db, int id) =>
{
    ProductType producttype = db.ProductTypes.SingleOrDefault(pt => pt.Id == id);
    if (producttype == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(producttype);
});

app.MapDelete("/api/producttypes/{id}", (BangazonDbContext db, int id) =>
{
    ProductType producttypeToDelete = db.ProductTypes.SingleOrDefault(pt => pt.Id == id);
    if (producttypeToDelete == null)
    {
        return Results.NotFound();
    }
    db.ProductTypes.Remove(producttypeToDelete);
    db.SaveChanges();
    return Results.Ok(db.ProductTypes);
});

app.MapPut("/api/producttypes/{id}", (BangazonDbContext db, int id, ProductType prodtype) =>
{
    ProductType producttypeToUpdate = db.ProductTypes.SingleOrDefault(pt => pt.Id == id);
    if (producttypeToUpdate == null)
    {
        return Results.NotFound();
    }
    producttypeToUpdate.Type = prodtype.Type;
    db.SaveChanges();
    return Results.Ok(producttypeToUpdate);
});

app.MapPost("/api/producttypes", (BangazonDbContext db, ProductType producttype) =>
{
    db.ProductTypes.Add(producttype);
    db.SaveChanges();
    return Results.Created($"/api/products/{producttype.Id}", producttype);
});

//LOGIN

app.MapGet("/api/checkuser/{uid}", (BangazonDbContext db, string uid) =>
{
    var authUser = db.Users.Where(u => u.Uid == uid).FirstOrDefault();
    if (authUser == null)
    {
        return Results.StatusCode(204);
    }
    return Results.Ok(authUser);
});

//SEARCH

app.MapGet("/api/products/search", (BangazonDbContext db, string searchValue) =>
{
    var searchResults = db.Products
        .Include(p => p.ProductType)
        .Where(p =>
            p.ProductName.ToLower().Contains(searchValue.ToLower()) ||
            p.Image.ToLower().Contains(searchValue.ToLower()) ||
            (p.ProductType != null && p.ProductType.Type.ToLower().Contains(searchValue.ToLower())) ||
            p.Price.ToString().Contains(searchValue) ||
            p.Quantity.ToString().Contains(searchValue) ||
            p.SellerId.ToString().Contains(searchValue)
        )
        .Select(p => new ProductDTO
        {
            Id = p.Id,
            ProductName = p.ProductName,
            Image = p.Image,
            ProductType = p.ProductType != null ? p.ProductType.Type : null,
            Price = p.Price,
            Quantity = p.Quantity,
            SellerId = p.SellerId
        })
        .ToList();

    return searchResults.Any() ? Results.Ok(searchResults) : Results.StatusCode(204);
});

app.MapDelete("/api/orders/{orderId}/products/{productId}", (BangazonDbContext db, int orderId, int productId) =>
{
    var order = db.Orders.Include(o => o.Products).FirstOrDefault(o => o.Id == orderId);

    if (order == null)
    {
        return Results.NotFound("Order not found.");
    }

    var productToRemove = order.Products.FirstOrDefault(p => p.Id == productId);

    if (productToRemove == null)
    {
        return Results.NotFound("Product not found in cart.");
    }

    order.Products.Remove(productToRemove);

    db.SaveChanges();

    return Results.Ok("Product removed from the cart.");
});


app.Run();