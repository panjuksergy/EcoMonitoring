using MediatR;

namespace SparkSwim.GoodsService.Products.Commands.DeleteProduct;

public class DeleteEcoRecordCommand : IRequest
{
    public Guid UserId { get; set; }
    public Guid RecordId { get; set; }
}