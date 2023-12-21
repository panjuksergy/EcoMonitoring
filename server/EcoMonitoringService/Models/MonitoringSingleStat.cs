
    namespace SparkSwim.GoodsService.Goods.Models;

    public class MonitoringSingleStat
    {
        public Guid MonitoringSingleStatId { get; set; }
        public EcoRecord EcoRecord { get; set; }
        public Guid RecordId { get; set; }
        public double SuspendedSolidsStat { get; set; }
        public double SulfurDioxideStat { get; set; }
        public double CarbonDioxideStat { get; set; }
        public double NitrogenDioxideStat { get; set; }
        public double HydrogenFluorideStat { get; set; }
        public double AmmoniaStat { get; set; }
        public double FormaldehydeStat { get; set; }
        
        public double SuspendedSolidsCancerStat { get; set; }
        public double SulfurDioxideCancerStat { get; set; }
        public double CarbonDioxideCancerStat { get; set; }
        public double NitrogenDioxideCancerStat { get; set; }
        public double HydrogenFluorideCancerStat { get; set; }
        public double AmmoniaCancerStat { get; set; }
        public double FormaldehydeCancerStat { get; set; }
        public double TotalNonCancerRisk { get; set; }
        public double TotalCancerRisk { get; set; }
    }