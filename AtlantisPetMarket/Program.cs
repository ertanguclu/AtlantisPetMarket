using AtlantisPetMarket.ValidationsRules;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.DbContexts;
using EntityLayer.Models.Concrete;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

// Database context
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));

// Managers and services
builder.Services.AddScoped<IProductManager<AppDbContext, Product, int>, ProductManager<AppDbContext, Product, int>>();
builder.Services.AddScoped<ICategoryManager<AppDbContext, Category, int>, CategoryManager<AppDbContext, Category, int>>();

// AutoMapper

// Controllers and views
builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);

// FluentValidation
builder.Services.AddScoped<IValidator<Product>, ProductValidator>();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());



// Identity
builder.Services.AddIdentity<MyUser, UserRole>()
    .AddEntityFrameworkStores<AppDbContext>();

var app = builder.Build();

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