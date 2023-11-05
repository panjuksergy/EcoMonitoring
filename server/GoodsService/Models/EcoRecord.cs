using SparkSwim.GoodsService.CustomAttributes;

namespace SparkSwim.GoodsService.Goods.Models;

    public class EcoRecord
    {
        public Guid RecordId { get; set; }
        public double SuspendedSolids { get; set; }
        public double SulfurDioxide { get; set; }
        public double CarbonDioxide { get; set; }
        public double NitrogenDioxide { get; set; }
        public double HydrogenFluoride  { get; set; }
        public double Ammonia { get; set; }
        public double Formaldehyde  { get; set; }
        public DateTime CreationDate { get; set; }
        public MonitoringSingleStat MonitoringSingleStat { get; set; }
        public Guid MonitoringSingleStatId { get; set; }
        public Guid UserId { get; set; }
    }