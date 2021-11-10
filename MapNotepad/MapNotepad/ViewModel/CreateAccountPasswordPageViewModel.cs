using System.Threading.Tasks;
using System.Windows.Input;
using MapNotepad.Helpers;
using MapNotepad.Services.Authentication;
using Prism.Navigation;

namespace MapNotepad.ViewModel
{
    public class CreateAccountPasswordPageViewModel : BaseViewModel
    {
        private IAuthenticationService _authenticationService;
        
        public CreateAccountPasswordPageViewModel(INavigationService navigationService, IAuthenticationService authenticationService) : base(navigationService)
        {
            _authenticationService = authenticationService;
        }
        
        #region -- Public Properties --

        private ICommand _backButtonCommand;
        public ICommand BackButtonCommand => _backButtonCommand ??=
            SingleExecutionCommand.FromFunc(OnBackButtonCommandAsync);

        private ICommand _createAccountCommand;
        public ICommand CreateAccountCommand => _createAccountCommand ??= 
            SingleExecutionCommand.FromFunc(OnCreateAccountCommandAsync);
        
        #endregion

        #region -- Private Helpers --

        private async Task OnCreateAccountCommandAsync()
        {
        }
        
        #endregion
    }
}