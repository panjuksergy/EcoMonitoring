using MediatR;
using SparkSwim.GoodsService.ShortenerService;

namespace EcoMonitoringService.EcoRecords.Queries.GetRefundInvoice;

public class RefundInvoiceQueryHandler : IRequestHandler<RefundInvoiceQuery, RefundInvoiceVm>
{

    private readonly IRefundService _refundService;
    public RefundInvoiceQueryHandler(IRefundService refundService)
    {
        _refundService = refundService;
    }
    public async Task<RefundInvoiceVm> Handle(RefundInvoiceQuery request, CancellationToken cancellationToken)
    {
        var invoice = await _refundService.CalculateRefundInvoice(request.Year, request.Month);

        return new RefundInvoiceVm
        {
            DateFrom = invoice.PeriodFrom,
            DateTo = invoice.PeriodTo,
            Money = invoice.Money,
        };
    }
}