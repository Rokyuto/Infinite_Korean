using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Infinite_Korean.Categories_Pages.ColorsCategory_Level
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Colors_Level : ContentPage
    {

        Random MyRandom = new Random();
        //Variables

        //Category Variables
        int My_Button_Pressed = 0; //Track for which Button is pressed 
        string Loaded_Level; //Track what happen with Page - Is it Category, Transcription, Symbol or Translation Page

        //Levels Variables

        //Transcriptions
        string[] Colors_Transcription_Arr = { "", "", "", "", "", "" }; //Array with Korean Colors Transcription
        string[] Colors_Transcription_Lvl2_Arr = { "", "", "", "", "" }; //Array with Korean Colors Transcription Lvl 2
        //Symbols
        string[] Colors_Symbol_Arr = { "", "", "", "", "", "" }; //Array with Korean Colors Symbols - Guess Words
        string[] Colors_Symbol_Lvl2_Arr = { "", "", "", "", "" }; //Array with Korean Colors Symbols Lvl 2 - Guess Words
        //Translate
        string[] Colors_Translate_Arr = {"white", "black", "red","blue","pirple","green"}; //Array with Korean Symbols Meaning - Answers
        string[] Colors_Translate_Lvl2_Arr = { "yellow", "orange", "pink", "gray", "brown" }; //Array with Korean Symbol Meaning - Answers - Lvl 2

        //Lists
        List<string> Colors_Transcription_List = new List<string>(); //Transcription List
        List<string> Colors_Symbol_List = new List<string>(); //Symbol List 
        List<string> Colors_Translate_List = new List<string>(); //Translate List

        //Mutual for All Levels Variables 
        int Elements_Quantity = 6; //Quantity of Colors in the list [0 - 5]
        int GenIndex; //Generate Guess Word
        int CorAswIndex; //Button with Correct Answer
        string SymbolCorrect_Ans; //Symbol Level Correct Answer

        int PlayerScore_Correct; //Player Correct Score
        int PlayerScore_Wrong; //Player Wrong Score
        int Level2_Req = 10; //Requarment for Level 2

        //Score Requarments for Transcription Level
        int Max_PlayerCorrectScore = 0;
        int Max_PlayerWrongScore = 0;

        //Score Requarments for Symbol Level
        int Level3_Req = 50;//Requarment for Level 3 in Symbol Level

        public static string PageAdress; //Initialize to which Page to Append End Level Pages ( Passed Page and Try Again Page )
        public static string LevelAdress; //Initialize to which Level to Append End Level Pages ( Passed Page and Try Again Page )

        public Colors_Level()
        {
            InitializeComponent();

            //On Page Load
            Level_Load();
        }

        private void Level_Load() //Page Load
        {
            //Set Buttons Texts
            LessonButton_Label.Text = "Lesson";
            Button1_Label.Text = "Transcription";
            Button2_Label.Text = "Symbols";
            Button3_Label.Text = "Translation";
            Title_Label.Text = "Colors";

            //Hide Levels Items
            GuessWordBGD.IsVisible = false; //Guess Word Background
            GuessWord_Label.IsVisible = false; //Guess Word
            Instruction_Label.IsVisible = false; //Instructions
            Scores_Grid.IsVisible = false; //Score Items 

            Loaded_Level = "Categories"; //Set the Page is Category Page
            SetButtonsImg();
        }

        private void SetButtonsImg() //Set Buttons Images
        {
            //Set Buttons Images
            My_Button1.Source="Button_Default.png";
            My_Button2.Source="Button_Default.png";
            My_Button3.Source="Button_Default.png";

            //Set Buttons are ENABLED
            My_Button1.IsEnabled = true;
            My_Button2.IsEnabled = true;
            My_Button3.IsEnabled = true;
        }

        private void BackButton_Clicked(object sender, EventArgs e)
        {
            BackFunc();
        }

        private void BackFunc() //Return to Previous Page
        {
            if (Loaded_Level == "Categories") //If Player is in Category Page
            {
                App.Current.MainPage = new Menu_Page(); //Back Button Navigate to Menu Page
            }
            else //If Player isn't in Category Page
            {
                BackInLevelFunc(); //Player Stay in the SAME Page
            }
        }

        private void BackInLevelFunc() //Update Current Page
        {
            //Update Page - Set to Category Page
            Loaded_Level = "Categories";

            //Update Page Title
            Title_Label.Text = "Colors";
            Title_Label.FontSize = 40;

            //Show Buttons
            Lesson_Button.IsVisible = true;
            My_Button1.IsVisible = true;
            My_Button2.IsVisible = true;
            My_Button3.IsVisible = true;
            Title_Label.IsVisible = true;

            //Hide Level UI Items
            GuessWordBGD.IsVisible = false;
            GuessWord_Label.IsVisible = false;
            Instruction_Label.IsVisible = false;
            Scores_Grid.IsVisible = false; //Hide Scores Items

            //Update Player Scores
            PlayerScore_Correct = 0;
            PlayerScore_Wrong = 0;

            LessonText_Grid.IsVisible = false; //Hide Lesson Text

            //Show Lesson Button
            Lesson_Button.IsVisible = true;
            LessonButton_Label.IsVisible = true;

            //Set Buttons Text
            LessonButton_Label.Text = "Lesson";
            Button1_Label.Text = "Transcription";
            Button2_Label.Text = "Symbols";
            Button3_Label.Text = "Translation";

            SetButtonsImg();

        }

        protected override bool OnBackButtonPressed() //On Mobile Back Button Click
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                BackFunc(); //Call Back Function to go to Previous Page 
            });
            return true;
            //return base.OnBackButtonPressed();
        }

        private void Lesson_Button_Clicked(object sender, EventArgs e) //On Lesson Button Click
        {
            My_Button_Pressed = 0;
            //Hide Buttons
            Lesson_Button.IsVisible = false;
            My_Button1.IsVisible = false;
            My_Button2.IsVisible = false;
            My_Button3.IsVisible = false;
            //Hide Texts
            LessonButton_Label.Text = "";
            Button1_Label.Text = "";
            Button2_Label.Text = "";
            Button3_Label.Text = "";

            //Call Functions
            Build_Level();
        }

        private void My_Button1_Clicked(object sender, EventArgs e)
        {
            My_Button_Pressed = 1;
            Build_Level();

            /*if ()
            {
                ButtonCorrect();
            }
            else 
            {
                ButtonWrong();
            }*/
        }

        private void My_Button2_Clicked(object sender, EventArgs e)
        {
            My_Button_Pressed = 2;
            Build_Level();

            /*if ()
            {
                ButtonCorrect();
            }
            else
            {
                ButtonWrong();
            }*/
        }

        private void My_Button3_Clicked(object sender, EventArgs e)
        {
            My_Button_Pressed = 3;
            Build_Level();

            /*if ()
            {
                ButtonCorrect();
            }
            else
            {
                ButtonWrong();
            }*/
        }

        private async void Build_Level() //Track Pressed Buttons and Load Levels
        {
            if (Loaded_Level == "Categories") //If Player is in the Category
            {
                switch (My_Button_Pressed)
                {
                    case 0: // If Lesson Button is Pressed
                        Loaded_Level = "Lesson";
                        LessonText_Grid.IsVisible = true; //Show Lesson Text
                        break;

                    case 1: // If Transcription Button is Pressed
                        Loaded_Level = "Transcription";
                        Max_PlayerCorrectScore = 60; //Set Level Max Correct Score
                        Max_PlayerWrongScore = 5; //Set Level Max Wrong Score
                        CorrectScore_Req.Text = "/" + Max_PlayerCorrectScore; //Show in UI Max Correct Score
                        WrongScore_Req.Text = "/" + Max_PlayerWrongScore; //Show in UI Max Wrong Score
                        LevelAdress = "Transcription"; //Initialize Loaded Level is Transcription
                        await Task.Delay(250); // 1/4 second waiting before continue
                        Levels_Design(); //Load Level Design & UI
                        Level_Start(); //Start Transription Level
                        break;

                    case 2: // If Symbol Button is Pressed
                        Loaded_Level = "Symbol";
                        Max_PlayerCorrectScore = 99; //Set Level Max Correct Score
                        Max_PlayerWrongScore = 15; //Set Level Max Wrong Score
                        CorrectScore_Req.Text = "/" + Max_PlayerCorrectScore; //Show in UI Max Correct Score
                        WrongScore_Req.Text = "/" + Max_PlayerWrongScore; //Show in UI Max Wrong Score
                        LevelAdress = "Symbol"; //Initialize Loaded Level is Symbol
                        await Task.Delay(250); // 1/4 second waiting before continue
                        
                        //Dropdown for Level

                        Levels_Design(); //Load Level Design & UI
                        Level_Start(); //Start Symbol Level
                        break;

                    case 3: // If Translate Button is Pressed
                        Loaded_Level = "Translate";
                        Max_PlayerCorrectScore = 99; //Set Level Max Correct Score
                        Max_PlayerWrongScore = 15; //Set Level Max Wrong Score
                        CorrectScore_Req.Text = "/" + Max_PlayerCorrectScore; //Show in UI Max Correct Score
                        WrongScore_Req.Text = "/" + Max_PlayerWrongScore; //Show in UI Max Wrong Score
                        LevelAdress = "Translate"; //Initialize Loaded Level is Translate
                        await Task.Delay(250); // 1/4 second waiting before continue

                        //Dropdown for Level

                        Levels_Design(); //Load Level Design & UI
                        Level_Start(); //Start Translate Level
                        break;
                }
            }
        }

        private void Levels_Design() //Create Levels UI
        {
            Title_Label.IsVisible = false; //Hide Category Title

            //Show Level Items
            Instruction_Label.IsVisible = true;
            Title_Label.FontSize = 22;
            GuessWordBGD.IsVisible = true;
            GuessWord_Label.IsVisible = true;

            Scores_Grid.IsVisible = true; //Show Scores Items

            //Hide Lesson Button
            Lesson_Button.IsVisible = false;
            LessonButton_Label.IsVisible = false;
        }

