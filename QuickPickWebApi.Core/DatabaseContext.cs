using Microsoft.EntityFrameworkCore;
using QuickPickWebApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace QuickPickWebApi.Core
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<InvoiceStatusCode> InvoiceStatusCodes { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
       


    }
}
