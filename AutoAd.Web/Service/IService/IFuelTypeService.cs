using AutoAd.Web.Models;

namespace AutoAd.Web.Service.IService
{
    public interface IFuelTypeService
    {
        Task<ResponseDto?> GetFuelTypesAsync();
        Task<ResponseDto?> GetFuelTypeByIdAsync(int id);
        Task<ResponseDto?> CreateFuelTypeAsync(FuelTypeDto dto);
        Task<ResponseDto?> UpdateFuelTypeAsync(FuelTypeDto dto);
        Task<ResponseDto?> DeleteFuelTypeAsync(int id);
    }
}
