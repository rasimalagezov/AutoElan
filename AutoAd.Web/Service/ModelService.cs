using AutoAd.Web.Models;
using AutoAd.Web.Service.IService;
using AutoAd.Web.Utulity;

namespace AutoAd.Web.Service
{
    public class ModelService : IModelService
    {
        private readonly IBaseService _baseService;

        public ModelService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> CreateModelAsync(ModelDto dto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = SD.AutoAdAPIBase + "/api/model"
            });
        }

        public async Task<ResponseDto?> DeleteModelAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.AutoAdAPIBase + "/api/model/" + id
            });
        }

        public async Task<ResponseDto?> GetModelByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.AutoAdAPIBase + "/api/model/" + id
            });
        }

        public async Task<ResponseDto?> GetModelsAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.AutoAdAPIBase + "/api/model"
            });
        }

        public async Task<ResponseDto?> GetModelsByBrandIdAsync(int brandId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.AutoAdAPIBase + "/api/model/brandId/" + brandId
            });
        }

        public async Task<ResponseDto?> UpdateModelAsync(ModelDto dto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = SD.AutoAdAPIBase + "/api/model"
            });
        }
    }
}
