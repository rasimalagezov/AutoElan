using AutoAd.Application.Repositories.GearboxRepository;
using AutoAd.Domain.Entities;
using AutoAd.Persistence.Contexts;

namespace AutoAd.Persistence.Repositories.GearboxRepository
{
    public class GearboxWriteRepository : WriteRepository<Gearbox>, IGearboxWriteRepository
    {
        public GearboxWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
