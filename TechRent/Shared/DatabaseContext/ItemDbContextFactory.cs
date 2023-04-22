using Microsoft.EntityFrameworkCore;

namespace TechRent.Shared.DatabaseContext
{
    public class ItemDbContextFactory
    {
        private readonly DbContextOptions _options;

        public ItemDbContextFactory(DbContextOptions options)
        {
            _options = options;
        }

        public ItemDbContext Create()
        {
            return new ItemDbContext(_options);
        }
    }
}
