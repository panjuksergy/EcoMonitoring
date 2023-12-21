using MediatR;

namespace EcoMonitoringService.EcoRecords.Queries.GetRefundInvoice;

public class RefundInvoiceQuery : IRequest<RefundInvoiceVm>
{
    public int Year { get; set; }
    public int Month { get; set; }
}