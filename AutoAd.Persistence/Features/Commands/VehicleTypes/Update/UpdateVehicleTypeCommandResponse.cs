namespace AutoAd.Persistence.Features.Commands.VehicleTypes.Update
{
    public class UpdateVehicleTypeCommandResponse
    {
        public object? Result { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = "";
    }
}
