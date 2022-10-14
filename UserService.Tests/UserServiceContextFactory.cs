using Microsoft.EntityFrameworkCore;
using System;
using UserService.Persistence;

namespace UserService.Tests
{
    public class UserServiceContextFactory
    {
        public static Guid UserAId = Guid.NewGuid();
        public static Guid UserBId = Guid.NewGuid();

        public static UserServiceDbContext Create()
        {
            var options = new DbContextOptionsBuilder<UserServiceDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new UserServiceDbContext(options);
            context.Database.EnsureCreated();
        }
    }
}
