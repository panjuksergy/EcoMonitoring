using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SparkSwim.GoodsService.Goods.Models;

namespace SparkSwim.GoodsService.ShortenerService
{
    public class MonitoringService : IMonitoringService
    {
        private const double RfcSulfureDioxide = 0.08;
        private const double RfcFormaldehid = 0.046;
        private const double RfcHydrogenFluoride = 0.82;
        private const double RfcCarmonDioxyde = 0.7;
        private const double RfcSuspendedSolids = 0.1;
        private const double RfcNitrogenDioxide = 0.04;
        private const double RfcAmmonia = 0.1;

        #region nonCancerRisk
        public double CalculateNonCancerRiskForNitrogenDioxide(double nitrogenDioxide)
        {
            double hq = nitrogenDioxide / RfcNitrogenDioxide;
            return hq;
        }

        // Розрахунок неканцерогенного ризику для аміаку
        public double CalculateNonCancerRiskForAmmonia(double ammonia)
        {
            double hq = ammonia / RfcAmmonia;
            return hq;
        }

        // Розрахунок неканцерогенного ризику для діоксиду сірки
        public double CalculateNonCancerRiskForSulfurDioxide(double sulfurDioxide)
        {
            double hq = sulfurDioxide / RfcSulfureDioxide;
            return hq;
        }

        // Розрахунок неканцерогенного ризику для формальдегіду
        public double CalculateNonCancerRiskForFormaldehyde(double formaldehyde)
        {
            double hq = formaldehyde / RfcFormaldehid;
            return hq;
        }

        // Розрахунок неканцерогенного ризику для фтористого водню
        public double CalculateNonCancerRiskForHydrogenFluoride(double hydrogenFluorid)
        {
            double hq = hydrogenFluorid / RfcHydrogenFluoride;
            return hq;
        }

        // Розрахунок неканцерогенного ризику для діоксиду вуглецю
        public double CalculateNonCancerRiskForCarbonDioxide(double carbonDioxide)
        {
            double hq = carbonDioxide / RfcCarmonDioxyde;
            return hq;
        }

        // Розрахунок неканцерогенного ризику для твердих часток (пилу)
        public double CalculateNonCancerRiskForSuspendedSolids(double suspendedSolids)
        {
            double hq = suspendedSolids / RfcSuspendedSolids;
            return hq;
        }

        // Розрахунок сумарного неканцерогенного ризику
        public double CalculateTotalNonCancerRisk(double hqSulfurDioxide, double hqFormaldehyde, double hqCarbonDioxide, double hqHydrogenFluoride, double hqSuspendedSolids)
        {
            double totalRisk = hqSulfurDioxide + hqFormaldehyde + hqHydrogenFluoride + hqCarbonDioxide +
                               hqSuspendedSolids;
            return totalRisk;
        }
        #endregion

        #region cancerRisk
        public double CalculateCSFForSulfurDioxide(double exposureLevel)
        {
            // Sample formula (Not an accurate representation of actual CSF determination)
            // This is a placeholder for an actual scientific calculation based on research
            double csf = exposureLevel * 0.005; // Example formula (not accurate)

            return csf;
        }

        // Add similar methods for other substances
        public double CalculateCSFForFormaldehyde(double exposureLevel)
        {
            double csf = exposureLevel * 0.003; // Example formula (not accurate)
            return csf;
        }

        public double CalculateCSFForHydrogenFluoride(double exposureLevel)
        {
            double csf = exposureLevel * 0.008; // Example formula (not accurate)
            return csf;
        }

        public double CalculateCSFForCarbonDioxide(double exposureLevel)
        {
            double csf = exposureLevel * 0.007; // Example formula (not accurate)
            return csf;
        }

        public double CalculateCSFForSuspendedSolids(double exposureLevel)
        {
            double csf = exposureLevel * 0.01; // Example formula (not accurate)
            return csf;
        }

        public double CalculateCSFForNitrogenDioxide(double exposureLevel)
        {
            double csf = exposureLevel * 0.004; // Example formula (not accurate)
            return csf;
        }

        public double CalculateCSFForAmmonia(double exposureLevel)
        {
            double csf = exposureLevel * 0.01; // Example formula (not accurate)
            return csf;
        }
        
        // Example method to calculate cancer risk for multiple carcinogens
        public double CalculateTotalCancerRisk(
            double riskSulfurDioxide, 
            double riskFormaldehyde, 
            double riskHydrogenFluoride,
            double riskCarbonDioxide,
            double riskSuspendedSolids,
            double riskNitrogenDioxide,
            double riskAmmonia)
        {
            // Calculate total cancer risk by summing up individual risks
            double totalRisk = riskSulfurDioxide + riskFormaldehyde + riskHydrogenFluoride +
                               riskCarbonDioxide + riskSuspendedSolids + riskNitrogenDioxide + riskAmmonia;

            return totalRisk;
        }

        #endregion 
        
    }
}