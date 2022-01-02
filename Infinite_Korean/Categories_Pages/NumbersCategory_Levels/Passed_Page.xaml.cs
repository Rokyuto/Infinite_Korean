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
    public partial class Passed_Page : ContentPage
    {
        public Passed_Page()
        {
            InitializeComponent();
        }

        private void PlayButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new Numbers_Category_Page(); //Go to Catergory Page
        }
    }
}