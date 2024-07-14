using EntityLayer.Concrete;
using EntityLayer.Models.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace EntityLayer.DbContexts
{
    public class AppDbContext : DbContext
    {

        public DbSet<Urun> Urunler { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<UstKategori> UstKategoriler { get; set; }


        //public DbSet<Fotograf> Fotograflar { get; set; }
        //public DbSet<Stok> Stoklar { get; set; }


        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 26));
            optionsBuilder.UseMySql("server=localhost;Database=PetShopDb;user id=root;password=1234", serverVersion);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


        }
    }
}