using AutoAd.Application.Repositories.ModelRepository;
using AutoAd.Domain.Entities;
using AutoAd.Persistence.Contexts;

namespace AutoAd.Persistence.Repositories.ModelRepository
{
    public class ModelWriteRepository : WriteRepository<Model>, IModelWriteRepository
    { 
        public ModelWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
