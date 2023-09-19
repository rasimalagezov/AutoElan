using AutoAd.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace AutoAd.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}
