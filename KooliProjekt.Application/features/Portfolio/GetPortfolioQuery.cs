using MediatR;

namespace KooliProjekt.Application.features.Portfolio
{
    public class GetPortfolioQuery : IRequest<KooliProjekt.Application.Data.Portfolio>
    {
        public int Id { get; set; }
    }
}
