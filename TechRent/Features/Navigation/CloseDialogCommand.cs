using TechRent.Shared.Commands;

namespace TechRent.Features.Navigation
{
    public class CloseDialogCommand : CommandBase
    {
        private readonly DialogNavigationProxy _dialogNavigationProxy;
        public CloseDialogCommand(DialogNavigationProxy dialogNavigationProxy)
        {
            _dialogNavigationProxy = dialogNavigationProxy;
        }
        public override void Execute(object? parameter)
        {
            _dialogNavigationProxy.Close();
        }
    }
}
