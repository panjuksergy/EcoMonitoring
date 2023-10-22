using Microsoft.EntityFrameworkCore;
using SparkSwim.GoodsService.Goods.Models;

namespace SparkSwim.GoodsService.Interfaces;

public interface IEcoDbContext
{
    DbSet<EcoRecord> EcoRecords { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}