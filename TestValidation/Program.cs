using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.DbContexts;
using EntityLayer.Models.Concrete;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TestValidation.ValidationRules;

namespace TestValidation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Database context
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Managers and services
            builder.Services.AddScoped<IProductManager<AppDbContext, Product, int>, ProductManager<AppDbContext, Product, int>>();
            builder.Services.AddScoped<ICategoryManager<AppDbContext, Category, int>, CategoryManager<AppDbContext, Category, int>>();


            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IValidator<Product>, ProductValidator>();

            builder.Services.AddFluentValidationClientsideAdapters();
            builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
