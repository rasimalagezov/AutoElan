using MediatR;

namespace AutoAd.Persistence.Features.Queries.Models.GetModelById
{
    public class GetModelByIdQueryRequest : IRequest<GetModelByIdQueryResponse>
    {
        public int Id { get; set; }
    }
}
