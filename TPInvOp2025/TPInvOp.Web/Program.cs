using FluentValidation;
using FluentValidation.AspNetCore;
using TPInvOp.Ioc;
using TPInvOp.Service.Mappers;
using TPInvOp.Service.Validators;

namespace TPInvOp.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            DI.ConfigureDI(builder.Services, builder.Configuration);

            builder.Services.AddValidatorsFromAssemblyContaining<CategoryValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<LocalityValidator>();
            builder.Services.AddFluentValidationAutoValidation();

            builder.Services.AddAutoMapper(typeof(Program).Assembly);
            builder.Services.AddAutoMapper(typeof(MappingProfileDto).Assembly);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();


            app.Run();
        }
    }
}
