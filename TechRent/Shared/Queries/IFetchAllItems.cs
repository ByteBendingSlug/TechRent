using System.Collections.Generic;
using System.Threading.Tasks;
using TechRent.Entities;

namespace TechRent.Shared.Queries
{
    public interface IFetchAllItems
    {
        Task<IEnumerable<Item>> Execute(string? categoryFilter = null, bool? availableFilter = null, string? sortBy = null, bool descending = false);
    }
}
