using System.Threading.Tasks;
using System.Windows.Input;
using MapNotepad.Helpers;
using MapNotepad.Services.Authentication;
using Prism.Navigation;
using Xamarin.Forms;

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

        private bool _isEmailClearImageVisible;
        public bool IsEmailClearImageVisible
        {
            get => _isEmailClearImageVisible;
            set => SetProperty(ref _isEmailClearImageVisible, value);
        }

        private bool _isEmailError;
        public bool IsEmailError
        {
            get => _isEmailError;
            set => SetProperty(ref _isEmailError, value);
        }
        
        private bool _passwordErrorIsVisible;
        public bool PasswordErrorIsVisible
        {
            get => _passwordErrorIsVisible;
            set => SetProperty(ref _passwordErrorIsVisible, value);
        }

        private Color _passwordBorderColor;
        public Color PasswordBorderColor
        {
            get => _passwordBorderColor;
            set => SetProperty(ref _passwordBorderColor, value);
        }
        
        private bool _isPasswordImageVisible;
        public bool IsPasswordImageVisible
        {
            get => _isPasswordImageVisible;
            set => SetProperty(ref _isPasswordImageVisible, value);
        }
        

        private ICommand _backButtonCommand;
        public ICommand BackButtonCommand => _backButtonCommand ??=
            SingleExecutionCommand.FromFunc(OnBackButtonCommandAsync);

        private ICommand _logInCommand;
        public ICommand LogInCommand => _logInCommand ??= 
            SingleExecutionCommand.FromFunc(OnLogInCommandAsync);
        
        private ICommand _emailClearCommand;
        public ICommand EmailClearCommand => _emailClearCommand ??= 
            SingleExecutionCommand.FromFunc(OnEmailClearCommandAsync);
        
        #endregion

        #region -- Overrides

        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);
            
            var email = parameters[Constants.Navigation.EMAIL_PARAMETER];
            if (email != null)
            {
                Email = (string) email;
            }
            IsEmailError = false;
            IsPasswordImageVisible = false;
            IsEmailClearImageVisible = false;
        }

        #endregion

        #region -- Private Helpers --
        private async Task OnLogInCommandAsync()
        {
            var result = await _authenticationService.SignInAsync(Email, Password);
            var user = result.Result;
            if (result.IsSuccess)
            {
                var parameters = new NavigationParameters();
                parameters.Add(Constants.Navigation.AUTHORIZED_USER_ID_PARAMETER, user.Id);
            }
            else if(user == null)
            {
                IsEmailError = true;
                PasswordErrorIsVisible = false;
                PasswordBorderColor = Color.FromHex(Colors.ENTRY_BORDER_COLOR);
            }
            else if (user.Password != Password)
            {
                PasswordErrorIsVisible = true;
                PasswordBorderColor = Color.FromHex(Colors.ERROR_ENTRY_BORDER_COLOR);
            }
        }
        
        private Task OnEmailClearCommandAsync()
        {
            Email = string.Empty;
            return Task.CompletedTask;
        }
        
        #endregion
    }
}