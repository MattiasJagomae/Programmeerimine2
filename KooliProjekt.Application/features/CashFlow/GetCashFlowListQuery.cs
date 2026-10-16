using MediatR;
using System.Collections.Generic;

namespace KooliProjekt.Application.features.CashFlow
{
    public class GetCashFlowListQuery : IRequest<List<KooliProjekt.Application.Data.CashFlow>>
    {
    }
}
