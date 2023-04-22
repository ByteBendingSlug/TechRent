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

        public InventoryViewModel(ItemProxy itemProxy, SelectedItemProxy selectedItemProxy, DialogNavigationProxy dialogNavigationStore)
        {
            ItemListingViewModel = new ItemListingViewModel(itemProxy, selectedItemProxy, dialogNavigationStore);
            ItemDetailsViewModel = new ItemDetailsViewModel(selectedItemProxy);

            LoadItemsCommand = new LoadItemsCommand(itemProxy);
            AddItemsCommand = new OpenAddDialogCommand(itemProxy, dialogNavigationStore);
        }

        public static InventoryViewModel CreateViewModel(ItemProxy itemProxy, SelectedItemProxy selectedItemProxy, DialogNavigationProxy dialogNavigationStore)
        {
            return new InventoryViewModel(itemProxy, selectedItemProxy, dialogNavigationStore);
        }

        public static InventoryViewModel LoadViewModel(ItemProxy itemProxy, SelectedItemProxy selectedItemProxy, DialogNavigationProxy dialogNavigationStore)
        {
            InventoryViewModel viewModel = new InventoryViewModel(itemProxy, selectedItemProxy, dialogNavigationStore);

            viewModel.LoadItemsCommand.Execute(null);

            return viewModel;
        }
    }
}
