using MediatR;

namespace KooliProjekt.Application.features.AssetMonthly
{
    public class GetAssetMonthlyQuery : IRequest<KooliProjekt.Application.Data.AssetMonthly>
    {
        public int Id { get; set; }
    }
}