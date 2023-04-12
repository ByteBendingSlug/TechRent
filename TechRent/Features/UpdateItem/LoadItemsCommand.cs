using System.Threading.Tasks;
using TechRent.Entities;
using TechRent.Shared.Commands;
using TechRent.Shared.ViewModels;

namespace TechRent.Features.UpdateItem
{
    public class LoadItemsCommand : AsyncCommandBase
    {
        private readonly InventoryViewModel _inventoryViewModel;
        private readonly ItemProxy _itemProxy;
        public LoadItemsCommand(InventoryViewModel inventoryViewModel, ItemProxy itemProxy)
        {
            _inventoryViewModel = inventoryViewModel;
            _itemProxy = itemProxy;
        }
        public override async Task ExecuteAsync(object? parameter)
        {
            await _itemProxy.Load();
        }
    }
}
