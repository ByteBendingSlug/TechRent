using System.Threading.Tasks;
using TechRent.Entities;
using TechRent.Shared.DatabaseContext;
using TechRent.Shared.DTOs;
using TechRent.Shared.FeatureContracts;

namespace TechRent.Features
{
    public class CreateItemCommand : ICreateCommand
    {
        private readonly ItemDbContextFactory _contextFactory;

        public CreateItemCommand(ItemDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Execute(Item item)
        {
            using (ItemDbContext context = _contextFactory.Create())
            {
                ItemDTO itemDTO = new ItemDTO()
                {
                    Id = item.Id,
                    ItemName = item.ItemName,
                    Category = item.Category,
                    Rent = item.Rent,
                };

                context.Items.Add(itemDTO);
                await context.SaveChangesAsync();
            }
        }
    }
}
