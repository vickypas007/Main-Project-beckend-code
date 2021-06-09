using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using QuickPickWebApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace QuickPickWebApi.Core
{
    public class DatabaseContext : DbContext
    {
        string connstr = "";
        //public DatabaseContext()
        //{
        //    var basePath = AppContext.BaseDirectory;

        //    var builder = new ConfigurationBuilder()
        //                  .SetBasePath(basePath)
        //                 .AddJsonFile("appsettings.Development.json")
        //                 .AddEnvironmentVariables();

        //    var config = builder.Build();

        //    connstr = config.GetConnectionString("DefaultConnection");
        //}

        public DatabaseContext(DbContextOptions options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<InvoiceStatusCode> InvoiceStatusCodes { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Location> Locations  { get; set; }
        public DbSet<Login> Logins  { get; set; }
        public DbSet<ShopCategory> shopCategories  { get; set; }
        public DbSet<TaxRate> taxRates  { get; set; }
        public DbSet<Country> countrys  { get; set; }
        public DbSet<State> states  { get; set; }
        public DbSet<City>  Cities  { get; set; }
        public DbSet<CityHub> cityHubs  { get; set; }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseMySql(connstr);
        //    }
        //}
    }
}
