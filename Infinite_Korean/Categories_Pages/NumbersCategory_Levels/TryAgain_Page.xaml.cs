using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Infinite_Korean.Categories_Pages.NumbersCategory_Levels
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TryAgain_Page : ContentPage
    {
        public TryAgain_Page()
        {
            InitializeComponent();
        }

        private void TryButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new Transcription_Level();
        }
    }
}