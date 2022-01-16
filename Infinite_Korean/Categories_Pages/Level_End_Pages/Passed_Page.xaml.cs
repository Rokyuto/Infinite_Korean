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

        //Numbers Page Levels
    /*    string Transcription_Level = "Transcription";
        string Symbol_Level = "Symbol";
        string Translate_Level = "Translate"; */

        public Passed_Page()
        {
            InitializeComponent();
            UpdateCongrats_Text();
        }

        private void UpdateCongrats_Text()
        {
            switch (Numbers_Category_Page.LevelAdress)
            {
                case "Transcription":
                    Page_Congrats_Text.Text = "You complete the Numbers Transcription Lesson";
                    break;
                case "Symbol":
                    Page_Congrats_Text.Text = "You complete the Numbers Symbol Lesson";
                    break;
                case "Translate":
                    Page_Congrats_Text.Text = "You complete the Numbers Translate Lesson";
                    break;
            }
        }

        private void Play_Button_Clicked(object sender, EventArgs e)
        {
            if (ColorsCategory_Level.Colors_Level.PageAdress == Color_Page)
            {
                App.Current.MainPage = new ColorsCategory_Level.Colors_Level();
            }
            if (Numbers_Category_Page.PageAdress == Numbers_Page)
            {
                App.Current.MainPage = new Numbers_Category_Page();
            }
        }
    }
}