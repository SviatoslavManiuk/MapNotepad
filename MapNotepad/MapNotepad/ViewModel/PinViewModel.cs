using Prism.Mvvm;
using Xamarin.Forms.GoogleMaps;

namespace MapNotepad.ViewModel
{
    public class PinViewModel: BindableBase
    {

        public PinViewModel(int id, int userId, string label, double longitude, double latitude, bool isSelected)
        {
            Id = id;
            UserId = userId;
            Label = label;
            Longitude = longitude.ToString();
            Latitude = latitude.ToString();
            this.Position = new Position(latitude, longitude);
            IsSelected = isSelected;
            
            if (isSelected)
            {
                FavouriteIcon = "ic_like_blue.png";
            }
            else
            {
                FavouriteIcon = "ic_like_grey.png";
            }
        }

        #region -- Public Properties --
        
        public int Id { get; }
        
        public int UserId { get; }
        
        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set => SetProperty(ref _isSelected, value);
        }
        
        private string _favouriteIcon;
        public string FavouriteIcon
        {
            get => _favouriteIcon;
            set => SetProperty(ref _favouriteIcon, value);
        }
        
        private string _label;
        public string Label
        {
            get => _label;
            set => SetProperty(ref _label, value);
        }

        private Position _position;

        public Position Position
        {
            get => _position;
            set => SetProperty(ref _position, value);
        }

        private string _longitude;
        public string Longitude
        {
            get => _longitude;
            set => SetProperty(ref _longitude, value);
        }
        
        private string _latitude;
        public string Latitude
        {
            get => _latitude;
            set => SetProperty(ref _latitude, value);
        }

        #endregion
    }
}