using Xamarin.Essentials;

namespace MapNotepad.Services.Settings
{
    public class SettingsManager: ISettingsManager
    {
        public int UserId
        {
            get => Preferences.Get(nameof(UserId), -1);
            set => Preferences.Set(nameof(UserId), value);
        }
    }
}