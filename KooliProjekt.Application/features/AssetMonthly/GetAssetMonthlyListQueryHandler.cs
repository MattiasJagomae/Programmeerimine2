using MediatR;
using Microsoft.EntityFrameworkCore;
using KooliProjekt.Application.Data;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.features.AssetMonthly
{
    public class GetAssetMonthlyListQueryHandler : IRequestHandler<GetAssetMonthlyListQuery, List<KooliProjekt.Application.Data.AssetMonthly>>
    {
        private readonly ApplicationDbContext _context;

        public GetAssetMonthlyListQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<KooliProjekt.Application.Data.AssetMonthly>> Handle(GetAssetMonthlyListQuery request, CancellationToken cancellationToken)
        {
            return await _context.AssetMonthlies.ToListAsync(cancellationToken);
        }
    }
}
