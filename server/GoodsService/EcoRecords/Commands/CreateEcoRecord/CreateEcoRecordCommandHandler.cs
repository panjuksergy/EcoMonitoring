using MediatR;
using SparkSwim.GoodsService.Goods.Models;
using SparkSwim.GoodsService.Interfaces;
using SparkSwim.GoodsService.ShortenerService;

namespace SparkSwim.GoodsService.Goods.Commands.CreateGood;

public class CreateEcoRecordCommandHandler : IRequestHandler<CreateEcoRecordCommand, EcoRecord>
{
    private readonly IEcoDbContext _dbContext;
    private readonly IMonitoringService _monitoringService;

    public CreateEcoRecordCommandHandler(IEcoDbContext dbContext, IMonitoringService monitoringService)
    {
        _dbContext = dbContext;
        _monitoringService = monitoringService;
    }

    public async Task<EcoRecord> Handle(CreateEcoRecordCommand request, CancellationToken cancellationToken)
    {
        var newEcoRecord = new EcoRecord
        {
            RecordId = Guid.NewGuid(),
            SuspendedSolids = request.SuspendedSolids,
            SulfurDioxide = request.SulfurDioxide,
            CarbonDioxide = request.CarbonDioxide,
            NitrogenDioxide = request.NitrogenDioxide,
            HydrogenFluoride = request.HydrogenFluoride,
            Ammonia = request.Ammonia,
            Formaldehyde = request.Formaldehyde,
            CreationDate = DateTime.Now,
            UserId = request.UserId,
        };

        await _dbContext.EcoRecords.AddAsync(newEcoRecord, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return newEcoRecord;
    }
}