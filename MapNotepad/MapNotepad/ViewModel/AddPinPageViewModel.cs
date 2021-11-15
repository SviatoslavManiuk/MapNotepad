using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MapNotepad.Helpers;
using MapNotepad.Model;
using MapNotepad.Services.EntityServices;
using MapNotepad.Services.Extensions;
using Prism.Navigation;

namespace MapNotepad.ViewModel
{
    // TODO: replace exceptions on some logic
    public class AddPinPageViewModel : BaseViewModel
    {
        private PinService _pinService;
        
        private int _userId;
        private int _pinId;
        private double _longitude;
        private double _latitude;
        private bool _isSelected;
        
        public AddPinPageViewModel(INavigationService navigationService, PinService pinService) : base(navigationService)
        {
            _pinService = pinService;
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

        private string _longitudeEntry;

        public string LongitudeEntry
        {
            get => _longitudeEntry;
            set => SetProperty(ref _longitudeEntry, value);
        }
        
        private string _latitudeEntry;

        public string LatitudeEntry
        {
            get => _latitudeEntry;
            set => SetProperty(ref _latitudeEntry, value);
        }

        private ICommand _backButtonCommand;
        public ICommand BackButtonCommand => _backButtonCommand ??=
            SingleExecutionCommand.FromFunc(OnBackButtonCommandAsync);

        private ICommand _saveCommand;
        public ICommand SaveCommand => _saveCommand ??= 
            SingleExecutionCommand.FromFunc(OnSaveCommandAsync);
        
        #endregion

        #region -- Overrides --

        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);
            
            var parameter = parameters[nameof(PinModel)];
            if (parameter is PinModel pin)
            {
                _pinId = pin.Id;
                _userId = pin.UserId;
                
                if (pin.Id == 0)
                {
                    _isSelected = true;
                    Title = "Add pin";
                }
                else
                {
                    Label = pin.Label;
                    Description = pin.Description;
                    _longitude = pin.Longitude;
                    LongitudeEntry = pin.Longitude.ToString();
                    _latitude = pin.Latitude;
                    LatitudeEntry = pin.Latitude.ToString();
                    _isSelected = pin.IsSelected;
                    Title = "Edit pin";
                }
            }
            else
            {
                throw new Exception();
            }
        }

        #endregion

        #region -- Private Helpers --
        
        private async Task OnSaveCommandAsync()
        {
            var pin = new PinModel()
            {
                UserId = _userId,
                Label = Label,
                Description = Description,
                Longitude = _longitude,
                Latitude = _latitude,
                IsSelected = _isSelected
            };
            
            var parameters = new NavigationParameters();
            
            if (_pinId == 0)
            {
                await _pinService.InsertAsync(pin);
                var result = await _pinService.FindByCoordinatesAsync(_longitude, _latitude);
                if (result.IsSuccess)
                {
                    pin.Id = result.Result.Id;
                    parameters.Add(Constants.Navigation.NEW_PIN_PARAMETER, pin.ToPinViewModel());
                }
                else
                {
                    throw new Exception();
                }
            }
            else
            {
                pin.Id = _pinId;
                await _pinService.UpdateAsync(pin);
                parameters.Add(Constants.Navigation.EDITED_PIN_PARAMETER, pin.ToPinViewModel());
            }

            await NavigationService.GoBackAsync(parameters);
        }
        
        #endregion
    }
}