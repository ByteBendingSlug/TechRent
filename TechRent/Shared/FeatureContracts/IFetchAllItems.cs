using System.Collections.Generic;
using System.Threading.Tasks;
using TechRent.Entities;

namespace TechRent.Shared.FeatureContracts
{
    public interface IFetchAllItems
    {
        Task<IEnumerable<Item>> Execute(string? categoryFilter = null);
    }
}
