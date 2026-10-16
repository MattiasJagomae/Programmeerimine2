using MediatR;
using Microsoft.EntityFrameworkCore;
using KooliProjekt.Application.Data;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.features.AssetClass
{
    public class GetAssetClassListQueryHandler : IRequestHandler<GetAssetClassListQuery, List<KooliProjekt.Application.Data.AssetClass>>
    {
        private readonly ApplicationDbContext _context;

        public GetAssetClassListQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<KooliProjekt.Application.Data.AssetClass>> Handle(GetAssetClassListQuery request, CancellationToken cancellationToken)
        {
            return await _context.AssetClasses.ToListAsync(cancellationToken);
        }
    }
}
