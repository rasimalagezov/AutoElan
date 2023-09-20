namespace AutoAd.Persistence.Features.Commands.Vehicles.Create
{
    public class CreateVehicleCommandResponse
    {
        public object? Result { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = "";
    }
}
