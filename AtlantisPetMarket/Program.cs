using AtlantisPetMarket.AutoMapperConfig;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.DbContexts;
using EntityLayer.Models.Concrete;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

// Database context
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));

// Managers and services
builder.Services.AddScoped<IProductManager<AppDbContext, Product, int>, ProductManager<AppDbContext, Product, int>>();
builder.Services.AddScoped<ICategoryManager<AppDbContext, Category, int>, CategoryManager<AppDbContext, Category, int>>();
builder.Services.AddScoped<IParentCategoryManager<AppDbContext, ParentCategory, int>, ParentCategoryManager<AppDbContext, ParentCategory, int>>();
builder.Services.AddScoped<IContactManager<AppDbContext, Contact, int>, ContactManager<AppDbContext, Contact, int>>();
builder.Services.AddScoped<ICartManager<AppDbContext, Cart, int>, CartManager<AppDbContext, Cart, int>>();
builder.Services.AddScoped<ICartItemManager<AppDbContext, CartItem, int>, CartItemManager<AppDbContext, CartItem, int>>();


// AutoMapper
builder.Services.AddAutoMapper(typeof(MapperConfig));
// Controllers and views
builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);

// FluentValidation

builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());



// Identity
builder.Services.AddIdentity<User, UserRole>()
    .AddEntityFrameworkStores<AppDbContext>();

var app = builder.Build();

var cultureInfo = new CultureInfo("tr-TR");
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication(); // Add authentication middleware
app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
