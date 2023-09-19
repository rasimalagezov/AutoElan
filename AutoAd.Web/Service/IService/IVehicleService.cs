using AutoAd.Web.Models;

namespace AutoAd.Web.Service.IService
{
    public interface IVehicleService
    {
        Task<ResponseDto?> GetVehiclesAsync();
        Task<ResponseDto?> GetVehicleByIdAsync(int id);
        Task<ResponseDto?> CreateVehicleAsync(VehicleDto dto);
        Task<ResponseDto?> UpdateVehicleAsync(VehicleDto dto);
        Task<ResponseDto?> DeleteVehicleAsync(int id);
    }
}
