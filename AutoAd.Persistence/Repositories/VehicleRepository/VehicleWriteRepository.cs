using AutoAd.Application.Repositories.VehicleRepository;
using AutoAd.Domain.Entities;
using AutoAd.Persistence.Contexts;

namespace AutoAd.Persistence.Repositories.VehicleRepository
{
    public class VehicleWriteRepository : WriteRepository<Vehicle>, IVehicleWriteRepository
    {
        public VehicleWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
