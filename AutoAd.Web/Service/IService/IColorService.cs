using AutoAd.Web.Models;

namespace AutoAd.Web.Service.IService
{
    public interface IColorService
    {
        Task<ResponseDto?> GetColorsAsync();
        Task<ResponseDto?> GetColorByIdAsync(int id);
        Task<ResponseDto?> CreateColorAsync(ColorDto dto);
        Task<ResponseDto?> UpdateColorAsync(ColorDto dto);
        Task<ResponseDto?> DeleteColorAsync(int id);
    }
}
