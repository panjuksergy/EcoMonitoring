using SparkSwim.GoodsService.Goods.Models;

namespace SparkSwim.GoodsService.ShortenerService;

public interface IMonitoring
{
    public double CalculateTotalNonCancerRisk();
    public double CalculateNonCancerRiskForSuspendedSolids();
    public double CalculateNonCancerRiskForCarbonDioxide();
    public double CalculateNonCancerRiskForHydrogenFluoride();
    public double CalculateNonCancerRiskForFormaldehyde();
    public double CalculateNonCancerRiskForSulfurDioxide();
    public double CalculateNonCancerRiskForAmmonia();
    public double CalculateNonCancerRiskForNitrogenDioxide();


}