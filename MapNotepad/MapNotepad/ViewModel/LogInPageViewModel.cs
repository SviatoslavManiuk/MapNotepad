using System.Threading.Tasks;
using System.Windows.Input;
using MapNotepad.Helpers;
using Prism.Navigation;

namespace MapNotepad.ViewModel
{
    public class LogInPageViewModel: BaseViewModel
    {
        public LogInPageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
        
        #region -- Public Properties --

        private ICommand _backButtonCommand;
        public ICommand BackButtonCommand => _backButtonCommand ??=
            SingleExecutionCommand.FromFunc(OnBackButtonCommandAsync);

        private ICommand _logInCommand;
        public ICommand LogInCommand => _logInCommand ??= 
            SingleExecutionCommand.FromFunc(OnLogInCommandAsync);
        
        #endregion

        #region -- Private Helpers --

        private async Task OnLogInCommandAsync()
        {
        }
        
        #endregion
    }
}