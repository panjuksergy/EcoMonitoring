using AutoMapper;
using SparkSwim.Core.Mapping;
using SparkSwim.GoodsService.Goods.Models;

namespace SparkSwim.GoodsService.Products.Queries.GetProductList;

public class EcoRecordsLookUpDto : IMapWith<EcoRecord>
{
    public Guid RecordId { get; set; }
    public double SuspendedSolids { get; set; }
    public double SulfurDioxide { get; set; }
    public double CarbonDioxide { get; set; }
    public double NitrogenDioxide { get; set; }
    public double HydrogenFluoride  { get; set; }
    public double Ammonia  { get; set; }
    public double Formaldehyde { get; set; }
    public DateTime CreationDate { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<EcoRecord, EcoRecordsLookUpDto>();
    }
}