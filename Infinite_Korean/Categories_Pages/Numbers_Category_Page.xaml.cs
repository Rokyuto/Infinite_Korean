using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Infinite_Korean.Categories_Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Numbers_Category_Page : ContentPage
    {
        public Numbers_Category_Page()
        {
            InitializeComponent();
        }

        private void BackButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new Menu_Page();
        }

        private void LessonButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NumbersCategory_Levels.Lesson_Page();
        }

        private void TranscriptionButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NumbersCategory_Levels.Transcription_Level();
        }

    }
}