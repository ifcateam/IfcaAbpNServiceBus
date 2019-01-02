using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace quarrierAbpMvcApp.EntityFrameworkCore
{
    public class quarrierAbpMvcAppDbContextFactory : IDesignTimeDbContextFactory<quarrierAbpMvcAppDbContext>
    {
        public quarrierAbpMvcAppDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<quarrierAbpMvcAppDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new quarrierAbpMvcAppDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../quarrierAbpMvcApp.Web/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
