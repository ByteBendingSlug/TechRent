using TechRent.Entities;
using TechRent.Features.Navigation;
using TechRent.Features.ShowItemListing;
using TechRent.Shared.Commands;

namespace TechRent.Features.RentItem
{
    public class OpenRentalDialogCommand : CommandBase
    {
        private readonly ItemListingElementViewModel _itemListingItemViewModel;
        private readonly ItemProxy _itemProxy;
        private readonly DialogNavigationProxy _dialogNavigationProxy;

        public OpenRentalDialogCommand(ItemListingElementViewModel itemListingElementViewModel,
            ItemProxy itemProxy,
            DialogNavigationProxy dialogNavigationProxy)
        {
            _itemListingItemViewModel = itemListingElementViewModel;
            _itemProxy = itemProxy;
            _dialogNavigationProxy = dialogNavigationProxy;
        }
        
        public override void Execute(object? parameter)
        {
            var item = _itemListingItemViewModel.Item;

            var rentItemViewModel =
                new RentItemViewModel(item, _itemProxy, _dialogNavigationProxy);
            _dialogNavigationProxy.CurrentViewModel = rentItemViewModel;
        }
    }
}
