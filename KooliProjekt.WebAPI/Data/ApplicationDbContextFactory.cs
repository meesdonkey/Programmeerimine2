using System.IO;
using KooliProjekt.Application.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace KooliProjekt.WebAPI.Data
{
    /// <summary>
    /// Lubab Package Manager Console käskudel Add-Migration ja Update-Database
    /// luua andmebaasikonteksti ilma, et rakendus käivituks.
    /// </summary>
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var basePath = Directory.GetCurrentDirectory();
            if (!File.Exists(Path.Combine(basePath, "appsettings.json")))
            {
                var webApiPath = Path.Combine(basePath, "KooliProjekt.WebAPI");
                if (File.Exists(Path.Combine(webApiPath, "appsettings.json")))
                {
                    basePath = webApiPath;
                }
            }

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
