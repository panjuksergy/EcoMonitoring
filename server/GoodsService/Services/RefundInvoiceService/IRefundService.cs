using SparkSwim.GoodsService.Goods.Models;

namespace SparkSwim.GoodsService.ShortenerService;

public interface IRefundService
{
    Task<RefundInvoice> CalculateRefundInvoice(int year, int month);
}