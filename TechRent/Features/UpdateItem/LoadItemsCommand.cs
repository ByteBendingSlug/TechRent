using System.Threading.Tasks;
using TechRent.Entities;
using TechRent.Shared.Commands;

namespace TechRent.Features.UpdateItem
{
    public class LoadItemsCommand : AsyncCommandBase
    {
        private readonly ItemProxy _itemProxy;
        public LoadItemsCommand(ItemProxy itemProxy)
        {
            _itemProxy = itemProxy;
        }
        public override async Task ExecuteAsync(object? parameter)
        {
            await _itemProxy.Load();
        }
    }
}
