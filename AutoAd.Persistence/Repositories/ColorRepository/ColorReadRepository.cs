using AutoAd.Application.Repositories.ColorRepository;
using AutoAd.Domain.Entities;
using AutoAd.Persistence.Contexts;

namespace AutoAd.Persistence.Repositories.ColorRepository
{
    public class ColorReadRepository : ReadRepository<Color>, IColorReadRepository
    {
        public ColorReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
