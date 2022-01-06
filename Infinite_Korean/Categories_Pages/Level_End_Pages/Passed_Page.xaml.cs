using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Infinite_Korean.Categories_Pages.Level_End_Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Passed_Page : ContentPage
    {
        //Variables
        string Numbers_Page = "Numbers";
        string Color_Page = "Colors";

        public Passed_Page()
        {
            InitializeComponent();
        }

        private void Play_Button_Clicked(object sender, EventArgs e)
        {
            if (ColorsCategory_Level.Colors_Level.PageAdress == Color_Page)
            {
                App.Current.MainPage = new ColorsCategory_Level.Colors_Level();
            }
            if (NumbersCategory_Levels.Transcription_Level.PageAdress == Numbers_Page)
            {
                App.Current.MainPage = new Numbers_Category_Page();
            }
        }
    }
}