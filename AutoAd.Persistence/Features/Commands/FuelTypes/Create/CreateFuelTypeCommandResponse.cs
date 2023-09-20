namespace AutoAd.Persistence.Features.Commands.FuelTypes.Create
{
    public class CreateFuelTypeCommandResponse
    {
        public object? Result { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = "";
    }
}
