using System.Threading.Tasks;
using TechRent.Entities;
using TechRent.Features.ShowItemListing;
using TechRent.Shared.Commands;

namespace TechRent.Features.DeleteItem
{
    public class DeleteItemCommand : AsyncCommandBase
    {
        private readonly ItemListingElementViewModel _itemListingElementViewModel;
        private readonly ItemProxy _itemProxy;

        public DeleteItemCommand(ItemListingElementViewModel itemListingElementViewModel, ItemProxy itemProxy)
        {
            _itemListingElementViewModel = itemListingElementViewModel;
            _itemProxy = itemProxy;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            var item = _itemListingElementViewModel.Item;
            _itemListingElementViewModel.IsDeleting = true;
            try
            {
                await _itemProxy.Delete(item.Id);
            }
            finally
            {
                _itemListingElementViewModel.IsDeleting = false;
            }
        }

    }
}
