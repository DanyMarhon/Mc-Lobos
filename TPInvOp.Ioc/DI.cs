using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TPInvOp.Data;
using TPInvOp.Service.Interfaces;
using TPInvOp.Service.Services;

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
            services.AddScoped<ICategoryService, CategoryService>();

            //Locality 
            services.AddScoped<ILocalityService, LocalityService>();

            //PaymentMethod 
            services.AddScoped<IPaymentMethodService, PaymentMethodService>();
            
            //Product
            services.AddScoped<IProductService, ProductService>();

            //Employee
            services.AddScoped<IEmployeeService, EmployeeService>();

            //Customer
            services.AddScoped<ICustomerService, CustomerService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            // Los repos de acá volaron porque ahora se instancian desde el UnitOfWork -Dany
            return services.BuildServiceProvider();
        }
    }
}
