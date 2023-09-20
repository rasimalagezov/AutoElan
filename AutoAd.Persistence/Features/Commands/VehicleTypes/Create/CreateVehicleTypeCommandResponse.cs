namespace AutoAd.Persistence.Features.Commands.VehicleTypes.Create
{
    public class CreateVehicleTypeCommandResponse
    {
        public object? Result { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = "";
    }
}
