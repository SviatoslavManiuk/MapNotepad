using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MapNotepad.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExtendedEntry : ContentView
    {
        public ExtendedEntry()
        {
            InitializeComponent();
        }
        
        #region -- Public Properties --
        
        public static readonly BindableProperty EntryTitleProperty = BindableProperty.Create(
            propertyName: nameof(EntryTitle), 
            returnType: typeof(string), 
            declaringType: typeof(ExtendedEntry), 
            defaultValue: string.Empty,
            BindingMode.TwoWay);

        public string EntryTitle
        {
            get => (string)GetValue(EntryTitleProperty);
            set => SetValue(EntryTitleProperty, value);
        }
        
        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(
            propertyName: nameof(BorderColor), 
            returnType: typeof(Color), 
            declaringType: typeof(ExtendedEntry), 
            defaultValue: Color.FromHex(Colors.ENTRY_BORDER_COLOR),
            BindingMode.TwoWay);

        public Color BorderColor
        {
            get => (Color)GetValue(BorderColorProperty);
            set => SetValue(BorderColorProperty, value);
        }
        
        public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(
            propertyName: nameof(Placeholder), 
            returnType: typeof(string),
            declaringType: typeof(ExtendedEntry), 
            defaultValue: string.Empty,
            BindingMode.TwoWay);

        public string Placeholder
        {
            get => (string)GetValue(PlaceholderProperty);
            set => SetValue(PlaceholderProperty, value);
        }
        
        public static readonly BindableProperty TextProperty = BindableProperty.Create(
            propertyName: nameof(Text), 
            returnType: typeof(string),
            declaringType: typeof(ExtendedEntry), 
            defaultValue: string.Empty,
            BindingMode.TwoWay);

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }
        
        public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create(
            propertyName: nameof(ImageSource), 
            returnType: typeof(string),
            declaringType: typeof(ExtendedEntry), 
            defaultValue: string.Empty,
            BindingMode.TwoWay);

        public string ImageSource
        {
            get => (string)GetValue(ImageSourceProperty);
            set => SetValue(ImageSourceProperty, value);
        }
        
        public static readonly BindableProperty ImageCommandProperty = BindableProperty.Create(
            propertyName: nameof(ImageCommand), 
            returnType: typeof(ICommand),
            declaringType: typeof(ExtendedEntry), 
            defaultValue: null,
            BindingMode.TwoWay);

        public ICommand ImageCommand
        {
            get => (ICommand)GetValue(ImageCommandProperty);
            set => SetValue(ImageCommandProperty, value);
        }

        public static readonly BindableProperty ErrorTextProperty = BindableProperty.Create(
            propertyName: nameof(ErrorText), 
            returnType: typeof(string),
            declaringType: typeof(ExtendedEntry), 
            defaultValue: string.Empty,
            BindingMode.TwoWay);

        public string ErrorText
        {
            get => (string)GetValue(ErrorTextProperty);
            set => SetValue(ErrorTextProperty, value);
        }
        
        public static readonly BindableProperty ErrorIsVisibleProperty = BindableProperty.Create(
            propertyName: nameof(ErrorIsVisible), 
            returnType: typeof(bool),
            declaringType: typeof(ExtendedEntry), 
            defaultValue: false,
            BindingMode.TwoWay);

        public bool ErrorIsVisible
        {
            get => (bool)GetValue(ErrorIsVisibleProperty);
            set => SetValue(ErrorIsVisibleProperty, value);
        }
        
        #endregion
    }
}