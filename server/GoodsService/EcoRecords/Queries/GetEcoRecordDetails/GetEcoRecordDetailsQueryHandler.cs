using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SparkSwim.GoodsService.Exceptions;
using SparkSwim.GoodsService.Goods.Models;
using SparkSwim.GoodsService.Interfaces;

namespace SparkSwim.GoodsService.Products.Queries.GetProduct;

public class GetEcoRecordDetailsQueryHandler : IRequestHandler<GetEcoRecordDetailsQuery, EcoRecordDetailsVm>
{
    private readonly IEcoDbContext _ecoDbContext;
    private readonly IMapper _mapper;

    public GetEcoRecordDetailsQueryHandler(IEcoDbContext dbContext, IMapper mapper)
    {
        _ecoDbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<EcoRecordDetailsVm> Handle(GetEcoRecordDetailsQuery request, CancellationToken cancellationToken)
    {
        var entity =
            await _ecoDbContext.EcoRecords.FirstOrDefaultAsync(_ => _.RecordId == request.RecordId,
                cancellationToken);
        if (entity == null || entity.RecordId != request.RecordId)
        {
            throw new NotFoundException(nameof(EcoRecord), request.RecordId);
        }

        return _mapper.Map<EcoRecordDetailsVm>(entity);
    }
}