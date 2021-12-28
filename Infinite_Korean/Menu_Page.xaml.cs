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

        }
    }
}