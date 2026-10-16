using MediatR;
using System.Collections.Generic;

namespace KooliProjekt.Application.features.Asset
{
    public class GetAssetListQuery : IRequest<List<KooliProjekt.Application.Data.Asset>>
    {
    }
}