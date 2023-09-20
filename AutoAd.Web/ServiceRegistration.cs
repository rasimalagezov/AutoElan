using AutoAd.Web.Service;
using AutoAd.Web.Service.IService;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace AutoAd.Web
{
    public static class ServiceRegistration
    {
        public static void AddWebApplicationServices(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<ITokenProvider, TokenProvider>();

            services.AddScoped<IBaseService, BaseService>();

            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IModelService, ModelService>();
            services.AddScoped<IColorService, ColorService>();
            services.AddScoped<IFuelTypeService, FuelTypeService>();
            services.AddScoped<IGearboxService, GearboxService>();
            services.AddScoped<IVehicleTypeService, VehicleTypeService>();

            services.AddScoped<IAuthService, AuthService>();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(option =>
                {
                    option.ExpireTimeSpan = TimeSpan.FromHours(10);
                    option.LoginPath = "/Auth/Login";
                    option.AccessDeniedPath = "/Auth/AccessDenied";
                });
        }
    }
}
