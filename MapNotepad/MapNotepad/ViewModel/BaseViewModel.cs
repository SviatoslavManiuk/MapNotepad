using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Navigation;

namespace MapNotepad.ViewModel
{
    public class BaseViewModel: BindableBase, IInitialize, INavigatedAware, IAppearingAware, IDestructible
    {
        protected BaseViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }
        
        protected async Task OnBackButtonCommandAsync()
        {
            await NavigationService.GoBackAsync();
        }
        
        
        #region -- Public Properties --
        protected INavigationService NavigationService { get; }
        
        #endregion

        #region -- IInitialize implementation --
        
        public virtual void Initialize(INavigationParameters parameters)
        {
        }
        
        #endregion

        #region -- INawigatedAware implementation --
        
        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
        }
        
        #endregion
        
        #region -- IAppearingAware --
        
        public virtual void OnAppearing()
        {
        }

        public virtual void OnDisappearing()
        {
        }
        
        #endregion

        #region -- IDescructible implementation --
        
        public virtual void Destroy()
        {
        }
        
        #endregion
    }
}