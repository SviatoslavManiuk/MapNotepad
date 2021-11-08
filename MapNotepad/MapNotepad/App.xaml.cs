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
            containerRegistry.RegisterForNavigation<WelcomePage, LogInRegisterPageViewModel>();
            containerRegistry.RegisterForNavigation<LogInPage, LogInViewPageModel>();
            containerRegistry.RegisterForNavigation<CreateAccountEmailPage, CreateAccountEmailPageViewModel>();
            containerRegistry.RegisterForNavigation<CreateAccountPasswordPage, CreateAccountPasswordPageViewModel>();
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync(nameof(WelcomePage));
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
