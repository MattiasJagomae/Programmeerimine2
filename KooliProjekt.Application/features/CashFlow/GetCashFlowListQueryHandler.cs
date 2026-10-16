using MediatR;
using Microsoft.EntityFrameworkCore;
using KooliProjekt.Application.Data;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.features.CashFlow
{
    public class GetCashFlowListQueryHandler : IRequestHandler<GetCashFlowListQuery, List<KooliProjekt.Application.Data.CashFlow>>
    {
        private readonly ApplicationDbContext _context;

        public GetCashFlowListQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<KooliProjekt.Application.Data.CashFlow>> Handle(GetCashFlowListQuery request, CancellationToken cancellationToken)
        {
            return await _context.CashFlows.ToListAsync(cancellationToken);
        }
    }
}
