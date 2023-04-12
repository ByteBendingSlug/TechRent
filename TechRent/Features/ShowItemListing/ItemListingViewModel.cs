using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using TechRent.Entities;
using TechRent.Features.Navigation;
using TechRent.Shared.ViewModels;

namespace TechRent.Features.ShowItemListing
{
    public class ItemListingViewModel : ViewModelBase
    {
        private readonly ItemProxy _itemProxy;
        private readonly SelectedItemProxy _selectedItemProxy;
        private readonly DialogNavigationProxy _dialogNavigationProxy;

        private readonly ObservableCollection<ItemListingElementViewModel> _itemListingElementViewModels;
        public IEnumerable<ItemListingElementViewModel> ItemListingElementViewModels => _itemListingElementViewModels;

        public ItemListingElementViewModel? SelectedItemElementViewModel
        {
            get
            {
                return _itemListingElementViewModels.FirstOrDefault(y => y.Item?.Id == _selectedItemProxy.SelectedItem?.Id) ?? _itemListingElementViewModels.FirstOrDefault();
            }
            set
            {
                _selectedItemProxy.SelectedItem = value?.Item;
            }
        }

        public ItemListingViewModel(ItemProxy itemProxy, SelectedItemProxy selectedItemProxy, DialogNavigationProxy dialogNavigationStore)
        {
            _itemProxy = itemProxy;
            _selectedItemProxy = selectedItemProxy;
            _dialogNavigationProxy = dialogNavigationStore;
            _itemListingElementViewModels = new();

            _selectedItemProxy.SelectedItemChanged += SelectedItemChangedInProxy;

            _itemProxy.ItemsLoaded += ItemLoadedInProxy;
            _itemProxy.ItemAdded += ItemsAddedInProxy;
            _itemProxy.ItemUpdated += ItemsUpdatedInProxy;
            _itemProxy.ItemDeleted += ItemsDeletedInProxy;

            _itemListingElementViewModels.CollectionChanged += SelectedItemsCollectionChanged;
        }

        protected override void Dispose()
        {
            _selectedItemProxy.SelectedItemChanged -= SelectedItemChangedInProxy;

            _itemProxy.ItemsLoaded -= ItemLoadedInProxy;
            _itemProxy.ItemAdded -= ItemsAddedInProxy;
            _itemProxy.ItemUpdated -= ItemsUpdatedInProxy;
            _itemProxy.ItemDeleted -= ItemsDeletedInProxy;

            _itemListingElementViewModels.CollectionChanged -= SelectedItemsCollectionChanged;

            base.Dispose();
        }

        private void SelectedItemChangedInProxy()
        {
            OnPropertyChanged(nameof(SelectedItemElementViewModel));
        }

        private void ItemLoadedInProxy()
        {
            _itemListingElementViewModels.Clear();

            foreach (Item item in _itemProxy.Items)
            {
                AddItem(item);
            }
        }

        private void ItemsAddedInProxy(Item item)
        {
            AddItem(item);
        }

        private void ItemsUpdatedInProxy(Item item)
        {
            var itemViewModel = _itemListingElementViewModels.FirstOrDefault(y => y.Item.Id == item.Id);
            itemViewModel?.Update(item);
        }

        private void ItemsDeletedInProxy(Guid id)
        {
            var itemViewModel = _itemListingElementViewModels.FirstOrDefault(y => y.Item?.Id == id);

            if (itemViewModel != null)
            {
                _itemListingElementViewModels.Remove(itemViewModel);
            }
        }

        private void SelectedItemsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(SelectedItemElementViewModel));
        }

        private void AddItem(Item item)
        {
            var itemViewModel =
                new ItemListingElementViewModel(item, _itemProxy, _dialogNavigationProxy);
            _itemListingElementViewModels.Add(itemViewModel);
        }
    }
}
