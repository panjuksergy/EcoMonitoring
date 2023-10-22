using MediatR;
using SparkSwim.GoodsService.Goods.Models;

namespace SparkSwim.GoodsService.Products.Queries.GetProduct;

public class GetEcoRecordDetailsQuery : IRequest<EcoRecordDetailsVm>
{
    public Guid RecordId { get; set; }
}