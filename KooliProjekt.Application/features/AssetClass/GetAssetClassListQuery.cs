using MediatR;
using System.Collections.Generic;

namespace KooliProjekt.Application.features.AssetClass
{
    public class GetAssetClassListQuery : IRequest<List<KooliProjekt.Application.Data.AssetClass>>
    {
    }
}