//--------------------------------------------------------------- Levels Logyc -------------------------------------------------------------------------------------------------

        //Transcription Level
        private void Level_Start()
        {
            SetButtonsImg();
            Elements_Quantity = 6;

            for (int CurrentItem = 0; CurrentItem < Elements_Quantity; CurrentItem++)
            {
                //Fill Lists
            }

            Generate_GuessNum(); //Call Function to Generate Guess Word
            
            //Set Player Score - Correct & Wrong
            PlayerScore_Correct = 0;
            PlayerScoreCorrect_Label.Text = PlayerScore_Correct.ToString();
            PlayerScore_Wrong = 0;
            PlayerScoreWrong_Label.Text = PlayerScore_Correct.ToString();
        }

        private void BlockAllButtons()
        {
            //Set Buttons are DISABLED
            My_Button1.IsEnabled = false;
            My_Button2.IsEnabled = false;
            My_Button3.IsEnabled = false;
        }

        private void Generate_GuessNum() //Generate Random Korean Number
        {
            if (Loaded_Level == "Transcription")
            {

            }
            else if(Loaded_Level == "Symbol")
            {

            }
            else if(Loaded_Level == "Translate")
            {

            }
            Generate_ButtonsAnswers(); //Call Function to Apply Correct and Wrong Answers to Buttons
        }

        private void Generate_ButtonsAnswers() //Generate Transcription Buttons Answers
        {
            //Choose witch Button Label to contains the CORRECT Answer
            CorAswIndex = MyRandom.Next(3); //Genrate Random Number [0 - 2] EQUAL to Buttons Labels Quantity

            //Buttons are Free to apply Text
            bool IsButton1_Free = true;
            bool IsButton2_Free = true;
            bool IsButton3_Free = true;

            if (Loaded_Level == "Transcription")
            {
                
            }
            else if (Loaded_Level == "Symbol")
            {

            }
            else if(Loaded_Level == "Translate")
            {

            }

        }

        private void ButtonCorrect()
        {
            switch (My_Button_Pressed)
            {
                case 1:
                    My_Button1.Source = "Button_Correct.png"; //Set new Image on the Button
                    PlayerScore_Correct++; //Update Correct Score
                    PlayerScoreCorrect_Label.Text = PlayerScore_Correct.ToString(); //Update Player Score Label
                    break;

                case 2:
                    My_Button2.Source = "Button_Correct.png"; //Set new Image on the Button
                    PlayerScore_Correct++; //Update Correct Score
                    PlayerScoreCorrect_Label.Text = PlayerScore_Correct.ToString(); //Update Player Score Label
                    break;

                case 3:
                    My_Button3.Source = "Button_Correct.png"; //Set new Image on the Button
                    PlayerScore_Correct++; //Update Correct Score
                    PlayerScoreCorrect_Label.Text = PlayerScore_Correct.ToString(); //Update Player Score Label
                    break;
            }
            //Call Functions
            BlockAllButtons();
            DelayTime();
        }

        private void ButtonWrong()
        {
            switch (My_Button_Pressed)
            {
                case 1:
                    My_Button1.Source ="Button_Wrong.png"; //Set new Image on the Button
                    PlayerScore_Wrong++; //Update Wrong Score
                    PlayerScoreWrong_Label.Text= PlayerScore_Wrong.ToString(); //Update Player Wrong Label
                    My_Button1.IsEnabled = false; //Disable the Button
                    break;

                case 2:
                    My_Button2.Source ="Button_Wrong.png"; //Set new Image on the Button
                    PlayerScore_Wrong++; //Update Wrong Score
                    PlayerScoreWrong_Label.Text= PlayerScore_Wrong.ToString(); //Update Player Wrong Label
                    My_Button2.IsEnabled = false; //Disable the Button
                    break;

                case 3:
                    My_Button3.Source ="Button_Wrong.png"; //Set new Image on the Button
                    PlayerScore_Wrong++; //Update Wrong Score
                    PlayerScoreWrong_Label.Text= PlayerScore_Wrong.ToString(); //Update Player Wrong Label
                    My_Button3.IsEnabled = false; //Disable the Button
                    break;

            }
            ScoreCheck();
        }

        private async void DelayTime()
        {
            await Task.Delay(250); // 1/4 second waiting before continue

            //Call Funtions
            ScoreCheck(); //Track Score
            NewWord(); //Regenerate the entire level
        }

        private void NewWord() //Regenerate the entire level after Player Answer Correct
        {
            UpdateLevel(); //Call Function to Update the Numbers to 10
            Generate_GuessNum(); //Call Function to Generate Guess Word
            Generate_ButtonsAnswers(); //Call Function to Apply Correct and Wrong Answers to Buttons

            SetButtonsImg(); //Call Function to Apply the Default Image to the Buttons 
        }

        private void UpdateLevel() //Increase the Difficulty of the level
        {
            if (Loaded_Level == "Transcription")
            {

            }
            else if (Loaded_Level == "Symbol")
            {

            }
            else if(Loaded_Level == "Translate")
            {

            }
        }

        public async void ScoreCheck() //Track Player Scores
        {
            PageAdress = "Colors";
            if (PlayerScore_Correct == Max_PlayerCorrectScore) //If Player Correct Score = Max Allowed
            {
                App.Current.MainPage = new Level_End_Pages.Passed_Page(); //Go to Congrats Page
            }
            if (PlayerScore_Wrong == Max_PlayerWrongScore) //If Player Wrong Score = Max Allowed
            {
                await Task.Delay(250); // 1/4 second waiting before continue
                App.Current.MainPage = new Level_End_Pages.TryAgain_Page(); //Go to Try Again Page
            }
        }

    }
}