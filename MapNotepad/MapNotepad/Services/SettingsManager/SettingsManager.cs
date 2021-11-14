using Xamarin.Essentials;

namespace MapNotepad.Services.SettingsManager
{
    public class SettingsManager: ISettingsManager
    {
        public int AuthorizedUserId
        {
            get => Preferences.Get(nameof(AuthorizedUserId), -1);
            set => Preferences.Set(nameof(AuthorizedUserId), value);
        }
    }
}