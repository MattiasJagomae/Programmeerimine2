using MediatR;
using System.Collections.Generic;

namespace KooliProjekt.Application.features.Transaction
{
    public class GetTransactionListQuery : IRequest<List<KooliProjekt.Application.Data.Transaction>>
    {
    }
}