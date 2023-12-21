namespace EcoMonitoringService.EcoRecords.Queries.GetRefundInvoice;

public class RefundInvoiceVm
{
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public double Money { get; set; }
}