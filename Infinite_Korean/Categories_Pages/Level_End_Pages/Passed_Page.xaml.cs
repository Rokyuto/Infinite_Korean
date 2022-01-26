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
        string Fruits_Page = "Fruits";
        string Vegetables_Page = "Vegetables";
        string Meats_Page = "Meats";
        string Drinks_Page = "Drinks";
        string Clothes_Page = "Clothes";
        string Weather_Page = "Weather";
        string Week_Page = "Week";
        string Months_Page = "Months";

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
                case "Fruits":
                    Category = "Fruits";
                    break;
                case "Vegetables":
                    Category = "Vegetables";
                    break;
                case "Meats":
                    Category = "Meats";
                    break;
                case "Drinks":
                    Category = "Drinks";
                    break;
                case "Clothes":
                    Category = "Vegetables";
                    break;
                case "Weather":
                    Category = "Meats";
                    break;
                case "Week":
                    Category = "Week";
                    break;
                case "Months":
                    Category = "Months";
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
            if (PageAdress == Fruits_Page)
            {
                App.Current.MainPage = new Fruit_Category_Page();
            }
            if(PageAdress == Vegetables_Page)
            {
                App.Current.MainPage = new Vegetables_Category_Page();
            }
            if(PageAdress == Meats_Page)
            { 
                App.Current.MainPage = new Meats_Category_Page();
            }
            if(PageAdress == Drinks_Page)
            {
                App.Current.MainPage = new Drinks_Category_Page();
            }
            if (PageAdress == Clothes_Page)
            {
                App.Current.MainPage = new Clothes_Category_Page();
            }
            if (PageAdress == Weather_Page)
            {
                App.Current.MainPage = new Weather_Category_Page();
            }
            if (PageAdress == Week_Page)
            {
                App.Current.MainPage = new Week_Category_Page();
            }
            if (PageAdress == Months_Page)
            {
                App.Current.MainPage = new Months_Category_Page();
            }
        }
    }
}