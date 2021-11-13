using Prism.Mvvm;

namespace MapNotepad.ViewModel
{
    public class PinViewModel: BindableBase
    {
        public PinViewModel()
        {
            FavouriteIcon = "ic_like_blue.png";
        }

        #region -- Public Properties --

        private string _favouriteIcon;
        public string FavouriteIcon
        {
            get => _favouriteIcon;
            set => SetProperty(ref _favouriteIcon, value);
        }
        
        #endregion
    }
}