using EntityLayer.Models.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EntityLayer.DbContexts
{
    public class AppDbContext : IdentityDbContext<MyUser, IdentityRole, string>
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ParentCategory> ParentCategories { get; set; }


        //public DbSet<Photo> Photos { get; set; }
        //public DbSet<Stock> Stocks { get; set; }


        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySQL(@"Server=localhost;Database=PetShopDb;Uid=root;password=Password187");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


        }
    }
}