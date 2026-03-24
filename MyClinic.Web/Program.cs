using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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


        // Add services
        builder.Services.AddControllersWithViews();

            // Infrastructure + DB
            builder.Services.AddInfrastructure(builder.Configuration);

            builder.Services.AddDbContext<MyClinicDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection"),
                    sqlOptions => sqlOptions.EnableRetryOnFailure()
                ));

            // Identity
            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<MyClinicDbContext>()
                .AddDefaultTokenProviders();

            // Custom Services
            builder.Services.AddScoped<IAppointmentService, AppointmentService>();
            builder.Services.AddScoped<IContactQueryService, ContactQueryService>();

            var app = builder.Build();

            // Configure pipeline
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
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

            // ? SAFE Migration + Seeding (Production Ready)
            using (var scope = app.Services.CreateScope())
            {
                try
                {
                    var db = scope.ServiceProvider.GetRequiredService<MyClinicDbContext>();
                    db.Database.Migrate();

                    var services = scope.ServiceProvider;
                    IdentitySeed.SeedAdminAsync(services).GetAwaiter().GetResult();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Migration/Seeding error: " + ex.Message);
                }
            }

            app.Run();
        }
    }


}
