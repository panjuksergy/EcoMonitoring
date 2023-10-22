using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SparkSwim.GoodsService.Goods.EntityTypeConfiguration;
using SparkSwim.GoodsService.Goods.Models;
using SparkSwim.GoodsService.Interfaces;

namespace SparkSwim.GoodsService;

public class EcoDbContext : DbContext, IEcoDbContext
{
    public DbSet<EcoRecord> EcoRecords { get; set; }
    
    public EcoDbContext(DbContextOptions<EcoDbContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.ApplyConfiguration(new UrlConfiguration());
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}