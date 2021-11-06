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
        
        public static readonly BindableProperty LeftImageSourceProperty = BindableProperty.Create(
            propertyName: nameof(LeftImageSource),
            returnType: typeof(string), 
            declaringType: typeof(TitleNavigationBar), 
            defaultValue: "ic_left_blue.png",
            BindingMode.TwoWay);

        public string LeftImageSource
        {
            get => (string)GetValue(LeftImageSourceProperty);
            set => SetValue(LeftImageSourceProperty, value);
        }
        
        public static readonly BindableProperty LeftImageCommandProperty = BindableProperty.Create(
             propertyName: nameof(LeftImageCommand), 
             returnType: typeof(ICommand), 
             declaringType: typeof(TitleNavigationBar), 
             defaultValue: null,
             BindingMode.TwoWay);

        public ICommand LeftImageCommand
        {
            get => (ICommand)GetValue(LeftImageCommandProperty);
            set => SetValue(LeftImageCommandProperty, value);
        }
        
        public static readonly BindableProperty TitleProperty = BindableProperty.Create(
                propertyName: nameof(Title), 
                returnType: typeof(string), 
                declaringType: typeof(TitleNavigationBar), 
                defaultValue: string.Empty,
                BindingMode.TwoWay);

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }
        
        public static readonly BindableProperty RightImageSourceProperty = BindableProperty.Create(
            propertyName: nameof(RightImageSource), 
            returnType: typeof(string), 
            declaringType: typeof(TitleNavigationBar), 
            defaultValue: string.Empty,
            BindingMode.TwoWay);
        
        public string RightImageSource
        {
            get => (string)GetValue(RightImageSourceProperty);
            set => SetValue(RightImageSourceProperty, value);
        }
        
        public static readonly BindableProperty RightImageIsVisibleProperty = BindableProperty.Create(
            propertyName: nameof(RightImageIsVisible), 
            returnType: typeof(bool),
            declaringType: typeof(TitleNavigationBar), 
            defaultValue: true,
            BindingMode.TwoWay);

        public bool RightImageIsVisible
        {
            get => (bool)GetValue(RightImageIsVisibleProperty);
            set => SetValue(RightImageIsVisibleProperty, value);
        }
        
        public static readonly BindableProperty RightImageIsEnabledProperty = BindableProperty.Create(
            propertyName: nameof(RightImageIsEnabled), 
            returnType: typeof(bool), 
            declaringType: typeof(TitleNavigationBar), 
            defaultValue: true,
            BindingMode.TwoWay);

        public bool RightImageIsEnabled
        {
            get => (bool)GetValue(RightImageIsEnabledProperty);
            set => SetValue(RightImageIsEnabledProperty, value);
        }
        
        public static readonly BindableProperty RightImageCommandProperty = BindableProperty.Create(
            propertyName: nameof(RightImageCommand), 
            returnType: typeof(ICommand), 
            declaringType: typeof(TitleNavigationBar), 
            defaultValue: null,
            BindingMode.TwoWay);

        public ICommand RightImageCommand
        {
            get => (ICommand)GetValue(RightImageCommandProperty);
            set => SetValue(RightImageCommandProperty, value);
        }
        
        #endregion
        
    }
}