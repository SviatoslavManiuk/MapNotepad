using System;
using Prism.Ioc;
using Prism.Unity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MapNotepad
{
    public partial class App : PrismApplication
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        #region --- Overrides ---
        
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }

        protected override void OnInitialized()
        {
            
        }
        
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
        
        #endregion
    }
}
