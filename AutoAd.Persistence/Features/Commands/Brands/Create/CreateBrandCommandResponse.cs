namespace AutoAd.Persistence.Features.Commands.Brands.Create
{
    public class CreateBrandCommandResponse
    {
        public object? Result { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = "";
    }
}
