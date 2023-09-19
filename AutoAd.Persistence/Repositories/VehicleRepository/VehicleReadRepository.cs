using AutoAd.Application.Repositories.VehicleRepository;
using AutoAd.Domain.Entities;
using AutoAd.Persistence.Contexts;

namespace AutoAd.Persistence.Repositories.VehicleRepository
{
    public class VehicleReadRepository : ReadRepository<Vehicle>, IVehicleReadRepository
    {
        public VehicleReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
