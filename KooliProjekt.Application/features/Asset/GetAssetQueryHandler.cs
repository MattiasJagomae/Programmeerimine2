using MediatR;
using Microsoft.EntityFrameworkCore;
using KooliProjekt.Application.Data;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.features.Asset
{
    public class GetAssetQueryHandler : IRequestHandler<GetAssetQuery, KooliProjekt.Application.Data.Asset>
    {
        private readonly ApplicationDbContext _context;

        public GetAssetQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<KooliProjekt.Application.Data.Asset> Handle(GetAssetQuery request, CancellationToken cancellationToken)
        {
            return await _context.Assets
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        }
    }
}
