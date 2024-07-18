using Microsoft.EntityFrameworkCore;
using DataAccess.Context;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using Microsoft.Extensions.Options;

namespace ContractSystems
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);

            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration
                .GetConnectionString("DefaultConnection");
            var options = new DbContextOptionsBuilder<PasswordContext>()
                .UseNpgsql(connectionString).Options;
            builder.Services.AddDbContext<PasswordContext>(options =>
                options.UseNpgsql(connectionString));

            builder.Services.AddScoped<IRecordRepository, RecordRepository>();

            builder.Services.AddScoped<IRecordService, RecordService>();

            builder.Services.AddControllersWithViews();

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

            using (PasswordContext db = new PasswordContext(options))
            {
                await db.Database.MigrateAsync();
            }

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Password}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
