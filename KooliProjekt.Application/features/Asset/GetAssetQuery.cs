using MediatR;

namespace KooliProjekt.Application.features.Asset
{
    public class GetAssetQuery : IRequest<KooliProjekt.Application.Data.Asset>
    {
        public int Id { get; set; }
    }
}