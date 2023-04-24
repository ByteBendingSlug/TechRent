using System.Windows.Input;
using TechRent.Entities;
using TechRent.Features.DeleteItem;
using TechRent.Features.Navigation;
using TechRent.Features.RentItem;
using TechRent.Shared.ViewModels;

namespace TechRent.Features.ShowItemListing
{
    public class ItemListingElementViewModel : ViewModelBase
    {
        public Item Item { get; private set; }

        public string ItemName => Item.ItemName;

        private bool _isDeleting;
        public bool IsDeleting
        {
            get => _isDeleting;
            set
            {
                _isDeleting = value;
                OnPropertyChanged(nameof(IsDeleting));
            }
        }

        private bool _isPopupOpen;

        public bool IsPopupOpen
        {
            get => _isPopupOpen;
            set
            {
                if (_isPopupOpen != value)
                {
                    _isPopupOpen = value;
                    OnPropertyChanged(nameof(IsPopupOpen));
                }
            }
        }

        public ICommand RentCommand { get; }
        public ICommand DeleteCommand { get; }

        public ItemListingElementViewModel(Item item, ItemProxy itemProxy, DialogNavigationProxy dialogNavigationProxy)
        {
            Item = item;

            RentCommand = new OpenRentalDialogCommand(this, itemProxy, dialogNavigationProxy);
            DeleteCommand = new DeleteItemCommand(this, itemProxy);
        }

        public void Update(Item item)
        {
            Item = item;
            OnPropertyChanged(nameof(ItemName));
        }
    }
}
