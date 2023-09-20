namespace AutoAd.Persistence.Features.Queries.Vehicles.GetVehicleById
{
    public class GetVehicleByIdQueryResponse
    {
        public object? Result { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = "";
    }
}
