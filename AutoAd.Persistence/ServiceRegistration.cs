using AutoAd.Application.Repositories.BrandRepository;
using AutoAd.Application.Repositories.ColorRepository;
using AutoAd.Application.Repositories.FuelTypeRepository;
using AutoAd.Application.Repositories.GearboxRepository;
using AutoAd.Application.Repositories.ModelRepository;
using AutoAd.Application.Repositories.VehicleRepository;
using AutoAd.Application.Repositories.VehicleTypeRepository;
using AutoAd.Application.Service;
using AutoAd.Persistence.Contexts;
using AutoAd.Persistence.Repositories.BrandRepository;
using AutoAd.Persistence.Repositories.ColorRepository;
using AutoAd.Persistence.Repositories.FuelTypeRepository;
using AutoAd.Persistence.Repositories.GearboxRepository;
using AutoAd.Persistence.Repositories.ModelRepository;
using AutoAd.Persistence.Repositories.VehicleRepository;
using AutoAd.Persistence.Repositories.VehicleTypeRepository;
using AutoAd.Persistence.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AutoAd.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(option => option.UseSqlServer(Configuration.ConnectionString));

            services.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(ServiceRegistration).Assembly));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

            services.AddScoped<IVehicleReadRepository, VehicleReadRepository>();
            services.AddScoped<IVehicleWriteRepository, VehicleWriteRepository>();

            services.AddScoped<IBrandReadRepository, BrandReadRepository>();
            services.AddScoped<IBrandWriteRepository, BrandWriteRepository>();

            services.AddScoped<IModelReadRepository, ModelReadRepository>();
            services.AddScoped<IModelWriteRepository, ModelWriteRepository>();

            services.AddScoped<IColorReadRepository, ColorReadRepository>();
            services.AddScoped<IColorWriteRepository, ColorWriteRepository>();

            services.AddScoped<IFuelTypeReadRepository, FuelTypeReadRepository>();
            services.AddScoped<IFuelTypeWriteRepository, FuelTypeWriteRepository>();

            services.AddScoped<IGearboxReadRepository, GearboxReadRepository>();
            services.AddScoped<IGearboxWriteRepository, GearboxWriteRepository>();

            services.AddScoped<IVehicleTypeReadRepository, VehicleTypeReadRepository>();
            services.AddScoped<IVehicleTypeWriteRepository, VehicleTypeWriteRepository>();
        }
    }
}
