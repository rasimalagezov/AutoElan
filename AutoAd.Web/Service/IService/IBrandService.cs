using AutoAd.Web.Models;

namespace AutoAd.Web.Service.IService
{
    public interface IBrandService
    {
        Task<ResponseDto?> GetBrandsAsync();
        Task<ResponseDto?> GetBrandByIdAsync(int id);
        Task<ResponseDto?> CreateBrandAsync(BrandDto dto);
        Task<ResponseDto?> UpdateBrandAsync(BrandDto dto);
        Task<ResponseDto?> DeleteBrandAsync(int id);
    }
}
