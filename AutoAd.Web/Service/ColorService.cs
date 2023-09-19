using AutoAd.Web.Models;
using AutoAd.Web.Service.IService;
using AutoAd.Web.Utulity;

namespace AutoAd.Web.Service
{
    public class ColorService : IColorService
    {
        private readonly IBaseService _baseService;

        public ColorService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> CreateColorAsync(ColorDto dto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = SD.AutoAdAPIBase + "/api/color"
            });
        }

        public async Task<ResponseDto?> DeleteColorAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.AutoAdAPIBase + "/api/color/" + id
            });
        }

        public async Task<ResponseDto?> GetColorByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.AutoAdAPIBase + "/api/color/" + id
            });
        }

        public async Task<ResponseDto?> GetColorsAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.AutoAdAPIBase + "/api/color"
            });
        }

        public async Task<ResponseDto?> UpdateColorAsync(ColorDto dto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = SD.AutoAdAPIBase + "/api/color"
            });
        }
    }
}
