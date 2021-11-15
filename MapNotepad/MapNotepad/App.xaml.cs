using MapNotepad.Services.Authentication;
using MapNotepad.Services.Repository;
using MapNotepad.Services.SettingsManager;
using MapNotepad.Services.SettingsWrapper;
using MapNotepad.View;
using MapNotepad.ViewModel;
using Prism.Ioc;
using Prism.Navigation;
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
            containerRegistry.RegisterInstance<ISettingsWrapper>(Container.Resolve<SettingsWrapper>());
            containerRegistry.RegisterInstance<IRepositoryService>(Container.Resolve<RepositoryService>());
            containerRegistry.RegisterInstance<IAuthenticationService>(Container.Resolve<AuthenticationService>());
            
            // Navigation
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<WelcomePage, WelcomePageViewModel>();
            containerRegistry.RegisterForNavigation<LogInPage, LogInPageViewModel>();
            containerRegistry.RegisterForNavigation<CreateAccountEmailPage, CreateAccountEmailPageViewModel>();
            containerRegistry.RegisterForNavigation<CreateAccountPasswordPage, CreateAccountPasswordPageViewModel>();
            containerRegistry.RegisterForNavigation<MapPage, MapPageViewModel>();
            containerRegistry.RegisterForNavigation<PinsListPage, PinsListPageViewModel>();
            containerRegistry.RegisterForNavigation<MainTabbedPage>();
            containerRegistry.RegisterForNavigation<AddPinPage, AddPinPageViewModel>();
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            var settingsWrapper = new SettingsWrapper(new SettingsManager());
            int authorizedUserId = settingsWrapper.GetAuthorizedUserId();
            if (authorizedUserId != 0)
            {
                var parameters = new NavigationParameters();
                parameters.Add(Constants.Navigation.AUTHORIZED_USER_ID_PARAMETER, authorizedUserId);
                await NavigationService.NavigateAsync(nameof(MainTabbedPage), parameters);
            }
            else
            {
                await NavigationService.NavigateAsync(nameof(WelcomePage));
            }
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
