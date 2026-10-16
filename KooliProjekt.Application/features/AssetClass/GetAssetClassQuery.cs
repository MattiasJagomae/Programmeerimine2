using MediatR;

namespace KooliProjekt.Application.features.AssetClass
{
    public class GetAssetClassQuery : IRequest<KooliProjekt.Application.Data.AssetClass>
    {
        public int Id { get; set; }
    }
}