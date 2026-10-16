using MediatR;
using Microsoft.EntityFrameworkCore;
using KooliProjekt.Application.Data;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.features.Asset
{
    public class GetAssetListQueryHandler : IRequestHandler<GetAssetListQuery, List<KooliProjekt.Application.Data.Asset>>
    {
        private readonly ApplicationDbContext _context;

        public GetAssetListQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<KooliProjekt.Application.Data.Asset>> Handle(GetAssetListQuery request, CancellationToken cancellationToken)
        {
            return await _context.Assets.ToListAsync(cancellationToken);
        }
    }
}
