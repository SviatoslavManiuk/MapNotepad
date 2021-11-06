using MapNotepad.View;
using MapNotepad.ViewModel;
using Prism.Ioc;
using Prism.Unity;
using Xamarin.Forms;

namespace MapNotepad
{
    public partial class App : PrismApplication
    {
        public App()
        {
        }

        #region --- Overrides ---
        
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
            //Navigation
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<LogInRegister, LogInRegisterViewModel>();
            containerRegistry.RegisterForNavigation<LogIn, LogInViewModel>();
            containerRegistry.RegisterForNavigation<CreateAccountEmail, CreateAccountEmailViewModel>();
            containerRegistry.RegisterForNavigation<CreateAccountPassword, CreateAccountPasswordViewModel>();
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync(nameof(LogInRegister));
        }
        
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
        
        #endregion
    }
}
