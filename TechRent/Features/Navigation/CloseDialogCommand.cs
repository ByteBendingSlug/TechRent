using TechRent.Shared.Commands;

namespace TechRent.Features.Navigation
{
    public class CloseDialogCommand : CommandBase
    {
        private readonly DialogNavigationProxy _dialogNavigationStore;
        public CloseDialogCommand(DialogNavigationProxy dialogNavigationStore)
        {
            _dialogNavigationStore = dialogNavigationStore;
        }
        public override void Execute(object? parameter)
        {
            _dialogNavigationStore.Close();
        }
    }
}
