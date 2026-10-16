using MediatR;

namespace KooliProjekt.Application.features.Transaction
{
    public class GetTransactionQuery : IRequest<KooliProjekt.Application.Data.Transaction>
    {
        public int Id { get; set; }
    }
}