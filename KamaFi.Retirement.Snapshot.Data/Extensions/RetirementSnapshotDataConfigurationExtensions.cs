using KamaFi.Retirement.Snapshot.Data.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace KamaFi.Retirement.Snapshot.Data.Extensions
{
    public static class RetirementSnapshotDataConfigurationExtensions
    {
        public static IServiceCollection AddDataConfiguration(
            this IServiceCollection services, 
            IConfiguration config)
        {
            var configSection = config.GetConfigSection(RetirementSnapshotOptions.Section);
            var options = configSection.Get<RetirementSnapshotOptions>();

            services.AddDbContext<RetirementSnapshotDbContext>(o =>
                o.UseLazyLoadingProxies()
                    .UseNpgsql(options.ConnectionString,
                    no =>
                    {
                        no.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                        no.MigrationsAssembly("KamaFi.Retirement.Snapshot.Data.Migrations");
                    }));

            return services;
        }
    }
}
