using Prism.Mvvm;
using Prism.Navigation;

namespace MapNotepad.Helpers
{
    public class BaseViewModel: BindableBase, IInitialize, INavigatedAware, IDestructible
    {
        public INavigationService NavigationService;

        public virtual void Initialize(INavigationParameters parameters)
        {
            
        }
        
        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
           
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
            
        }
        
        public virtual void Destroy()
        {
            
        }
    }
}