using System.IO;
using Microsoft.Extensions.Configuration;

namespace Core.DataAccess
{
    public class AppConfiguration
    {
        protected string DatabaseConnectionName { get; set; }
        public IConfiguration Configuration { get; set; }

        public AppConfiguration()
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);
            Configuration = configurationBuilder.Build();
        }

        public string GetConnectionString(string databaseConnectionName)
        {
            DatabaseConnectionName = databaseConnectionName;

            string _connectionString = Configuration.GetConnectionString(DatabaseConnectionName);
            return _connectionString;
        }
    }
}