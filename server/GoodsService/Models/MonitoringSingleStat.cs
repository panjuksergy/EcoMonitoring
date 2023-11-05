
    namespace SparkSwim.GoodsService.Goods.Models;

    public class MonitoringSingleStat
    {
        public Guid MonitoringSingleStatId { get; set; }
        public EcoRecord EcoRecord { get; set; }
        public Guid EcoRecordId { get; set; }
        public double SuspendedSolidsStat { get; set; }
        public double SulfurDioxideStat { get; set; }
        public double CarbonDioxideStat { get; set; }
        public double NitrogenDioxideStat { get; set; }
        public double HydrogenFluorideStat { get; set; }
        public double AmmoniaStat { get; set; }
        public double FormaldehydeStat { get; set; }
        public double TotalNonCancerRisk { get; set; }
    }