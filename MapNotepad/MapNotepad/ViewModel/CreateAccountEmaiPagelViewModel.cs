using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using MapNotepad.Helpers;
using MapNotepad.View;
using Prism.Navigation;

namespace MapNotepad.ViewModel
{
    public class CreateAccountEmailPageViewModel: BaseViewModel
    {
        public CreateAccountEmailPageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        #region -- Public Properties --
        
        private ICommand _backButtonCommand;
        public ICommand BackButtonCommand => _backButtonCommand ??=
            SingleExecutionCommand.FromFunc(OnBackButtonCommandAsync);

        private ICommand _nextButtonCommand;
        public ICommand NextButtonCommand => _nextButtonCommand ??= 
            SingleExecutionCommand.FromFunc(OnNextButtonCommandAsync);

        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }
        
        private string _email;
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }
        
        private bool _allFieldsNotNull;
        public bool AllFieldsNotNull
        {
            get => _allFieldsNotNull;
            set
            {
                if (SetProperty(ref _allFieldsNotNull, value))
                {
                    RaisePropertyChanged(nameof(AllFieldsNotNull));
                }
            }
        }
        
        #endregion
        
        #region -- Overrides --
        
        protected override void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnPropertyChanged(args);

            switch (args.PropertyName)
            {
                case nameof(Name):
                case nameof(Email):
                    AllFieldsNotNull = !(string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Email));
                    break;
            }
        }
        #endregion

        #region -- Private Helpers --

        private async Task OnNextButtonCommandAsync()
        {
            if (IsEmailValid())
            {
                var parameters = new NavigationParameters();
                parameters.Add(Constants.Navigation.NAME_PARAMETER, Name);
                parameters.Add(Constants.Navigation.EMAIL_PARAMETER, Email);
                
                await NavigationService.NavigateAsync(nameof(CreateAccountPasswordPage), parameters);
            }
        }

        private bool IsEmailValid()
        {
            if (!Regex.IsMatch(Email, @"^\S{1,64}@\S{1,64}$"))
            {
                //UserDialogs.Instance.Alert("Email must match the format: {64 symbols @ 64 symbols}");
                return false;
            }

            return true;
        }
        
        #endregion
    }
}