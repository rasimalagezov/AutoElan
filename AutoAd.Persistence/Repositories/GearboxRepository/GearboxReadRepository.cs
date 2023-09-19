using AutoAd.Application.Repositories.GearboxRepository;
using AutoAd.Domain.Entities;
using AutoAd.Persistence.Contexts;

namespace AutoAd.Persistence.Repositories.GearboxRepository
{
    public class GearboxReadRepository : ReadRepository<Gearbox>, IGearboxReadRepository
    {
        public GearboxReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
