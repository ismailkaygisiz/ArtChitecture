using Core.Entities.Concrete;
using Core.Utilities.IoC;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Concrete.EntityFramework
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext()
        {
            Configuration = ServiceTool.ServiceProvider.GetService<IConfiguration>();
        }

        protected IConfiguration Configuration { get; }

        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public DbSet<Language> Languages { get; set; }
        public DbSet<Translate> Translates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString(Configuration.GetConnectionString("CurrentDB")));
        }
    }
}