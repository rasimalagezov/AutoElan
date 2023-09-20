namespace AutoAd.Persistence.Features.Queries.Vehicles.GetVehicles
{
    public class GetVehiclesQueryResponse
    {
        public object? Result { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = "";
    }
}
