using AutoAd.Web.Models;
using AutoAd.Web.Service.IService;
using AutoAd.Web.Utulity;

namespace AutoAd.Web.Service
{
    public class VehicleTypeService : IVehicleTypeService
    {
        private readonly IBaseService _baseService;

        public VehicleTypeService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> CreateVehicleTypeAsync(VehicleTypeDto dto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = SD.AutoAdAPIBase + "/api/vehicleType"
            });
        }

        public async Task<ResponseDto?> DeleteVehicleTypeAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.AutoAdAPIBase + "/api/vehicleType/" + id
            });
        }

        public async Task<ResponseDto?> GetVehicleTypeByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.AutoAdAPIBase + "/api/vehicleType/" + id
            });
        }

        public async Task<ResponseDto?> GetVehicleTypesAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.AutoAdAPIBase + "/api/vehicleType"
            });
        }

        public async Task<ResponseDto?> UpdateVehicleTypeAsync(VehicleTypeDto dto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = SD.AutoAdAPIBase + "/api/vehicleType"
            });
        }
    }
}
