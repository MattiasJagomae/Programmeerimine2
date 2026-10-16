using MediatR;
using Microsoft.EntityFrameworkCore;
using KooliProjekt.Application.Data;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.features.Transaction
{
    public class GetTransactionQueryHandler : IRequestHandler<GetTransactionQuery, KooliProjekt.Application.Data.Transaction>
    {
        private readonly ApplicationDbContext _context;

        public GetTransactionQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<KooliProjekt.Application.Data.Transaction> Handle(GetTransactionQuery request, CancellationToken cancellationToken)
        {
            return await _context.Transactions
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        }
    }
}
