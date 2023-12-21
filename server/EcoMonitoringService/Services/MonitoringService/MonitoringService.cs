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

// Розрахунок неканцерогенного ризику для діоксиду азоту 

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
    }
}