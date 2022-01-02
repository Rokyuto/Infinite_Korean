﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Infinite_Korean.Categories_Pages.NumbersCategory_Levels
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Lesson_Page : ContentPage
    {
        public Lesson_Page()
        {
            InitializeComponent();
        }

        private void BackButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new Numbers_Category_Page(); //Return to Previous Page
        }
    }
}