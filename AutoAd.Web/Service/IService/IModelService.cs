using AutoAd.Web.Models;

namespace AutoAd.Web.Service.IService
{
    public interface IModelService
    {
        Task<ResponseDto?> GetModelsAsync();
        Task<ResponseDto?> GetModelsByBrandIdAsync(int brandId);
        Task<ResponseDto?> GetModelByIdAsync(int id);
        Task<ResponseDto?> CreateModelAsync(ModelDto dto);
        Task<ResponseDto?> UpdateModelAsync(ModelDto dto);
        Task<ResponseDto?> DeleteModelAsync(int id);
    }
}
