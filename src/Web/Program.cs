using Application.Interfaces;
using Application.Mapper;
using Application.Services;
using Core.Repositories.Base;
using Core.Specifications.Base;
using Infrastructure.Data;
using Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AppDbContext>
                (options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddRazorPages();

            builder.Services.AddAutoMapper(typeof(DtoProfile));
            builder.Services.AddScoped<IAddressSevice, AddressSevice>();
            builder.Services.AddScoped<IGroupService, GroupService>();
            builder.Services.AddScoped<IScheduleService, ScheduleService>();
            builder.Services.AddScoped<IImportService, ImportService>();
            builder.Services.AddScoped<ISpecificationEvaluator, SpecificationEvaluator>();
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            var app = builder.Build();
            await app.Services.MigrateDatabaseAsync();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            await app.RunAsync();
        }
    }
}
