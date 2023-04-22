using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TechRent.Shared.DatabaseContext;

namespace TechRent.Extensions
{
    public static class AddDbContextHostBuilderExtension
    {
        public static IHostBuilder AddDbContext(this IHostBuilder hostBuilder)
        {
            _ = hostBuilder.ConfigureServices((context, services) =>
            {
                string? connectionString = context.Configuration.GetConnectionString("sqlite");

                services.AddSingleton(new DbContextOptionsBuilder().UseSqlite("Data Source = TechRent.db").Options);
                services.AddSingleton<ItemDbContextFactory>();
            });

            return hostBuilder;
        }
    }
}
