using System.Windows.Input;
using MapNotepad.View;
using Prism.Navigation;
using Xamarin.Forms;

namespace MapNotepad.ViewModel
{
    public class LogInRegisterPageViewModel: BaseViewModel
    {
        public LogInRegisterPageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        public ICommand LogInButtonTapCommand => new Command(OnLogInButtonTap);
        
        public ICommand CreateAccountButtonTapCommand => new Command(OnCreateAccountButtonTap);

        #region --- Private Helpers---
        
        private async void OnLogInButtonTap()
        {
            await NavigationService.NavigateAsync(nameof(LogInPage));
        }
        
        private async void OnCreateAccountButtonTap()
        {
            await NavigationService.NavigateAsync(nameof(CreateAccountEmailPage));
        }
        
        #endregion
    }
}