namespace AutoAd.Persistence.Features.Commands.Models.Delete
{
    public class DeleteModelCommandResponse
    {
        public object? Result { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = "";
    }
}
