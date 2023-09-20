namespace AutoAd.Persistence.Features.Commands.Brands.Update
{
    public class UpdateBrandCommandResponse
    {
        public object? Result { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = "";
    }
}
