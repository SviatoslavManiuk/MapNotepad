using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using MapNotepad.Helpers;
using MapNotepad.Services.Authentication;
using MapNotepad.View;
using Prism.Navigation;
using Xamarin.Essentials;

namespace MapNotepad.ViewModel
{
    public class CreateAccountPasswordPageViewModel : BaseViewModel
    {
        private IAuthenticationService _authenticationService;
        private string _name;
        private string _email;
        
        public CreateAccountPasswordPageViewModel(INavigationService navigationService, IAuthenticationService authenticationService) : base(navigationService)
        {
            _authenticationService = authenticationService;
        }
        
        #region -- Public Properties --
        
        private string _password;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }
        
        private string _confirmPassword;
        public string ConfirmPassword
        {
            get => _confirmPassword;
            set => SetProperty(ref _confirmPassword, value);
        }

        private ICommand _backButtonCommand;
        public ICommand BackButtonCommand => _backButtonCommand ??=
            SingleExecutionCommand.FromFunc(OnBackButtonCommandAsync);

        private ICommand _createAccountCommand;
        public ICommand CreateAccountCommand => _createAccountCommand ??= 
            SingleExecutionCommand.FromFunc(OnCreateAccountCommandAsync);
        
        #endregion


        #region -- Overrides

        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);

            _name = (string)parameters[Constants.Navigation.NAME_PARAMETER];
            _email = (string)parameters[Constants.Navigation.EMAIL_PARAMETER];
        }

        #endregion

        #region -- Private Helpers --

        private async Task OnCreateAccountCommandAsync()
        {
            if (Password != ConfirmPassword)
            {
                UserDialogs.Instance.Alert("Password mismatch");
            }
            else if (!IsPasswordValid())
            {
                UserDialogs.Instance.Alert("Password must have at least 6 symbols at minimum have one digit and one uppercase letter!");
            }
            else
            {

                var result = await _authenticationService.SignUpAsync(_name, _email, Password);

                if (result.IsSuccess)
                {
                    var parameters = new NavigationParameters();
                    parameters.Add(Constants.Navigation.EMAIL_PARAMETER, _email);
                    await NavigationService.NavigateAsync(nameof(LogInPage), parameters);
                }
                else
                {
                    UserDialogs.Instance.Alert("A User with this email already exists");
                }
            }
        }
        
        private bool IsPasswordValid()
        {
            return Regex.IsMatch(Password, @"^((?=.*\d)(?=.*[A-Z]).{6,})$");
        }
        
        #endregion
    }
}