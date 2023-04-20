using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TechRent.Entities;
using TechRent.Features.Navigation;
using TechRent.Features.ShowItemDetail;
using TechRent.Shared.Commands;

namespace TechRent.Features.AddItem
{
    public class AddItemCommand : AsyncCommandBase
    {
        private readonly AddItemViewModel _addItemViewModel;
        private readonly ItemProxy _itemProxy;
        private readonly DialogNavigationProxy _dialogNavigationProxy;

        public AddItemCommand(AddItemViewModel addItemViewModel, ItemProxy itemProxy, DialogNavigationProxy dialogNavigationProxy)
        {
            _addItemViewModel = addItemViewModel;
            _itemProxy = itemProxy;
            _dialogNavigationProxy = dialogNavigationProxy;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            var itemDetailsFormViewModel = _addItemViewModel.ItemDetailsFormViewModel;

            itemDetailsFormViewModel.IsSubmitting = true;

            if (string.IsNullOrEmpty(itemDetailsFormViewModel.ItemName))
            {
                itemDetailsFormViewModel.IsSubmitting = false;
                return;
            }

            Item item = new Item(
                Guid.NewGuid(),
                itemDetailsFormViewModel.ItemName!,
                itemDetailsFormViewModel.Category!,
                itemDetailsFormViewModel.IsRented);

            try
            {
                await _itemProxy.Add(item);

                _dialogNavigationProxy.Close();
            }
            finally
            {
                itemDetailsFormViewModel.IsSubmitting = false;
            }
        }
    }
}
