namespace AutoAd.Persistence.Features.Queries.Brands.GetBrands
{
    public class GetBrandsQueryResponse
    {
        public object? Result { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = "";
    }
}
