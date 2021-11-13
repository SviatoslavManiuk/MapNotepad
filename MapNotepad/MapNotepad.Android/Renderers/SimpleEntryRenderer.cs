using Android.Content;
using MapNotepad.Controls;
using MapNotepad.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


[assembly: ExportRenderer(typeof(SimpleEntry), typeof(SimpleEntryRenderer))]
namespace MapNotepad.Droid.Renderers
{
    public class SimpleEntryRenderer : EntryRenderer
    {
        public SimpleEntryRenderer(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> args)
        {
            base.OnElementChanged(args);
            if (Control != null)
            {
                Control.SetBackgroundColor(Android.Graphics.Color.Transparent);
                Control.SetPadding(0,0,0,0);
            }
        }
    }
}