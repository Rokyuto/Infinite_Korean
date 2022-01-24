using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Infinite_Korean
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu_Page : ContentPage
    {
        public Menu_Page()
        {
            InitializeComponent();
        }

        protected override bool OnBackButtonPressed() //On Mobile Back Button Click
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                App.Current.MainPage = new MainPage(); // Go to Previous Page - Start Page
            });
            return true;
            //return base.OnBackButtonPressed();
        }

        private void BackButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new MainPage();
        }

        private void NumbersButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new Categories_Pages.Numbers_Category_Page();
        }

        private void ColorButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new Categories_Pages.ColorsCategory_Level.Colors_Level();
        }

        private void Animals_Button_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new Categories_Pages.Animals_Category_Page();
        }

        private void Animals2_Button_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new Categories_Pages.Animals_2_Category_Page();
        }

        private void Fruits_Button_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new Categories_Pages.Fruit_Category_Page();
        }
    }
}