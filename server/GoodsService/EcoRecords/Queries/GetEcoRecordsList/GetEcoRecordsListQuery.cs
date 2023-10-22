using MediatR;
using SparkSwim.GoodsService.Goods.Models;

namespace SparkSwim.GoodsService.Products.Queries.GetProductList;

public class GetEcoRecordsListQuery : IRequest<EcoRecordsListVm>
{
    // public int CountToGet { get; set; }
    // public int NumberFromToSkip { get; set; }
}