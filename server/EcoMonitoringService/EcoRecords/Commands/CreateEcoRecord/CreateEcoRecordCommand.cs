using SparkSwim.GoodsService.Goods.Models;

namespace SparkSwim.GoodsService.Goods.Commands.CreateGood;
using MediatR;
public class CreateEcoRecordCommand : IRequest<EcoRecord>
{
    public Guid UserId { get; set; }
    public DateTime CreationDate { get; set; }
    public double SuspendedSolids { get; set; }
    public double SulfurDioxide { get; set; }
    public double CarbonDioxide { get; set; }
    public double NitrogenDioxide { get; set; }
    public double HydrogenFluoride  { get; set; }
    public double Ammonia { get; set; }
    public double Formaldehyde  { get; set; }
    
}