using System.Globalization;

namespace MapNotepad.Services.TranslateService
{
    public interface ILocalize
    {
        CultureInfo GetCurrentCultureInfo();
    }
}