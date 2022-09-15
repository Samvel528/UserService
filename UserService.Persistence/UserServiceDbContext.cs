using Microsoft.EntityFrameworkCore;
using UserService.Application.Interfaces;
using UserService.Domain;
using UserService.Persistence.EntityTypeConfiguration;

namespace UserService.Persistence
{
    public sealed class UserServiceDbContext : DbContext, IUserServiceDbContext
    {
        public DbSet<User> Users { get; set; }
        public UserServiceDbContext(DbContextOptions<UserServiceDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserServiceConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
