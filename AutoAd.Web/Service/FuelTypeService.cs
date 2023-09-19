using AutoAd.Web.Models;
using AutoAd.Web.Service.IService;
using AutoAd.Web.Utulity;

namespace AutoAd.Web.Service
{
    public class FuelTypeService : IFuelTypeService
    {
        private readonly IBaseService _baseService;

        public FuelTypeService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> CreateFuelTypeAsync(FuelTypeDto dto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = SD.AutoAdAPIBase + "/api/fuelType"
            });
        }

        public async Task<ResponseDto?> DeleteFuelTypeAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.AutoAdAPIBase + "/api/fuelType/" + id
            });
        }

        public async Task<ResponseDto?> GetFuelTypeByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.AutoAdAPIBase + "/api/fuelType/" + id
            });
        }

        public async Task<ResponseDto?> GetFuelTypesAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.AutoAdAPIBase + "/api/fuelType"
            });
        }

        public async Task<ResponseDto?> UpdateFuelTypeAsync(FuelTypeDto dto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = SD.AutoAdAPIBase + "/api/fuelType"
            });
        }
    }
}
