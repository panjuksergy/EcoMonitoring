namespace SparkSwim.GoodsService.Goods.Models;

public class RefundInvoice
{
    public Guid RefundId { get; set; }
    public List<EcoRecord> EcoRecords { get; set; }
    public DateTime PeriodFrom { get; set; }
    public DateTime PeriodTo { get; set; }
    public double Money { get; set; }
}