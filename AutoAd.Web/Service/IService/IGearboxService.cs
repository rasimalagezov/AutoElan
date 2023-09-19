using AutoAd.Web.Models;

namespace AutoAd.Web.Service.IService
{
    public interface IGearboxService
    {
        Task<ResponseDto?> GetGearboxesAsync();
        Task<ResponseDto?> GetGearboxByIdAsync(int id);
        Task<ResponseDto?> CreateGearboxAsync(GearboxDto dto);
        Task<ResponseDto?> UpdateGearboxAsync(GearboxDto dto);
        Task<ResponseDto?> DeleteGearboxAsync(int id);
    }
}
