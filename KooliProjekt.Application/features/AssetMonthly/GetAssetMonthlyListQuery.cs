using MediatR;
using System.Collections.Generic;

namespace KooliProjekt.Application.features.AssetMonthly
{
    public class GetAssetMonthlyListQuery : IRequest<List<KooliProjekt.Application.Data.AssetMonthly>>
    {
    }
}