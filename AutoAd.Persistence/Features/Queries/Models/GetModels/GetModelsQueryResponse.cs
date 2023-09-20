namespace AutoAd.Persistence.Features.Queries.Models.GetModels
{
    public class GetModelsQueryResponse
    {
        public object? Result { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = "";
    }
}
