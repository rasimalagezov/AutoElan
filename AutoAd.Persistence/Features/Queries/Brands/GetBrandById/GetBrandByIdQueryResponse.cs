namespace AutoAd.Persistence.Features.Queries.Brands.GetBrandById
{
    public class GetBrandByIdQueryResponse
    {
        public object? Result { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = "";
    }
}
