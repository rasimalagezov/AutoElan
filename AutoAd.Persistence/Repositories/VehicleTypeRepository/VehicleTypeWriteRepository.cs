using AutoAd.Application.Repositories.VehicleTypeRepository;
using AutoAd.Domain.Entities;
using AutoAd.Persistence.Contexts;

namespace AutoAd.Persistence.Repositories.VehicleTypeRepository
{
    public class VehicleTypeWriteRepository : WriteRepository<VehicleType>, IVehicleTypeWriteRepository
    {
        public VehicleTypeWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
