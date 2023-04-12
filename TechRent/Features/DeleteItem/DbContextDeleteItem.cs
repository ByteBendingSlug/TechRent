using System;
using System.Threading.Tasks;
using TechRent.Shared.DatabaseContext;
using TechRent.Shared.DTOs;
using TechRent.Shared.FeatureContracts;

namespace TechRent.Features.DeleteItem
{
    public class DbContextDeleteItem : IDeleteCommand
    {
        private readonly ItemDbContextFactory _contextFactory;

        public DbContextDeleteItem(ItemDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Execute(Guid id)
        {
            using (ItemDbContext context = _contextFactory.Create())
            {
                var itemDTO = new ItemDTO()
                {
                    Id = id,
                };

                context.Items.Remove(itemDTO);
                await context.SaveChangesAsync();
            }
        }
    }
}
