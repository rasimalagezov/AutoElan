using AutoAd.Application.Repositories.VehicleTypeRepository;
using AutoAd.Domain.Entities;
using AutoAd.Persistence.Contexts;

namespace AutoAd.Persistence.Repositories.VehicleTypeRepository
{
    public class VehicleTypeReadRepository : ReadRepository<VehicleType>, IVehicleTypeReadRepository
    {
        public VehicleTypeReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
