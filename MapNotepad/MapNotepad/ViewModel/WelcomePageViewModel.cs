using System.Threading.Tasks;
using System.Windows.Input;
using MapNotepad.Helpers;
using MapNotepad.View;
using Prism.Navigation;

namespace MapNotepad.ViewModel
{
    public class WelcomePageViewModel : BaseViewModel
    {
        public WelcomePageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        #region -- Public Properties --
        
        private ICommand _logInButtonCommand;
        public ICommand LogInButtonCommand => _logInButtonCommand ??=
            SingleExecutionCommand.FromFunc(OnLogInButtonCommandAsync);

        private ICommand _createAccountButtonCommand;
        public ICommand CreateAccountButtonCommand => _createAccountButtonCommand ??= 
            SingleExecutionCommand.FromFunc(OnCreateAccountButtonCommandAsync);
        
        #endregion

        #region -- Private Helpers--

        private async Task OnLogInButtonCommandAsync()
        {
            await NavigationService.NavigateAsync(nameof(LogInPage));
        }

        private async Task OnCreateAccountButtonCommandAsync()
        {
            await NavigationService.NavigateAsync(nameof(CreateAccountEmailPage));
        }

        #endregion
    }
}