using System;
using MapNotepad.Model;
using MapNotepad.ViewModel;

namespace MapNotepad.Services.Extensions
{
    public static class PinExtension
    {
        public static PinViewModel ToPinViewModel(this PinModel pin)
        {
            return new PinViewModel(pin.Id, pin.UserId, pin.Label, pin.Longitude, pin.Latitude, pin.IsSelected);
        }

        public static PinModel ToPinModel(this PinViewModel pinViewModel)
        {
            Double.TryParse(pinViewModel.Longitude, out double longitude);
            Double.TryParse(pinViewModel.Latitude, out double latitude);

            return new PinModel()
            {
                Id = pinViewModel.Id,
                UserId = pinViewModel.UserId,
                Label = pinViewModel.Label,
                Longitude = longitude,
                Latitude = latitude,
                IsSelected = pinViewModel.IsSelected
            };
        }
    }
}