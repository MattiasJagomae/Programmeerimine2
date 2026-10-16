using MediatR;
using Microsoft.EntityFrameworkCore;
using KooliProjekt.Application.Data;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.features.AssetMonthly
{
    public class GetAssetMonthlyQueryHandler : IRequestHandler<GetAssetMonthlyQuery, KooliProjekt.Application.Data.AssetMonthly>
    {
        private readonly ApplicationDbContext _context;

        public GetAssetMonthlyQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<KooliProjekt.Application.Data.AssetMonthly> Handle(GetAssetMonthlyQuery request, CancellationToken cancellationToken)
        {
            return await _context.AssetMonthlies
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        }
    }
}
