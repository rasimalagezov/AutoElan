using AutoAd.Application.Repositories.FuelTypeRepository;
using AutoAd.Domain.Entities;
using AutoAd.Persistence.Contexts;

namespace AutoAd.Persistence.Repositories.FuelTypeRepository
{
    public class FuelTypeReadRepository : ReadRepository<FuelType>, IFuelTypeReadRepository
    {
        public FuelTypeReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
