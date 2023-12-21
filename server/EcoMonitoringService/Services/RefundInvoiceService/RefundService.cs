using Microsoft.EntityFrameworkCore;
using SparkSwim.GoodsService.Goods.Models;
using SparkSwim.GoodsService.Interfaces;

namespace SparkSwim.GoodsService.ShortenerService;

public class RefundService : IRefundService
{
    private readonly IEcoDbContext _dbContext;

    private const double MAX_SUSPENDED_SOLIDS = 13;
    private const double MAX_SULFUR_DIOXIDE = 1;
    private const double MAX_CARBON_DIOXIDE = 13;
    private const double MAX_NITROGEN_DIOXIDE = 17;
    private const double MAX_HIDROHEN_FLOURIDE = 15;
    private const double MAX_AMONIA = 12;
    private const double MAX_FORMALDEHYDE = 13;

    private const double MONEY_PER_01 = 100;

    public RefundService(IEcoDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<RefundInvoice> CalculateRefundInvoice(int year, int month)
    {
        var startDate = new DateTime(year, month, 1);
        var endDate = startDate.AddMonths(1).AddDays(1);

        var allRecordsInMonth = await _dbContext.EcoRecords
            .Where(_ => _.CreationDate >= startDate && _.CreationDate <= endDate).ToListAsync();

        var result = new MonthFormatDto();
        
        foreach (var record in allRecordsInMonth)
        {
            result.Ammonia += record.Ammonia;
            result.Formaldehyde += record.Formaldehyde;
            result.CarbonDioxide += record.CarbonDioxide;
            result.SulfurDioxide += record.SulfurDioxide;
            result.HydrogenFluoride += record.HydrogenFluoride;
            result.NitrogenDioxide += record.NitrogenDioxide;
            result.SuspendedSolids += record.SuspendedSolids;
        }

        var moneyToRefund = CalculateMoneyToRefund(result);

        var invoice = new RefundInvoice
        {
            EcoRecords = allRecordsInMonth,
            Money = moneyToRefund,
            PeriodFrom = startDate,
            PeriodTo = endDate,
            RefundId = Guid.NewGuid(),
        };

        return invoice;
    }


    public double CalculateMoneyToRefund(MonthFormatDto monthStat)
    {
        int illegalIndex = 0;

        illegalIndex += (int)((monthStat.Formaldehyde - MAX_FORMALDEHYDE) / 0.1);
        illegalIndex += (int)((monthStat.Ammonia - MAX_AMONIA) / 0.1);

        illegalIndex += (int)((monthStat.SuspendedSolids - MAX_SUSPENDED_SOLIDS) / 0.1);
        illegalIndex += (int)((monthStat.CarbonDioxide - MAX_CARBON_DIOXIDE) / 0.1);

        illegalIndex += (int)((monthStat.SulfurDioxide - MAX_SULFUR_DIOXIDE) / 0.1);
        illegalIndex += (int)((monthStat.NitrogenDioxide - MAX_NITROGEN_DIOXIDE) / 0.1);

        illegalIndex += (int)((monthStat.HydrogenFluoride - MAX_HIDROHEN_FLOURIDE) / 0.1);

        var result = illegalIndex * MONEY_PER_01;

        return result;
    }
}