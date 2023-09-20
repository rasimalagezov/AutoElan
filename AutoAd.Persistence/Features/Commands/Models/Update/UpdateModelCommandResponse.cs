namespace AutoAd.Persistence.Features.Commands.Models.Update
{
    public class UpdateModelCommandResponse
    {
        public object? Result { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = "";
    }
}
