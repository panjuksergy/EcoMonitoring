using AutoMapper;
using SparkSwim.Core.Mapping;
using SparkSwim.GoodsService.Goods.Commands.CreateGood;

namespace SparkSwim.GoodsService.Goods.Models;

public class CreateEcoRecordDto : IMapWith<CreateEcoRecordCommand>
{
    public Guid UserId { get; set; }
    public double SuspendedSolids { get; set; }
    public double SulfurDioxide { get; set; }
    public double CarbonDioxide { get; set; }
    public double NitrogenDioxide { get; set; }
    public double HydrogenFluoride  { get; set; }
    public double Ammonia  { get; set; }
    public double Formaldehyde  { get; set; }   

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateEcoRecordDto, CreateEcoRecordCommand>();
    }
}