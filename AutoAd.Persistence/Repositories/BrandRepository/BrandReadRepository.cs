using AutoAd.Application.Repositories.BrandRepository;
using AutoAd.Domain.Entities;
using AutoAd.Persistence.Contexts;

namespace AutoAd.Persistence.Repositories.BrandRepository
{
    public class BrandReadRepository : ReadRepository<Brand>, IBrandReadRepository
    {
        public BrandReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
