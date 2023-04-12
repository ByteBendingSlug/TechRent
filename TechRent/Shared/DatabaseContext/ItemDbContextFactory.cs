using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
