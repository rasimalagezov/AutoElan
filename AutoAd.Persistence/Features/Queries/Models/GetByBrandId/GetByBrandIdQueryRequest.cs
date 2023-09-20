using MediatR;

namespace AutoAd.Persistence.Features.Queries.Models.GetByBrandId
{
    public class GetByBrandIdQueryRequest : IRequest<GetByBrandIdQueryResponse>
    {
        public int Id { get; set; }
    }
}
