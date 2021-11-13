using System.Threading.Tasks;
using System.Windows.Input;
using MapNotepad.Helpers;
using Prism.Navigation;

namespace MapNotepad.ViewModel
{
    public class MapPageViewModel:BaseViewModel
    {
        public MapPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            IsEntryImageVisible = false;
        }

        #region -- Public Properties --
        
        private bool _isEntryImageVisible;

        public bool IsEntryImageVisible
        {
            get => _isEntryImageVisible;
            set => SetProperty(ref _isEntryImageVisible, value);
        }

        private ICommand _userLocationCommand;
        public ICommand UserLocationCommand => _userLocationCommand ??=
            SingleExecutionCommand.FromFunc(OnUserLocationCommandAsync);
        
        #endregion

        #region -- Private Helpers

        public async Task OnUserLocationCommandAsync()
        {
        }

        #endregion
    }
}