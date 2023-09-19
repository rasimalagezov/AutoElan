using AutoAd.Application.Repositories.FuelTypeRepository;
using AutoAd.Domain.Entities;
using AutoAd.Persistence.Contexts;

namespace AutoAd.Persistence.Repositories.FuelTypeRepository
{
    public class FuelTypeWriteRepository : WriteRepository<FuelType>, IFuelTypeWriteRepository
    {
        public FuelTypeWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
