using MediatR;

namespace AutoAd.Persistence.Features.Queries.VehicleTypes.GetVehicleTypeById
{
    public class GetVehicleTypeByIdQueryRequest : IRequest<GetVehicleTypeByIdQueryResponse>
    {
        public int Id { get; set; }
    }
}
