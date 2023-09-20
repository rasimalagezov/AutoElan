namespace AutoAd.Persistence.Features.Commands.Models.Create
{
    public class CreateModelCommandResponse
    {
        public object? Result { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = "";
    }
}
