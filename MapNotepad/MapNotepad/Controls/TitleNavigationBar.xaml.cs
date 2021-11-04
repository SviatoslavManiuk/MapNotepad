using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MapNotepad.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TitleNavigationBar : ContentView
    {
        public TitleNavigationBar()
        {
            InitializeComponent();
        }

        #region -- Public Properties --
        
        //Left Image Properties
        public static readonly BindableProperty LeftImageSourceProperty = 
            BindableProperty.Create("RightImageSource", typeof(string), typeof(TitleNavigationBar), 
                "ic_left_blue.png", BindingMode.TwoWay);

        public string LeftImageSource
        {
            get => (string)GetValue(LeftImageSourceProperty);
            set => SetValue(LeftImageSourceProperty, value);
        }
        
        public static readonly BindableProperty LeftImageCommandProperty = 
            BindableProperty.Create("RightImageSource", typeof(ICommand), typeof(TitleNavigationBar), 
                null, BindingMode.TwoWay);

        public ICommand LeftImageCommand
        {
            get => (ICommand)GetValue(LeftImageCommandProperty);
            set => SetValue(LeftImageCommandProperty, value);
        }
        
        // Label Properties
        public static readonly BindableProperty TextLabelProperty = 
            BindableProperty.Create("RightImageSource", typeof(string), typeof(TitleNavigationBar), 
                string.Empty, BindingMode.TwoWay);

        public string TextLabel
        {
            get => (string)GetValue(TextLabelProperty);
            set => SetValue(TextLabelProperty, value);
        }
        
        public static readonly BindableProperty RightImageSourceProperty = 
            BindableProperty.Create("RightImageSource", typeof(string), typeof(TitleNavigationBar), 
                string.Empty, BindingMode.TwoWay);
        
        //Right Image Properties
        public string RightImageSource
        {
            get => (string)GetValue(RightImageSourceProperty);
            set => SetValue(RightImageSourceProperty, value);
        }
        
        public static readonly BindableProperty RightImageIsVisibleProperty = 
            BindableProperty.Create("RightImageSource", typeof(bool), typeof(TitleNavigationBar), 
                false, BindingMode.TwoWay);

        public bool RightImageIsVisible
        {
            get => (bool)GetValue(RightImageIsVisibleProperty);
            set => SetValue(RightImageIsVisibleProperty, value);
        }
        
        public static readonly BindableProperty RightImageIsEnabledProperty = 
            BindableProperty.Create("RightImageSource", typeof(bool), typeof(TitleNavigationBar), 
                true, BindingMode.TwoWay);

        public bool RightImageIsEnabled
        {
            get => (bool)GetValue(RightImageIsEnabledProperty);
            set => SetValue(RightImageIsEnabledProperty, value);
        }
        
        public static readonly BindableProperty RightImageCommandProperty = 
            BindableProperty.Create("RightImageSource", typeof(ICommand), typeof(TitleNavigationBar), 
                null, BindingMode.TwoWay);

        public ICommand RightImageCommand
        {
            get => (ICommand)GetValue(RightImageCommandProperty);
            set => SetValue(RightImageCommandProperty, value);
        }
        
        #endregion
        
    }
}