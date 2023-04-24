using System.Threading.Tasks;
using TechRent.Entities;
using TechRent.Features.Navigation;
using TechRent.Shared.Commands;

namespace TechRent.Features.RentItem
{
    public class RentItemCommand : AsyncCommandBase
    {
        private readonly RentItemViewModel _rentItemViewModel;
        private readonly ItemProxy _itemProxy;
        private readonly DialogNavigationProxy _dialogNavigationProxy;

        public RentItemCommand(RentItemViewModel rentItemViewModel, ItemProxy itemProxy, DialogNavigationProxy dialogNavigationProxy)
        {
            _rentItemViewModel = rentItemViewModel;
            _itemProxy = itemProxy;
            _dialogNavigationProxy = dialogNavigationProxy;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            var formViewModel = _rentItemViewModel.ItemDetailsFormViewModel;

            formViewModel.IsSubmitting = true;

            Item item = new Item(
                _rentItemViewModel.ItemID,
                formViewModel.ItemName!,
                formViewModel.Category!,
                formViewModel.IsRented);

            try
            {
                await _itemProxy.Update(item);

                _dialogNavigationProxy.Close();
            }
            finally
            {
                formViewModel.IsSubmitting = false;
            }
        }
    }
}

