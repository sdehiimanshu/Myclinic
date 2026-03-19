using Microsoft.AspNetCore.Identity;
using MyClinic.Application.Interfaces;
using MyClinic.Application.Services;
using MyClinic.Infrastructure;
using MyClinic.Infrastructure.Data;
using MyClinic.Web.Data;

namespace MyClinic.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddInfrastructure(builder.Configuration);
            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<MyClinicDbContext>()
            .AddDefaultTokenProviders();


            builder.Services.AddScoped<IAppointmentService, AppointmentService>();
            builder.Services.AddScoped<IContactQueryService, ContactQueryService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                IdentitySeed.SeedAdminAsync(services).GetAwaiter().GetResult();
            }

            app.Run();
        }
    }
}
