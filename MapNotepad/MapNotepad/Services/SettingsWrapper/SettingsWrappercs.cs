using MapNotepad.Services.SettingsManager;
using Xamarin.Essentials;

namespace MapNotepad.Services.SettingsWrapper
{
    public class SettingsWrapper: ISettingsWrapper
    {
        private ISettingsManager _settingsManager;
        public SettingsWrapper(ISettingsManager settingsManager)
        {
            _settingsManager = settingsManager;
        }

        public int GetAuthorizedUserId()
        {
            return _settingsManager.AuthorizedUserId;
        }
        
        public void SetAuthorizedUserId(int id)
        {
            _settingsManager.AuthorizedUserId = id;
        }
    }
}