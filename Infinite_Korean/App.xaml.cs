using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Infinite_Korean
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
            Device.SetFlags(new[] { "Brush_Experimental" }); //Add Brush Experiment for Images
            //NavigationPage.SetHasNavigationBar(this, false); // Set Navigation Bar HIDDEN
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
