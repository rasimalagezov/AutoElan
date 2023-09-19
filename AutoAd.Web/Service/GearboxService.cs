using AutoAd.Web.Models;
using AutoAd.Web.Service.IService;
using AutoAd.Web.Utulity;

namespace AutoAd.Web.Service
{
    public class GearboxService : IGearboxService
    {
        private readonly IBaseService _baseService;

        public GearboxService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> CreateGearboxAsync(GearboxDto dto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = SD.AutoAdAPIBase + "/api/gearbox"
            });
        }

        public async Task<ResponseDto?> DeleteGearboxAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.AutoAdAPIBase + "/api/gearbox/" + id
            });
        }

        public async Task<ResponseDto?> GetGearboxByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.AutoAdAPIBase + "/api/gearbox/" + id
            });
        }

        public async Task<ResponseDto?> GetGearboxesAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.AutoAdAPIBase + "/api/gearbox"
            });
        }

        public async Task<ResponseDto?> UpdateGearboxAsync(GearboxDto dto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = SD.AutoAdAPIBase + "/api/gearbox"
            });
        }
    }
}
