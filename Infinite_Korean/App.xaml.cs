﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Infinite_Korean
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Device.SetFlags(new[] { "Brush_Experimental" });
            NavigationPage.SetHasNavigationBar(this, false);
            MainPage = new MainPage();
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
