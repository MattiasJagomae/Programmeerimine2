using MediatR;

namespace KooliProjekt.Application.features.CashFlow
{
    public class GetCashFlowQuery : IRequest<KooliProjekt.Application.Data.CashFlow>
    {
        public int Id { get; set; }
    }
}