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
    public partial class TryAgain_Page : ContentPage
    {

        //Variables
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

        public TryAgain_Page()
        {
            InitializeComponent();
        }

        private void TryAgain_Button_Clicked(object sender, EventArgs e)
        {
            if (Passed_Page.PageAdress == Color_Page)
            {
                Passed_Page.PageAdress = "";
                App.Current.MainPage = new ColorsCategory_Level.Colors_Level();
            }
            else if (Passed_Page.PageAdress == Numbers_Page)
            {
                Passed_Page.PageAdress = "";
                App.Current.MainPage = new Numbers_Category_Page();
            }
            else if(Passed_Page.PageAdress == Animals_Page)
            {
                Passed_Page.PageAdress = "";
                App.Current.MainPage = new Animals_Category_Page();
            }
            else if (Passed_Page.PageAdress == Animals_2_Page)
            {
                Passed_Page.PageAdress = "";
                App.Current.MainPage = new Animals_2_Category_Page();
            }
            else if(Passed_Page.PageAdress == Fruits_Page)
            {
                Passed_Page.PageAdress = "";
                App.Current.MainPage = new Fruit_Category_Page();
            }
            else if(Passed_Page.PageAdress == Vegetables_Page)
            {
                Passed_Page.PageAdress = "";
                App.Current.MainPage = new Vegetables_Category_Page();
            }
            else if(Passed_Page.PageAdress == Meats_Page)
            {
                Passed_Page.PageAdress = "";
                App.Current.MainPage = new Meats_Category_Page();
            }
            else if(Passed_Page.PageAdress == Drinks_Page)
            {
                Passed_Page.PageAdress = "";
                App.Current.MainPage = new Drinks_Category_Page();
            }
            else if(Passed_Page.PageAdress == Clothes_Page)
            {
                Passed_Page.PageAdress = "";
                App.Current.MainPage = new Clothes_Category_Page();
            }
            else if(Passed_Page.PageAdress == Weather_Page)
            {
                Passed_Page.PageAdress = "";
                App.Current.MainPage = new Weather_Category_Page();
            }
            else if(Passed_Page.PageAdress == Week_Page)
            {
                Passed_Page.PageAdress = "";
                App.Current.MainPage = new Week_Category_Page();
            }
            else if (Passed_Page.PageAdress == Months_Page)
            {
                Passed_Page.PageAdress = "";
                App.Current.MainPage = new Months_Category_Page();
            }
        }

    }
}