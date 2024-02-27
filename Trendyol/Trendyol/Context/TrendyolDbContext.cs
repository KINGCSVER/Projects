using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trendyol.Models;

namespace Trendyol.Context;

public class TrendyolDbContext : DbContext 
{
    public TrendyolDbContext()
    {

    }

    public DbSet<User> User { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Stock> Stock { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<Admin> Admin { get; set; }
    public DbSet<SuperAdmin> SuperAdmin { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(builder.GetConnectionString("Default"));
        }
    }
}

