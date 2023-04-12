using System.Windows.Input;
using TechRent.Entities;
using TechRent.Features.Navigation;
using TechRent.Features.ShowItemDetail;
using TechRent.Shared.ViewModels;

namespace TechRent.Features.AddItem
{
    public class AddItemViewModel : ViewModelBase
    {
        public ItemDetailsFormViewModel ItemDetailsFormViewModel { get; }

        public AddItemViewModel(ItemProxy itemProxy, DialogNavigationProxy dialogNavigationProxy)
        {
            ICommand submitCommand = new AddItemCommand(this, itemProxy, dialogNavigationProxy);
            ICommand cancelCommand = new CloseDialogCommand(dialogNavigationProxy);
            ItemDetailsFormViewModel = new ItemDetailsFormViewModel(submitCommand, cancelCommand);
        }
    }
}
