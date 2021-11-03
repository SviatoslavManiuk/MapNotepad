using System.Windows.Input;
using MapNotepad.View.ViewList;
using Prism.Navigation;
using Xamarin.Forms;

namespace MapNotepad.ViewModel.ViewModelList
{
    public class LogInRegisterViewModel: BaseViewModel
    {
        public LogInRegisterViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        public ICommand LogInButtonTapCommand => new Command(OnLogInButtonTap);
        
        public ICommand CreateAccountButtonTapCommand => new Command(OnCreateAccountButtonTap);

        #region --- Private Helpers---
        
        private async void OnLogInButtonTap()
        {
            await NavigationService.NavigateAsync("NavigationPage/" + nameof(LogIn));
        }
        
        private async void OnCreateAccountButtonTap()
        {
            await NavigationService.NavigateAsync("NavigationPage/" + nameof(CreateAccountEmail));
        }
        
        #endregion
    }
}