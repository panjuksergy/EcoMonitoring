using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SparkSwim.GoodsService.Goods.Models;

namespace SparkSwim.GoodsService.ShortenerService
{
    public class Monitoring : IMonitoring
    {
        public EcoRecord LastConcentration { get; set; }

        private const double RfcSulfureDioxide = 0.08;
        private const double RfcFormaldehid = 0.046;
        private const double RfcHydrogenFluoride = 0.82;
        private const double RfcCarmonDioxyde = 0.7;
        private const double RfcSuspendedSolids = 0.1;
        private const double RfcNitrogenDioxide = 0.04;
        private const double RfcAmmonia = 0.1;

// Розрахунок неканцерогенного ризику для діоксиду азоту 

        public double CalculateNonCancerRiskForNitrogenDioxide()
        {
            double hq = LastConcentration.NitrogenDioxide / RfcNitrogenDioxide;
            return hq;
        }

// Розрахунок неканцерогенного ризику для аміаку
        public double CalculateNonCancerRiskForAmmonia()
        {
            double hq = LastConcentration.Ammonia / RfcAmmonia;
            return hq;
        }

// Розрахунок неканцерогенного ризику для діоксиду сірки
        public double CalculateNonCancerRiskForSulfurDioxide()
        {
            double hq = LastConcentration.SulfurDioxide / RfcSulfureDioxide;
            return hq;
        }

// Розрахунок неканцерогенного ризику для формальдегіду
        public double CalculateNonCancerRiskForFormaldehyde()
        {
            double hq = LastConcentration.Formaldehyde / RfcFormaldehid;
            return hq;
        }

// Розрахунок неканцерогенного ризику для фтористого водню
        public double CalculateNonCancerRiskForHydrogenFluoride()
        {
            double hq = LastConcentration.HydrogenFluoride / RfcHydrogenFluoride;
            return hq;
        }

// Розрахунок неканцерогенного ризику для діоксиду вуглецю
        public double CalculateNonCancerRiskForCarbonDioxide()
        {
            double hq = LastConcentration.CarbonDioxide / RfcCarmonDioxyde;
            return hq;
        }

// Розрахунок неканцерогенного ризику для твердих часток (пилу)
        public double CalculateNonCancerRiskForSuspendedSolids()
        {
            double hq = LastConcentration.SuspendedSolids / RfcSuspendedSolids;
            return hq;
        }

// Розрахунок сумарного неканцерогенного ризику
        public double CalculateTotalNonCancerRisk()
        {
            double hqSulfurDioxide = CalculateNonCancerRiskForSulfurDioxide();
            double hqFormaldehyde = CalculateNonCancerRiskForFormaldehyde();
            double hqHydrogenFluoride = CalculateNonCancerRiskForHydrogenFluoride();
            double hqCarbonDioxide = CalculateNonCancerRiskForCarbonDioxide();
            double hqSuspendedSolids = CalculateNonCancerRiskForSuspendedSolids();

            double totalRisk = hqSulfurDioxide + hqFormaldehyde + hqHydrogenFluoride + hqCarbonDioxide +
                               hqSuspendedSolids;
            return totalRisk;
        }
    }
}