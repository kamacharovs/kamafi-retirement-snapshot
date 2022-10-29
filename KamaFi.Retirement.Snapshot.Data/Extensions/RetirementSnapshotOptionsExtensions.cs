using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace KamaFi.Retirement.Snapshot.Data.Extensions
{
    public static class RetirementSnapshotOptionsExtensions
    {
        public static IConfigurationSection GetConfigSection(
            this IConfiguration configuration, 
            string sectionName)
        {
            var configSection = configuration.GetSection(sectionName);

            if (configSection is null)
            {
                throw new ConfigurationErrorsException($"Configuration {sectionName} is required");
            }

            return configSection;
        }
    }
}
