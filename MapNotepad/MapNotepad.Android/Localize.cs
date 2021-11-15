using MapNotepad.Services.TranslateService;
using Xamarin.Forms;
[assembly: Dependency(typeof(MapNotepad.Droid.Localize))]
namespace MapNotepad.Droid
{
    public class Localize : ILocalize
    {
        public System.Globalization.CultureInfo GetCurrentCultureInfo()
        {
            var androidLocale = Java.Util.Locale.Default;
            var netLanguage = androidLocale.ToString().Replace("_", "-");
            return new System.Globalization.CultureInfo(netLanguage);
        }
    }
}