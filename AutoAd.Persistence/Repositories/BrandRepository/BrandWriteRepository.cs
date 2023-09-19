using AutoAd.Application.Repositories.BrandRepository;
using AutoAd.Domain.Entities;
using AutoAd.Persistence.Contexts;

namespace AutoAd.Persistence.Repositories.BrandRepository
{
    public class BrandWriteRepository : WriteRepository<Brand>, IBrandWriteRepository
    {
        public BrandWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
