namespace AutoAd.Persistence.Features.Commands.Gearboxes.Delete
{
    public class DeleteGearboxCommandResponse
    {
        public object? Result { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = "";
    }
}
