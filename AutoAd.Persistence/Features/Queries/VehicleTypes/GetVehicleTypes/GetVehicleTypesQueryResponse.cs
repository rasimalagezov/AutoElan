namespace AutoAd.Persistence.Features.Queries.VehicleTypes.GetVehicleTypes
{
    public class GetVehicleTypesQueryResponse
    {
        public object? Result { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = "";
    }
}
