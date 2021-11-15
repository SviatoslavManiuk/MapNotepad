using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using MapNotepad.Helpers;
using MapNotepad.View;
using Prism.Navigation;

namespace MapNotepad.ViewModel
{
    public class PinsListPageViewModel:BaseViewModel
    {
        public PinsListPageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        #region -- Public Properties --
        
        private ObservableCollection<PinViewModel> _pins;
        public ObservableCollection<PinViewModel> Pins
        {
            get => _pins;
            set => SetProperty(ref _pins, value);
        }

        private ICommand _addPinCommand;
        public ICommand AddPinCommand => _addPinCommand ??=
            SingleExecutionCommand.FromFunc(AddPinCommandCommandAsync);
        
        #endregion

        #region -- Private Helpers

        public async Task AddPinCommandCommandAsync()
        {
            await NavigationService.NavigateAsync(nameof(AddPinPage));
        }

        #endregion
    }
}