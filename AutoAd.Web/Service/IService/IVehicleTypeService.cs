using AutoAd.Web.Models;

namespace AutoAd.Web.Service.IService
{
    public interface IVehicleTypeService
    {
        Task<ResponseDto?> GetVehicleTypesAsync();
        Task<ResponseDto?> GetVehicleTypeByIdAsync(int id);
        Task<ResponseDto?> CreateVehicleTypeAsync(VehicleTypeDto dto);
        Task<ResponseDto?> UpdateVehicleTypeAsync(VehicleTypeDto dto);
        Task<ResponseDto?> DeleteVehicleTypeAsync(int id);
    }
}
