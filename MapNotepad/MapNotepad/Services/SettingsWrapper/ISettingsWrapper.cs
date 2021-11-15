namespace MapNotepad.Services.SettingsWrapper
{
    public interface ISettingsWrapper
    {
        int GetAuthorizedUserId();

        void SetAuthorizedUserId(int id);
    }
}