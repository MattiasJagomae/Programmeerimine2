using MediatR;
using Microsoft.EntityFrameworkCore;
using KooliProjekt.Application.Data;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.features.Portfolio
{
    public class GetPortfolioQueryHandler : IRequestHandler<GetPortfolioQuery, KooliProjekt.Application.Data.Portfolio>
    {
        private readonly ApplicationDbContext _context;

        public GetPortfolioQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<KooliProjekt.Application.Data.Portfolio> Handle(GetPortfolioQuery request, CancellationToken cancellationToken)
        {
            return await _context.Portfolios
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        }
    }
}