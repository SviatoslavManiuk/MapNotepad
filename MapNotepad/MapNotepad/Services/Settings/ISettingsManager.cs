namespace MapNotepad.Services.Settings
{
    public interface ISettingsManager
    {
        int UserId { get; set; }
        int SelectedSort { get; set; }
    }
}