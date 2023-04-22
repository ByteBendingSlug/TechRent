using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechRent.Entities;
using TechRent.Shared.DatabaseContext;
using TechRent.Shared.DTOs;
using TechRent.Shared.FeatureContracts;

namespace TechRent.Features.UpdateItem;

public class FetchAllItems : IFetchAllItems
{
    private readonly ItemDbContextFactory _contextFactory;

    public FetchAllItems(ItemDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<IEnumerable<Item>> Execute(string? categoryFilter = null)
    {
        using ItemDbContext context = _contextFactory.Create();
        IEnumerable<ItemDTO> itemDTOs = await context.Items.ToListAsync();
        return itemDTOs.Select(y => new Item(y.Id, y.ItemName ?? "Unknown", y.Kategorie ?? "Unknown", y.Ausleihen));
    }
}
