using AutoAd.Application.Repositories.ModelRepository;
using AutoAd.Domain.Entities;
using AutoAd.Persistence.Contexts;

namespace AutoAd.Persistence.Repositories.ModelRepository
{
    public class ModelReadRepository : ReadRepository<Model>, IModelReadRepository
    {
        public ModelReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
