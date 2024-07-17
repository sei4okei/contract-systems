using Microsoft.EntityFrameworkCore;
using DataAccess.Context;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using BusinessLogic.Interfaces;
using BusinessLogic.Services;

namespace ContractSystems
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<PasswordContext>(options =>
                options.UseInMemoryDatabase(Guid.NewGuid().ToString()));

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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Password}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
