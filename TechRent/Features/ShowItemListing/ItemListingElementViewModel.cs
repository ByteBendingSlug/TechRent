﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TechRent.Entities;
using TechRent.Features.DeleteItem;
using TechRent.Features.RentItem;
using TechRent.Features.Navigation;
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

        public ItemListingElementViewModel(Item item, ItemProxy itemProxy, DialogNavigationProxy dialogNavigationStore)
        {
            Item = item;

            RentCommand = new OpenRentalDialogCommand(this, itemProxy, dialogNavigationStore);
            DeleteCommand = new DeleteItemCommand(this, itemProxy);
        }

        public void Update(Item item)
        {
            Item = item;
            OnPropertyChanged(nameof(ItemName));
        }
    }
}
