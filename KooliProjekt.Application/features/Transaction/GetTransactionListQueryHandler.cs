using MediatR;
using Microsoft.EntityFrameworkCore;
using KooliProjekt.Application.Data;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.features.Transaction
{
    public class GetTransactionListQueryHandler : IRequestHandler<GetTransactionListQuery, List<KooliProjekt.Application.Data.Transaction>>
    {
        private readonly ApplicationDbContext _context;

        public GetTransactionListQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<KooliProjekt.Application.Data.Transaction>> Handle(GetTransactionListQuery request, CancellationToken cancellationToken)
        {
            return await _context.Transactions.ToListAsync(cancellationToken);
        }
    }
}