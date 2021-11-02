using System;
using System.Windows.Input;
using MapNotepad.Helpers;
using MapNotepad.View;
using Xamarin.Forms;

namespace MapNotepad.ViewModel
{
    public class LogInRegisterViewModel: BaseViewModel
    {
        public LogInRegisterViewModel(){}

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