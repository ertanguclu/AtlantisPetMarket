using AtlantisPetMarket.AutoMapperConfig;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.DbContexts;
using EntityLayer.Models.Concrete;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AtlantisPetMarket
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<AppDbContext>(p => p.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IProductManager<AppDbContext, Product, int>, ProductManager<AppDbContext, Product, int>>();
            builder.Services.AddScoped<ICategoryManager<AppDbContext, Category, int>, CategoryManager<AppDbContext, Category, int>>();
            builder.Services.AddAutoMapper(typeof(ProductMapperConfig));


            builder.Services.AddIdentity<MyUser, UserRole>().AddEntityFrameworkStores<AppDbContext>();
            // Add services to the container.
            builder.Services.AddControllersWithViews();

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
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
