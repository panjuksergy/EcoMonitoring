using AutoMapper;
using SparkSwim.Core.Mapping;
using SparkSwim.GoodsService.Goods.Models;

namespace SparkSwim.GoodsService.Products.Queries.GetProduct;

public class EcoRecordDetailsVm : IMapWith<EcoRecord>
{
    public Guid RecordId { get; set; }
    public Guid UserId { get; set; }
    public double SuspendedSolids { get; set; }
    public double SulfurDioxide { get; set; }
    public double CarbonDioxide { get; set; }
    public double NitrogenDioxide { get; set; }
    public double HydrogenFluoride  { get; set; }
    public double AmmoniaFormaldehyde  { get; set; }
    public DateTime CreationDate { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<EcoRecord, EcoRecordDetailsVm>();
    }
}