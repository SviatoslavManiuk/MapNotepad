using Prism.Mvvm;
using Prism.Navigation;

namespace MapNotepad.ViewModel
{
    public class BaseViewModel: BindableBase, IInitialize, INavigatedAware, IDestructible
    {
        public BaseViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
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

        #region -- IDescructible implementation --
        
        public virtual void Destroy()
        {
        }
        
        #endregion
    }
}