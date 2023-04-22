using System;
using System.Windows.Input;
using TechRent.Entities;
using TechRent.Features.Navigation;
using TechRent.Features.ShowItemDetail;
using TechRent.Shared.ViewModels;

namespace TechRent.Features.RentItem
{
    public class RentItemViewModel : ViewModelBase
    {
        public Guid ItemID { get; }
        public ItemDetailsFormViewModel ItemDetailsFormViewModel { get; }

        public RentItemViewModel(Item item, ItemProxy itemProxy, DialogNavigationProxy dialogNavigationProxy)
        {
            ItemID = item.Id;

            ICommand submitCommand = new RentItemCommand(this, itemProxy, dialogNavigationProxy);
            ICommand cancelCommand = new CloseDialogCommand(dialogNavigationProxy);
            ItemDetailsFormViewModel = new ItemDetailsFormViewModel(submitCommand, cancelCommand)
            {
                ItemName = item.ItemName,
                Category = item.Category,
                IsRented = item.Rent,
            };
        }
    }
}
