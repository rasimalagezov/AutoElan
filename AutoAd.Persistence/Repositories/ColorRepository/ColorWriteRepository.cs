using AutoAd.Application.Repositories.ColorRepository;
using AutoAd.Domain.Entities;
using AutoAd.Persistence.Contexts;

namespace AutoAd.Persistence.Repositories.ColorRepository
{
    public class ColorWriteRepository : WriteRepository<Color>, IColorWriteRepository
    {
        public ColorWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
