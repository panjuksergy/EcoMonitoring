using MediatR;
using System.Threading;
using System.Threading.Tasks;
using SparkSwim.GoodsService.Exceptions;
using SparkSwim.GoodsService.Interfaces;

namespace SparkSwim.GoodsService.Products.Commands.DeleteProduct
{
    public class DeleteEcoRecordCommandHandler : IRequestHandler<DeleteEcoRecordCommand>
    {
        private readonly IEcoDbContext _dbContext;

        public DeleteEcoRecordCommandHandler(IEcoDbContext ecoDbContext)
        {
            _dbContext = ecoDbContext;
        }

        public async Task Handle(DeleteEcoRecordCommand request, CancellationToken cancellationToken)
        {
            var recordToDelete = await _dbContext.EcoRecords.FindAsync(request.RecordId);

            if (recordToDelete == null)
            {
                throw new NotFoundException(nameof(EcoDbContext), request.RecordId);
            }

            _dbContext.EcoRecords.Remove(recordToDelete);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}