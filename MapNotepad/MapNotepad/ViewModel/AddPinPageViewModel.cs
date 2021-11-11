using System.Threading.Tasks;
using System.Windows.Input;
using MapNotepad.Helpers;
using Prism.Navigation;

namespace MapNotepad.ViewModel
{
    public class AddPinPageViewModel : BaseViewModel
    {
        public AddPinPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Add Pin";
        }
        
        #region -- Public Properties --

        public string Title { get; private set; }

        private string _label;

        public string Label
        {
            get => _label;
            set => SetProperty(ref _label, value);
        }
        
        private string _description;

        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }
        
        private double _longitude;

        public double Longitude
        {
            get => _longitude;
            set => SetProperty(ref _longitude, value);
        }
        
        private double _latitude;

        public double Latitude
        {
            get => _latitude;
            set => SetProperty(ref _latitude, value);
        }

        private ICommand _backButtonCommand;
        public ICommand BackButtonCommand => _backButtonCommand ??=
            SingleExecutionCommand.FromFunc(OnBackButtonCommandAsync);

        private ICommand _saveCommand;
        public ICommand SaveCommand => _saveCommand ??= 
            SingleExecutionCommand.FromFunc(OnSaveCommandAsync);
        
        #endregion

        #region -- Private Helpers --

        private async Task OnSaveCommandAsync()
        {
        }
        
        #endregion
    }
}