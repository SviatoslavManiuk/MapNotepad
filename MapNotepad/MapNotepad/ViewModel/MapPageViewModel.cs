// TODO: replace exceptions on some logic

using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using MapNotepad.Helpers;
using MapNotepad.Services.EntityServices;
using MapNotepad.Services.Extensions;
using Prism.Navigation;

namespace MapNotepad.ViewModel
{
    public class MapPageViewModel:BaseViewModel
    {
        private PinService _pinService;
        public MapPageViewModel(INavigationService navigationService, PinService pinService) : base(navigationService)
        {
            _pinService = pinService;
            IsEntryImageVisible = false;
        }

        #region -- Public Properties --
        
        private ObservableCollection<PinViewModel> _pins;
        public ObservableCollection<PinViewModel> Pins
        {
            get => _pins;
            set => SetProperty(ref _pins, value);
        }
        
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

        #region -- Overrides --

        public override async void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);

            int authorizedUserId = (int)parameters[Constants.Navigation.AUTHORIZED_USER_ID_PARAMETER];
            
            var result =  await _pinService.GetPinsByUserAsync(authorizedUserId);
            if (result.IsSuccess)
            {
                Pins = new ObservableCollection<PinViewModel>(result.Result.Select(pin => pin.ToPinViewModel()));
            }
            else
            {
                throw new Exception();
            }
        }

        #endregion

        #region -- Private Helpers

        public async Task OnUserLocationCommandAsync()
        {
        }

        #endregion
    }
}