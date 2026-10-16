using MediatR;
using Microsoft.EntityFrameworkCore;
using KooliProjekt.Application.Data;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.features.CashFlow
{
    public class GetCashFlowQueryHandler : IRequestHandler<GetCashFlowQuery, KooliProjekt.Application.Data.CashFlow>
    {
        private readonly ApplicationDbContext _context;

        public GetCashFlowQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<KooliProjekt.Application.Data.CashFlow> Handle(GetCashFlowQuery request, CancellationToken cancellationToken)
        {
            return await _context.CashFlows
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        }
    }
}