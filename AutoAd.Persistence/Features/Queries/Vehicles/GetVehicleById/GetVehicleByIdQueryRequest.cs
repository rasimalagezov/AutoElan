using MediatR;

namespace AutoAd.Persistence.Features.Queries.Vehicles.GetVehicleById
{
    public class GetVehicleByIdQueryRequest : IRequest<GetVehicleByIdQueryResponse>
    {
        public int Id { get; set; }
    }
}
