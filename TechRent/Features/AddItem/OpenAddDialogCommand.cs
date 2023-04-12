using TechRent.Entities;
using TechRent.Features.Navigation;
using TechRent.Shared.Commands;

namespace TechRent.Features.AddItem
{
    public class OpenAddDialogCommand : CommandBase
    {
        private readonly ItemProxy _itemProxy;
        private readonly DialogNavigationProxy _dialogNavigationProxy;
        public OpenAddDialogCommand(ItemProxy itemProxy, DialogNavigationProxy dialogNavigationProxy)
        {
            _itemProxy = itemProxy;
            _dialogNavigationProxy = dialogNavigationProxy;
        }

        public override void Execute(object? parameter)
        {
            AddItemViewModel addItemViewModel = new AddItemViewModel(_itemProxy, _dialogNavigationProxy);
            _dialogNavigationProxy.CurrentViewModel = addItemViewModel!;
        }
    }
}

