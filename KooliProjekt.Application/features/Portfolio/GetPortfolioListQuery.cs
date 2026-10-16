using MediatR;
using System.Collections.Generic;

namespace KooliProjekt.Application.features.Portfolio
{
    public class GetPortfolioListQuery : IRequest<List<KooliProjekt.Application.Data.Portfolio>>
    {
    }
}