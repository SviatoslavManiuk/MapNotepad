using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MapNotepad.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchNavigationBar : ContentView
    {
        public SearchNavigationBar()
        {
            InitializeComponent();
        }
        
        #region -- Public Properties --
        
        public static readonly BindableProperty LeftImageSourceProperty = BindableProperty.Create(
            propertyName: nameof(LeftImageSource),
            returnType: typeof(string), 
            declaringType: typeof(SearchNavigationBar), 
            defaultValue: "ic_settings.png",
            BindingMode.TwoWay);

        public string LeftImageSource
        {
            get => (string)GetValue(LeftImageSourceProperty);
            set => SetValue(LeftImageSourceProperty, value);
        }
        
        public static readonly BindableProperty LeftImageCommandProperty = BindableProperty.Create(
             propertyName: nameof(LeftImageCommand), 
             returnType: typeof(ICommand), 
             declaringType: typeof(SearchNavigationBar), 
             defaultValue: null,
             BindingMode.TwoWay);

        public ICommand LeftImageCommand
        {
            get => (ICommand)GetValue(LeftImageCommandProperty);
            set => SetValue(LeftImageCommandProperty, value);
        }
        
        public static readonly BindableProperty TextProperty = BindableProperty.Create(
            propertyName: nameof(Text), 
            returnType: typeof(string),
            declaringType: typeof(SearchNavigationBar), 
            defaultValue: string.Empty,
            BindingMode.TwoWay);
        
        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }
        
        public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(
            propertyName: nameof(Placeholder), 
            returnType: typeof(string),
            declaringType: typeof(SearchNavigationBar), 
            defaultValue: string.Empty,
            BindingMode.TwoWay);
        
        public string Placeholder
        {
            get => (string)GetValue(PlaceholderProperty);
            set => SetValue(PlaceholderProperty, value);
        }

        public static readonly BindableProperty EntryBackgroundProperty = BindableProperty.Create(
            propertyName: nameof(EntryBackground), 
            returnType: typeof(Color), 
            declaringType: typeof(SearchNavigationBar), 
            defaultValue: Color.FromHex(Colors.SEARCH_ENTRY_COLOR),
            BindingMode.TwoWay);

        public Color EntryBackground
        {
            get => (Color)GetValue(EntryBackgroundProperty);
            set => SetValue(EntryBackgroundProperty, value);
        }
        
        public static readonly BindableProperty EntryImageCommandProperty = BindableProperty.Create(
            propertyName: nameof(EntryImageCommand), 
            returnType: typeof(ICommand), 
            declaringType: typeof(SearchNavigationBar), 
            defaultValue: null,
            BindingMode.TwoWay);

        public ICommand EntryImageCommand
        {
            get => (ICommand)GetValue(EntryImageCommandProperty);
            set => SetValue(EntryImageCommandProperty, value);
        }
        
        public static readonly BindableProperty IsEntryImageVisibleProperty = BindableProperty.Create(
            propertyName: nameof(IsEntryImageVisible), 
            returnType: typeof(bool), 
            declaringType: typeof(SearchNavigationBar), 
            defaultValue: false,
            BindingMode.TwoWay);

        public bool IsEntryImageVisible
        {
            get => (bool)GetValue(IsEntryImageVisibleProperty);
            set => SetValue(IsEntryImageVisibleProperty, value);
        }

        public static readonly BindableProperty RightImageSourceProperty = BindableProperty.Create(
            propertyName: nameof(RightImageSource), 
            returnType: typeof(string), 
            declaringType: typeof(SearchNavigationBar), 
            defaultValue: "ic_exid.png",
            BindingMode.TwoWay);
        
        public string RightImageSource
        {
            get => (string)GetValue(RightImageSourceProperty);
            set => SetValue(RightImageSourceProperty, value);
        }

        public static readonly BindableProperty RightImageCommandProperty = BindableProperty.Create(
            propertyName: nameof(RightImageCommand), 
            returnType: typeof(ICommand), 
            declaringType: typeof(SearchNavigationBar), 
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