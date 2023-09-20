namespace AutoAd.Persistence.Features.Queries.Models.GetModelById
{
    public class GetModelByIdQueryResponse
    {
        public object? Result { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = "";
    }
}
