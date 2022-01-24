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
        }

    }
}