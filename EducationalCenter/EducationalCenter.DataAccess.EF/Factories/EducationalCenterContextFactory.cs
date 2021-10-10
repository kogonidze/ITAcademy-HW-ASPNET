using System.IO;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace EducationalCenter.DataAccess.EF.Factories
{
    public class EducationalCenterContextFactory : IDesignTimeDbContextFactory<EducationalCenterContext>
    {
        public EducationalCenterContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var dbContextBuilder = new DbContextOptionsBuilder<EducationalCenterContext>();
            var connString = configuration.GetConnectionString("DefaultConnection");
            dbContextBuilder.UseSqlServer(connString);

            var storeOptions = Options.Create(new OperationalStoreOptions());

            return new EducationalCenterContext(dbContextBuilder.Options, storeOptions);
        }
    }
}
