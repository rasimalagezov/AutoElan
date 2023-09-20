using AutoAd.Application.Repositories.VehicleRepository;
using AutoAd.Domain.Entities;
using AutoAd.Persistence.Contexts;
using Microsoft.AspNetCore.Http;

namespace AutoAd.Persistence.Repositories.VehicleRepository
{
    public class VehicleWriteRepository : WriteRepository<Vehicle>, IVehicleWriteRepository
    {
        public VehicleWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
