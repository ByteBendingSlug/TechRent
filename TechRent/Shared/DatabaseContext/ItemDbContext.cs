using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechRent.Shared.DTOs;

namespace TechRent.Shared.DatabaseContext
{
    public class ItemDbContext : DbContext, IAsyncDisposable
    {
        public ItemDbContext(DbContextOptions options) : base(options) { }

        public DbSet<ItemDTO> Items { get; set; }
    }
}
