using System;

namespace TechRent.Entities
{
    public class SelectedItemProxy : IDisposable
    {
        private readonly ItemProxy _itemProxy;

        private Item? _selectedItem;
        public Item? SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                SelectedItemChanged?.Invoke();
            }
        }

        public event Action? SelectedItemChanged;

        public SelectedItemProxy(ItemProxy itemProxy)
        {
            _itemProxy = itemProxy;

            _itemProxy.ItemAdded += ItemAddedInProxy;
            _itemProxy.ItemUpdated += ItemUpdatedInProxy;
        }

        private void ItemAddedInProxy(Item item)
        {
            SelectedItem = item;
        }

        private void ItemUpdatedInProxy(Item item)
        {
            if (item.Id == SelectedItem?.Id)
            {
                SelectedItem = item;
            }
        }

        public void Dispose()
        {
            _itemProxy.ItemAdded -= ItemAddedInProxy;
            _itemProxy.ItemUpdated -= ItemUpdatedInProxy;
        }
    }
}
