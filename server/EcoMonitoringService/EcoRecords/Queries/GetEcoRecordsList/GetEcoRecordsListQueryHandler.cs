using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SparkSwim.GoodsService.Goods.Models;
using SparkSwim.GoodsService.Interfaces;
using SparkSwim.GoodsService.Products.Queries.GetProduct;
using System.Linq; // Add System.Linq for LINQ
using System.Threading;
using System.Threading.Tasks;

namespace SparkSwim.GoodsService.Products.Queries.GetProductList
{
    public class GetEcoRecordsListQueryHandler : IRequestHandler<GetEcoRecordsListQuery, EcoRecordsListVm>
    {
        private readonly IEcoDbContext _ecoDbContext;
        private readonly IMapper _mapper;

        public GetEcoRecordsListQueryHandler(IEcoDbContext dbContext, IMapper mapper)
        {
            _ecoDbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<EcoRecordsListVm> Handle(GetEcoRecordsListQuery request, CancellationToken cancellationToken)
        {
            var ecoRecords = await _ecoDbContext.EcoRecords
                .OrderBy(e => e.CreationDate) // Sort by CreationDate in ascending order
                .ProjectTo<EcoRecordsLookUpDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            Console.WriteLine(ecoRecords);
            return new EcoRecordsListVm { EcoRecords = ecoRecords };
        }
    }
}