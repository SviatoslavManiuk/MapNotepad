using System.Threading.Tasks;
using System.Windows.Input;
using MapNotepad.Helpers;
using MapNotepad.Services.Authentication;
using Prism.Navigation;

namespace MapNotepad.ViewModel
{
    public class LogInPageViewModel: BaseViewModel
    {
        private IAuthenticationService _authenticationService;
        
        public LogInPageViewModel(INavigationService navigationService, IAuthenticationService authenticationService) : base(navigationService)
        {
            _authenticationService = authenticationService;
        }
        
        
        #region -- Public Properties --
        
        private string _email;
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }
        
        private string _password;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        private ICommand _backButtonCommand;
        public ICommand BackButtonCommand => _backButtonCommand ??=
            SingleExecutionCommand.FromFunc(OnBackButtonCommandAsync);

        private ICommand _logInCommand;
        public ICommand LogInCommand => _logInCommand ??= 
            SingleExecutionCommand.FromFunc(OnLogInCommandAsync);
        
        #endregion

        #region -- Overrides

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            
            var email = parameters[Constants.Navigation.EMAIL_PARAMETER];
            if (email != null)
            {
                Email = (string) email;
            }
        }

        #endregion

        #region -- Private Helpers --
        private async Task OnLogInCommandAsync()
        {
        }
        
        #endregion
    }
}