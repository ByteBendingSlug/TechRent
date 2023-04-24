using System.Windows.Input;
using TechRent.Entities;
using TechRent.Features.AddItem;
using TechRent.Features.Navigation;
using TechRent.Features.ShowItemDetail;
using TechRent.Features.ShowItemListing;
using TechRent.Features.UpdateItem;

namespace TechRent.Shared.ViewModels
{
    public class InventoryViewModel : ViewModelBase
    {
        public ItemListingViewModel ItemListingViewModel { get; }
        public ItemDetailsViewModel ItemDetailsViewModel { get; }

        public ICommand LoadItemsCommand { get; }
        public ICommand AddItemsCommand { get; }

        public InventoryViewModel(ItemProxy itemProxy, SelectedItemProxy selectedItemProxy, DialogNavigationProxy dialogNavigationProxy)
        {
            ItemListingViewModel = new ItemListingViewModel(itemProxy, selectedItemProxy, dialogNavigationProxy);
            ItemDetailsViewModel = new ItemDetailsViewModel(selectedItemProxy);

            LoadItemsCommand = new LoadItemsCommand(itemProxy);
            AddItemsCommand = new OpenAddDialogCommand(itemProxy, dialogNavigationProxy);
        }

        public static InventoryViewModel CreateViewModel(ItemProxy itemProxy, SelectedItemProxy selectedItemProxy, DialogNavigationProxy dialogNavigationProxy)
        {
            return new InventoryViewModel(itemProxy, selectedItemProxy, dialogNavigationProxy);
        }

        public static InventoryViewModel LoadViewModel(ItemProxy itemProxy, SelectedItemProxy selectedItemProxy, DialogNavigationProxy dialogNavigationProxy)
        {
            InventoryViewModel viewModel = new InventoryViewModel(itemProxy, selectedItemProxy, dialogNavigationProxy);

            viewModel.LoadItemsCommand.Execute(null);

            return viewModel;
        }
    }
}
