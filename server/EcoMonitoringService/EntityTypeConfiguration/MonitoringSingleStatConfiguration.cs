using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SparkSwim.GoodsService.Goods.Models;

namespace SparkSwim.GoodsService.Goods.EntityTypeConfiguration;

public class MonitoringSingleStatConfiguration : IEntityTypeConfiguration<MonitoringSingleStat>
{
    public void Configure(EntityTypeBuilder<MonitoringSingleStat> builder)
    {
        builder.HasKey(_ => _.MonitoringSingleStatId);
        builder.HasOne(_ => _.EcoRecord).WithOne(_ => _.MonitoringSingleStat)
            .HasForeignKey<EcoRecord>(_ => _.MonitoringSingleStatId).IsRequired();
    }
}