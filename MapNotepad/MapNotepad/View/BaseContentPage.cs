using MapNotepad.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace MapNotepad.View
{
    public class BaseContentPage : ContentPage
    {
        public BaseContentPage()
        {
            BackgroundColor = Color.FromHex(Colors.BASE_COLOR);
            On<iOS>().SetUseSafeArea(true);
        }

        #region -- Overrides --

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (BindingContext is IAppearingAware)
            {
               var context =  (IAppearingAware) BindingContext;
               if (context != null)
               {
                   context.OnAppearing();
               }
            }
        }
        
        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            if (BindingContext is IAppearingAware)
            {
                var context =  (IAppearingAware) BindingContext;
                if (context != null)
                {
                    context.OnDisappearing();
                }
            }
        }

        #endregion
    }
}