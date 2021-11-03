using MapNotepad.ViewModel;
using Xamarin.Forms;

namespace MapNotepad.View
{
    public class BaseContentPage : ContentPage
    {
        public BaseContentPage()
        {
            BackgroundColor = Color.FromHex("#FEFEFD");
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