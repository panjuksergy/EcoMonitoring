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


    double CalculateCSFForSulfurDioxide(double exposureLevel);
    double CalculateCSFForFormaldehyde(double exposureLevel);
    double CalculateCSFForHydrogenFluoride(double exposureLevel);
    double CalculateCSFForCarbonDioxide(double exposureLevel);
    double CalculateCSFForSuspendedSolids(double exposureLevel);
    double CalculateCSFForNitrogenDioxide(double exposureLevel);
    double CalculateCSFForAmmonia(double exposureLevel);

    double CalculateTotalCancerRisk(
        double riskSulfurDioxide,
        double riskFormaldehyde,
        double riskHydrogenFluoride,
        double riskCarbonDioxide,
        double riskSuspendedSolids,
        double riskNitrogenDioxide,
        double riskAmmonia);
    public double CalculateTotalNonCancerRisk(double hqSulfurDioxide, double hqFormaldehyde, double hqCarbonDioxide,
        double hqHydrogenFluoride, double hqSuspendedSolids);

}