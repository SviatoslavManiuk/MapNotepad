using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MapNotepad.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : BaseContentPage
    {
        public MapPage()
        {
            InitializeComponent();

            map.UiSettings.ZoomControlsEnabled = false;
        }
    }
}