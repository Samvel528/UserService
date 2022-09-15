namespace UserService.Persistence
{
    public sealed class DbInitializer
    {
        public static void Initialize(UserServiceDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
