using TechRent.Entities;
using TechRent.Shared.ViewModels;

namespace TechRent.Features.ShowItemDetail
{
    public class ItemDetailsViewModel : ViewModelBase
    {
        private readonly SelectedItemProxy _selectedItemProxy;

        private Item? SelectedItem => _selectedItemProxy.SelectedItem;

        public bool HasSelectedItem => SelectedItem != null;
        public string ItemName => SelectedItem?.ItemName ?? "Unknown";
        public string CategoryDisplay => SelectedItem?.Category ?? "Unknown";
        public bool IsRentedDisplay => SelectedItem?.Rent ?? false;

        public ItemDetailsViewModel(SelectedItemProxy selectedItemProxy)
        {
            _selectedItemProxy = selectedItemProxy;

            _selectedItemProxy.SelectedItemChanged += SelectedItemChangedInSelectedItemProxy;
        }


        private void SelectedItemChangedInSelectedItemProxy()
        {
            OnPropertyChanged(nameof(HasSelectedItem));
            OnPropertyChanged(nameof(SelectedItem));
            OnPropertyChanged(nameof(ItemName));
            OnPropertyChanged(nameof(CategoryDisplay));
            OnPropertyChanged(nameof(IsRentedDisplay));

        }
        protected override void Dispose()
        {
            _selectedItemProxy.SelectedItemChanged -= SelectedItemChangedInSelectedItemProxy;

            base.Dispose();
        }
    }
}

