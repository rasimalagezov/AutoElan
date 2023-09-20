namespace AutoAd.Persistence.Features.Commands.FuelTypes.Delete
{
    public class DeleteFuelTypeCommandResponse
    {
        public object? Result { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = "";
    }
}
