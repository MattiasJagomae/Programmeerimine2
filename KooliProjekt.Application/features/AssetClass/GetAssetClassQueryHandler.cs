using MediatR;
using Microsoft.EntityFrameworkCore;
using KooliProjekt.Application.Data;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.features.AssetClass
{
    public class GetAssetClassQueryHandler : IRequestHandler<GetAssetClassQuery, KooliProjekt.Application.Data.AssetClass>
    {
        private readonly ApplicationDbContext _context;

        public GetAssetClassQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<KooliProjekt.Application.Data.AssetClass> Handle(GetAssetClassQuery request, CancellationToken cancellationToken)
        {
            return await _context.AssetClasses
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        }
    }
}