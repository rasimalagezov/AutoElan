namespace AutoAd.Persistence.Features.Commands.VehicleTypes.Delete
{
    public class DeleteVehicleTypeCommandResponse
    {
        public object? Result { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = "";
    }
}
