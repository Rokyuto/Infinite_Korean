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

        public static string PageAdress; //Initialize from which Page Player is comming
        public static string LevelAdress; //Initialize which Level is Passed

        //Levels
        string Category; //Initialize which Category the Player is in
        public static string Passed_Level; //Initialize which Level the Player is Passed 

        //Categories
        string Numbers_Page = "Numbers";
        string Color_Page = "Colors";
        string Animals_Page = "Animals";
        string Animals_2_Page = "Animals_2";

        public static int Stars; //Count Player Mistakes when he Pass Level

        public Passed_Page()
        {
            InitializeComponent();
            UpdateCongrats_Text();
        }

        private void UpdateCongrats_Text()
        {
            switch(Stars)
            {
                case 3:
                    Star_3.IsVisible = true;
                    break;
                case 2:
                    Star_2.IsVisible = true;
                    break;
                case 1:
                    Star_1.IsVisible = true;
                    break;
            }

            switch (LevelAdress)
            {
                case "Transcription":
                    Passed_Level = "Transcription"; //Player Passed Transcription Level
                    break;
                case "Symbol":
                    Passed_Level = "Symbol"; //Player Passed Symbol Level
                    break;
                case "Translate":
                    Passed_Level = "Translate"; //Player Passed Translate Level
                    break;
            }

            switch(PageAdress)
            {
                case "Numbers":
                    Category = "Numbers"; //Player is in Numbers Category
                    break;
                case "Colors":
                    Category = "Colors"; //Player is in Colors Category
                    break;
                case "Animals":
                    Category = "Animals";
                    break;
                case "Animals_2":
                    Category = "Animals 2";
                    break;
            }

            Page_Congrats_Text.Text = "You complete the " + Category + " " + Passed_Level + " Lesson";
        }

        private void Play_Button_Clicked(object sender, EventArgs e)
        {
            if (PageAdress == Numbers_Page)
            {   
                App.Current.MainPage = new Numbers_Category_Page();
            }
            if (PageAdress == Color_Page)
            {
                App.Current.MainPage = new ColorsCategory_Level.Colors_Level();
            }
            if(PageAdress == Animals_Page)
            {
                App.Current.MainPage = new Animals_Category_Page();
            }
            if (PageAdress == Animals_2_Page)
            {
                App.Current.MainPage = new Animals_2_Category_Page();
            }
        }
    }
}