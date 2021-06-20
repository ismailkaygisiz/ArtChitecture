using System.IO;
using Microsoft.Extensions.Configuration;

namespace Core.DataAccess
{
    public class AppConfiguration
    {
        private readonly string _connectionString;

        public AppConfiguration(string databaseConnectionName)
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);

            var root = configurationBuilder.Build();
            _connectionString = root.GetSection("ConnectionStrings")
                .GetSection(databaseConnectionName.ToString()).Value;
            _ = root.GetSection("ApplicationSettings");
        }

        public string GetConnectionString()
        {
            return _connectionString;
        }
    }
}
