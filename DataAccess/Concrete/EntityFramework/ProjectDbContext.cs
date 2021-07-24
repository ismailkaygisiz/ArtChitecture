using Core.DataAccess;
using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class ProjectDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupOperationClaim> GroupOperationClaims { get; set; }

        public DbSet<Language> Languages { get; set; }
        public DbSet<Translate> Translates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(new AppConfiguration().GetConnectionString("MsSql"));
        }
    }
}