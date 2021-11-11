using MapNotepad.Services.Authentication;
using MapNotepad.Services.Repository;
using MapNotepad.Services.Settings;
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
            // Services
            containerRegistry.RegisterInstance<ISettingsManager>(Container.Resolve<SettingsManager>());
            containerRegistry.RegisterInstance<IRepositoryService>(Container.Resolve<RepositoryService>());
            containerRegistry.RegisterInstance<IAuthenticationService>(Container.Resolve<AuthenticationService>());
            
            // Navigation
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<WelcomePage, WelcomePageViewModel>();
            containerRegistry.RegisterForNavigation<LogInPage, LogInPageViewModel>();
            containerRegistry.RegisterForNavigation<CreateAccountEmailPage, CreateAccountEmailPageViewModel>();
            containerRegistry.RegisterForNavigation<CreateAccountPasswordPage, CreateAccountPasswordPageViewModel>();
            containerRegistry.RegisterForNavigation<AddPinPage, AddPinPageViewModel>();
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync(nameof(AddPinPage));
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
