using TechRent.Features.Navigation;

namespace TechRent.Shared.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly DialogNavigationProxy _dialogNavigationProxy;

        public ViewModelBase? CurrentDialogViewModel => _dialogNavigationProxy.CurrentViewModel;
        public bool IsDialogOpen => _dialogNavigationProxy.IsOpen;

        public InventoryViewModel InventoryViewModel { get; }

        public MainWindowViewModel(DialogNavigationProxy dialogNavigationProxy, InventoryViewModel inventoryViewModel)
        {
            _dialogNavigationProxy = dialogNavigationProxy;
            InventoryViewModel = inventoryViewModel;

            _dialogNavigationProxy.CurrentViewModelChanged += CurentViewModelChangedInDialogNavigationProxy;
        }

        protected override void Dispose()
        {
            _dialogNavigationProxy.CurrentViewModelChanged -= CurentViewModelChangedInDialogNavigationProxy;

            base.Dispose();
        }

        private void CurentViewModelChangedInDialogNavigationProxy()
        {
            OnPropertyChanged(nameof(CurrentDialogViewModel));
            OnPropertyChanged(nameof(IsDialogOpen));
        }
    }
}
