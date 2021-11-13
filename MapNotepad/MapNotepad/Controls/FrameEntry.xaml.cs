using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MapNotepad.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FrameEntry : Frame
    {
        public FrameEntry()
        {
            InitializeComponent();
        }
        
        public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(
            propertyName: nameof(Placeholder), 
            returnType: typeof(string),
            declaringType: typeof(FrameEntry), 
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
            declaringType: typeof(FrameEntry), 
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
            declaringType: typeof(FrameEntry), 
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
            declaringType: typeof(FrameEntry), 
            defaultValue: null,
            BindingMode.TwoWay);

        public ICommand ImageCommand
        {
            get => (ICommand)GetValue(ImageCommandProperty);
            set => SetValue(ImageCommandProperty, value);
        }
        
        public static readonly BindableProperty IsImageVisibleProperty = BindableProperty.Create(
            propertyName: nameof(IsImageVisible), 
            returnType: typeof(bool), 
            declaringType: typeof(FrameEntry), 
            defaultValue: false,
            BindingMode.TwoWay);

        public bool IsImageVisible
        {
            get => (bool)GetValue(IsImageVisibleProperty);
            set => SetValue(IsImageVisibleProperty, value);
        }
    }
}