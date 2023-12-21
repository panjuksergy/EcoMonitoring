using SparkSwim.GoodsService.Goods.Models;

namespace SparkSwim.GoodsService.ShortenerService;

public interface IMonitoringService
{
    public double CalculateNonCancerRiskForNitrogenDioxide(double nitrogenDioxide);
    public double CalculateNonCancerRiskForAmmonia(double ammonia);
    public double CalculateNonCancerRiskForSulfurDioxide(double sulfurDioxide);
    public double CalculateNonCancerRiskForFormaldehyde(double formaldehyde);
    public double CalculateNonCancerRiskForHydrogenFluoride(double hydrogenFluorid);
    public double CalculateNonCancerRiskForCarbonDioxide(double carbonDioxide);
    public double CalculateNonCancerRiskForSuspendedSolids(double suspendedSolids);

    public double CalculateTotalNonCancerRisk(double hqSulfurDioxide, double hqFormaldehyde, double hqCarbonDioxide,
        double hqHydrogenFluoride, double hqSuspendedSolids);

}