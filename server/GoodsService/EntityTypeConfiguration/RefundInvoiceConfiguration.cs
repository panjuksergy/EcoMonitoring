using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SparkSwim.GoodsService.Goods.Models;

namespace SparkSwim.GoodsService.Goods.EntityTypeConfiguration;

public class RefundInvoiceConfiguration : IEntityTypeConfiguration<RefundInvoice>
{
    public void Configure(EntityTypeBuilder<RefundInvoice> builder)
    {
        builder.HasKey(_ => _.RefundId);
        builder.HasMany(_ => _.EcoRecords);
    }
}