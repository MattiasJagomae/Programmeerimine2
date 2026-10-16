using MediatR;
using Microsoft.EntityFrameworkCore;
using KooliProjekt.Application.Data;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.features.Portfolio
{
    public class GetPortfolioListQueryHandler : IRequestHandler<GetPortfolioListQuery, List<KooliProjekt.Application.Data.Portfolio>>
    {
        private readonly ApplicationDbContext _context;

        public GetPortfolioListQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<KooliProjekt.Application.Data.Portfolio>> Handle(GetPortfolioListQuery request, CancellationToken cancellationToken)
        {
            return await _context.Portfolios.ToListAsync(cancellationToken);
        }
    }
}
