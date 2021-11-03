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
        
        public ICommand CreateButtonTapCommand => new Command(OnCreateButtonTap);

        #region --- Private Helpers---
        
        private async void OnLogInButtonTap()
        {
            await NavigationService.NavigateAsync(nameof(LogIn));
        }
        
        private async void OnCreateButtonTap()
        {
            await NavigationService.NavigateAsync(nameof(CreateAccountEmail));
        }
        
        #endregion
    }
}