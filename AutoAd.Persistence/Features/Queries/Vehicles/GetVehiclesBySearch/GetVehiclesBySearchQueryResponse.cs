namespace AutoAd.Persistence.Features.Queries.Vehicles.GetVehiclesBySearch
{
    public class GetVehiclesBySearchQueryResponse
    {
        public object? Result { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = "";
    }
}
