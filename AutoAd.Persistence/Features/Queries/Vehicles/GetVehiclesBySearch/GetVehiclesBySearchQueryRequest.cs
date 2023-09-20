using MediatR;

namespace AutoAd.Persistence.Features.Queries.Vehicles.GetVehiclesBySearch
{
    public class GetVehiclesBySearchQueryRequest : IRequest<GetVehiclesBySearchQueryResponse>
    {
        public string? BrandName { get; set; } 
        public string? ModelName { get; set; }
        public int? MinProductionYear { get; set; }
        public int? MaxProductionYear { get; set; }
        public long? MinPrice { get; set; }
        public long? MaxPrice { get; set; }
    }
}
