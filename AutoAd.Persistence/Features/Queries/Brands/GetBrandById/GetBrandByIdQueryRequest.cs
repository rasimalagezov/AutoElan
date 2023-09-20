using MediatR;

namespace AutoAd.Persistence.Features.Queries.Brands.GetBrandById
{
    public class GetBrandByIdQueryRequest : IRequest<GetBrandByIdQueryResponse>
    {
        public int Id { get; set; }
    }
}
