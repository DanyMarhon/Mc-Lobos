using TPInvOp.Data;
using TPInvOp.Data.Interfaces;
using TPInvOp.Data.Repositories;
using TPInvOp.Service.Interfaces;
using TPInvOp.Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace TPInvOp.Ioc
{
    public static class DI
    {
        public static IServiceProvider ConfigureDI(IServiceCollection services, IConfiguration configuration)
        {

            //Connection bd
            services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("MyConnection"))); //ahora estamos usando la cadena que esta en el json. att Joaquin

            //Categories 
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();

            //Locality 
            services.AddScoped<ILocalityRepository, LocalityRepository>();
            services.AddScoped<ILocalityService, LocalityService>();

            //PaymentMethod 
            services.AddScoped<IPaymentMethodRepository, PaymentMethodRepository>();
            services.AddScoped<IPaymentMethodService, PaymentMethodService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services.BuildServiceProvider();
        }
    }
}
