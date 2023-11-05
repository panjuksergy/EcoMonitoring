using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SparkSwim.GoodsService.Goods.Models;

namespace SparkSwim.GoodsService.Goods.EntityTypeConfiguration;

public class UrlConfiguration : IEntityTypeConfiguration<EcoRecord>
{
    public void Configure(EntityTypeBuilder<EcoRecord> builder)
    {
        builder.HasKey(_ => _.RecordId);
        builder
            .HasOne(e => e.MonitoringSingleStat)
            .WithOne(s => s.EcoRecord)
            .HasForeignKey<MonitoringSingleStat>(s => s.EcoRecordId).IsRequired();
    }   
}