using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public static class AppIdentityDbContextSeeded
    {
        public static async Task MigrateDatabaseAsync(this IServiceProvider provider)
        {
            using (var scope = provider.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<AppDbContext>();
                await context.Database.MigrateAsync();
            }
        }
    }
}
