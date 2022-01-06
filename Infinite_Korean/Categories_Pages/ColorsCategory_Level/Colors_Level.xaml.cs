﻿using System;
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
        string[] Numbers_Transcription_Arr = { "yeong", "hana", "dul", "set", "net", "daseot" }; //Array with Korean Numbers Transcription
        string[] Numbers_Transcription_Lvl2_Arr = { "yeoseot", "ilgop", "yeodeol", "ahop", "yeol" }; //Array with Korean Numbers Transcription Lvl 2
        //Symbols
        string[] Numbers_Symbol_Arr = { "영", "하나", "둘", "셋", "넷", "다섯" }; //Array with Korean Numbers Symbols - Guess Words
        string[] Numbers_Symbol_Lvl2_Arr = { "여섯", "일곱", "여덟", "아홉", "열" }; //Array with Korean Numbers Symbols Lvl 2 - Guess Words
        //Translate
        string[] Numbers_Translate_Arr = {"0","1","2","3","4","5"}; //Array with Korean Symbols Meaning - Answers
        string[] Numbers_Translate_Lvl2_Arr = {"6", "7", "8", "9", "10"}; //Array with Korean Symbol Meaning - Answers - Lvl 2

        //Lists
        List<string> Numbers_Transcription_List = new List<string>(); //Transcription List
        List<string> Numbers_Symbol_List = new List<string>(); //Symbol List 
        List<string> Numbers_Translate_List = new List<string>(); //???

        //Mutual for All Levels Variables 
        int Elements_Quantity = 6; //Quantity of Numbers in the list [0 - 5]
        int GuessWord; //GuessWord Number
        int GenIndex;
        int PlayerScore_Correct; //Player Correct Score
        int PlayerScore_Wrong; //Player Wrong Score
        int Level2_Req = 10;
        int CorAswIndex; //Number with Correct Answer

        string MyCorrect_Answer;

        //Score Requarments for Transcription Level
        int Max_PlayerCorrectScore_TranscrLvl = 60;
        int Max_PlayerWrongScore_TranscrLvl = 5;

        //Symbols Level Score Requarments
        int Max_PlayerCorrect_Score = 99;
        int Max_PlayerWrong_Score = 15;
        int Level3_Req = 50;


        public static string PageAdress; //Initialize to which Page to Append End Level Pages ( Passed Page and Try Again Page )

        public Colors_Level()
        {
            InitializeComponent();

            //On Page Load
            Level_Load();
        }

        private void Level_Load() //Page Load
        {
            //Set Buttons Texts
            Button1_Label.Text = "Transcription";
            Button2_Label.Text = "Symbols";
            Button3_Label.Text = "Translation";
            Title_Label.Text = "Colors";

            //Hide Levels Items
            GuessWordBGD.IsVisible = false;
            GuessWord_Label.IsVisible = false;
            Instruction_Label.IsVisible = false;
            //Correct Score
            CounterCorrect_Img.IsVisible = false;
            CorrectScore_Req.IsVisible = false;
            PlayerScoreCorrect_Label.IsVisible = false;
            //Wrong Score
            CounterWrong_Img.IsVisible = false;
            WrongScore_Req.IsVisible = false;
            PlayerScoreWrong_Label.IsVisible = false;

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
                //Hide Score Items
            CounterCorrect_Img.IsVisible = false;
            CorrectScore_Req.IsVisible = false;
            PlayerScoreCorrect_Label.IsVisible = false;
            CounterWrong_Img.IsVisible = false;
            WrongScore_Req.IsVisible = false;
            PlayerScoreWrong_Label.IsVisible = false;

            //Set Buttons Text
            LessonButton_Label.Text = "Lesson";
            Button1_Label.Text = "Transcription";
            Button2_Label.Text = "Symbols";
            Button3_Label.Text = "Translation";

            //Show Lesson Button
            Lesson_Button.IsVisible = true;
            LessonButton_Label.IsVisible = true;

            SetButtonsImg();

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

            if (Button1_Label.Text ==  GenIndex.ToString())
            {
                My_Button1.Source = "Button_Correct.png"; //Set new Image on the Button
                PlayerScore_Correct++; //Update Correct Score
                PlayerScoreCorrect_Label.Text = PlayerScore_Correct.ToString(); //Update Player Score Label

                //Call Functions
                BlockAllButtons();
                DelayTime();

            }
            else if (Button1_Label.Text !=  GenIndex.ToString())
            {
                My_Button1.Source ="Button_Wrong.png"; //Set new Image on the Button
                PlayerScore_Wrong++; //Update Wrong Score
                PlayerScoreWrong_Label.Text= PlayerScore_Wrong.ToString(); //Update Player Wrong Label
                My_Button1.IsEnabled = false; //Disable the Button

                ScoreCheck();
            }      
        }

        private void My_Button2_Clicked(object sender, EventArgs e)
        {
            My_Button_Pressed = 2;
            Build_Level();

            if (Button2_Label.Text ==  GenIndex.ToString())
            {
                My_Button2.Source = "Button_Correct.png"; //Set new Image on the Button
                PlayerScore_Correct++; //Update Correct Score
                PlayerScoreCorrect_Label.Text = PlayerScore_Correct.ToString(); //Update Player Score Label

                //Call Functions
                BlockAllButtons();
                DelayTime();

            }
            else if(Button2_Label.Text != GenIndex.ToString())
            {
                My_Button2.Source ="Button_Wrong.png"; //Set new Image on the Button
                PlayerScore_Wrong++; //Update Wrong Score
                PlayerScoreWrong_Label.Text= PlayerScore_Wrong.ToString(); //Update Player Wrong Label
                My_Button2.IsEnabled = false; //Disable the Button

                ScoreCheck();
            }
        }

        private void My_Button3_Clicked(object sender, EventArgs e)
        {
            My_Button_Pressed = 3;
            Build_Level();

            if (Button3_Label.Text == GenIndex.ToString())
            {
                My_Button3.Source = "Button_Correct.png"; //Set new Image on the Button
                PlayerScore_Correct++; //Update Correct Score
                PlayerScoreCorrect_Label.Text = PlayerScore_Correct.ToString(); //Update Player Score Label

                //Call Functions
                BlockAllButtons();
                DelayTime();

            }
            else if(Button3_Label.Text != GenIndex.ToString())
            {
                My_Button3.Source ="Button_Wrong.png"; //Set new Image on the Button
                PlayerScore_Wrong++; //Update Wrong Score
                PlayerScoreWrong_Label.Text= PlayerScore_Wrong.ToString(); //Update Player Wrong Label
                My_Button3.IsEnabled = false; //Disable the Button

                ScoreCheck();
            }
        }

        private async void Build_Level() //Track Pressed Buttons and Load Levels
        {
            if (Loaded_Level == "Categories") //If Player is in the Category
            {
                switch (My_Button_Pressed)
                {
                    case 0: // If Lesson Button is Pressed
                        Loaded_Level = "Lesson";
                        break;
                    case 1: // If Transcription Button is Pressed
                        Loaded_Level = "Transcription";
                        await Task.Delay(250); // 1/4 second waiting before continue
                        Levels_Design(); //Load Level Design & UI
                        Level_Start(); //Start Transription Level
                        break;
                    case 2: // If Symbol Button is Pressed
                        Loaded_Level = "Symbol";
                        Levels_Design(); //Load Level Design & UI
                        break;
                    case 3: // If Translate Button is Pressed
                        Loaded_Level = "Translate";
                        Levels_Design(); //Load Level Design & UI
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

            //Correct Score
            CounterCorrect_Img.IsVisible = true;
            CorrectScore_Req.IsVisible = true;
            PlayerScoreCorrect_Label.IsVisible = true;
            //Wrong Score
            CounterWrong_Img.IsVisible = true;
            WrongScore_Req.IsVisible = true;
            PlayerScoreWrong_Label.IsVisible = true;

            //Hide Lesson Button
            Lesson_Button.IsVisible = false;
            LessonButton_Label.IsVisible = false;
        }

//--------------------------------------------------------------- Levels Logyc -------------------------------------------------------------------------------------------------

        //Transcription Level
        private void Level_Start()
        {
            SetButtonsImg();

            for (int CurrentItem = 0; CurrentItem < Elements_Quantity; CurrentItem++)
            {
                Numbers_Transcription_List.Add(Numbers_Transcription_Arr[CurrentItem]); //Fill Numbers List
                Numbers_Symbol_List.Add(Numbers_Symbol_Arr[CurrentItem]); //Fill Number Symbol List - Guess Word List
                Numbers_Translate_List.Add(Numbers_Translate_Arr[CurrentItem]); //Fill Number Translate List - Answers List
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
            GenIndex = MyRandom.Next(Elements_Quantity); //Generate Random Number EQUAL to Index of Numbers_Transcription_List
            GuessWord_Label.Text = Numbers_Transcription_List[GenIndex]; //Show the Random Array Element on GuessWord Label
            Generate_TranscriptionButtonsAnswers(); //Call Function to Apply Correct and Wrong Answers to Buttons
        }

        private void Generate_TranscriptionButtonsAnswers() //Generate Transcription Buttons Answers
        {
            //Choose witch Button Label to contains the CORRECT Answer
            CorAswIndex = MyRandom.Next(3); //Genrate Random Number [0 - 2] EQUAL to Buttons Labels Quantity

            //Buttons are Free to apply Text
            bool IsButton1_Free = true;
            bool IsButton2_Free = true;
            bool IsButton3_Free = true;

            int WrongButton_Ans1; //First Button with Wrong Answer
            int WrongButton_Ans2; //Second Button with Wrong Answer

            switch (CorAswIndex)
            {
                case 0: //If Random Number is 0
                    Button1_Label.Text = GenIndex.ToString(); //Apply Correct Answer to Button1 Label 

                    //Update whitch Buttons are available 
                    IsButton1_Free = false;
                    break;
                case 1: //If Random Number is 1
                    Button2_Label.Text = GenIndex.ToString(); //Apply Correct Answer to Button2 Label 

                    //Update whitch Buttons are available 
                    IsButton2_Free = false;
                    break;
                case 2: //If Random Number is 2
                    Button3_Label.Text = GenIndex.ToString(); //Apply Correct Answer to Button3 Label 

                    //Update whitch Buttons are available 
                    IsButton3_Free = false;
                    break;
            }

            WrongButton_Ans1 = MyRandom.Next(Numbers_Transcription_List.Count - GenIndex); //Generate Wrong Answer 1
            WrongButton_Ans2 = MyRandom.Next(Numbers_Transcription_List.Count - GenIndex); //Generate Wrong Answer 2

            if (WrongButton_Ans1 == GenIndex) //If Wrong Answer1 = Correct Answer
            {
                WrongButton_Ans1 = MyRandom.Next(0, Numbers_Transcription_List.Count - GenIndex); //Generate Wrong Answer 1
            }
            if (WrongButton_Ans2 == WrongButton_Ans1) //If Wrong Answer1 = Wrong Answer2
            {
                WrongButton_Ans2 = MyRandom.Next(0, Numbers_Transcription_List.Count - WrongButton_Ans1); //Generate new Wrong Answer2
            }
            if (WrongButton_Ans2 == GenIndex) //If Wrong Answer2 = Correct Answer
            {
                WrongButton_Ans2 = MyRandom.Next(0, Numbers_Transcription_List.Count - GenIndex); //Generate new Wrong Answer2
            }

            //Check witch Buttons are FREE to Apply Number
            if (IsButton1_Free == true && IsButton2_Free == true)
            {
                Button1_Label.Text = WrongButton_Ans1.ToString(); //Apply Wrong Answer to Button1 Label 
                Button2_Label.Text = WrongButton_Ans2.ToString(); //Apply Wrong Answer to Button2 Label   
            }
            if (IsButton1_Free == true && IsButton3_Free == true)
            {
                Button1_Label.Text = WrongButton_Ans1.ToString(); //Apply Wrong Answer to Button1 Label 
                Button3_Label.Text = WrongButton_Ans2.ToString(); //Apply Wrong Answer to Button3 Label   
            }
            if (IsButton2_Free == true && IsButton3_Free == true)
            {
                Button2_Label.Text = WrongButton_Ans1.ToString(); //Apply Wrong Answer to Button2 Label   
                Button3_Label.Text = WrongButton_Ans2.ToString(); //Apply Wrong Answer to Button3 Label   
            }

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
            Generate_TranscriptionButtonsAnswers(); //Call Function to Apply Correct and Wrong Answers to Buttons

            SetButtonsImg(); //Call Function to Apply the Default Image to the Buttons 
        }

        private void UpdateLevel() //Increase the Difficulty of the level
        {
            if (PlayerScore_Correct == Level2_Req) //If Player Score equal to 10
            {
                Numbers_Transcription_List.AddRange(Numbers_Transcription_Lvl2_Arr); //Add to Numbers list Numers to 10 
                Elements_Quantity = 11; //Сet a new Quantity of Numbers in the level
            }
        }

        public async void ScoreCheck() //Track Player Scores
        {
            PageAdress = "Colors";
            if (PlayerScore_Correct == Max_PlayerCorrectScore_TranscrLvl) //If Player Correct Score = Max Allowed
            {
                App.Current.MainPage = new Level_End_Pages.Passed_Page(); //Go to Congrats Page
            }
            if (PlayerScore_Wrong == Max_PlayerWrongScore_TranscrLvl) //If Player Wrong Score = Max Allowed
            {
                await Task.Delay(250); // 1/4 second waiting before continue
                App.Current.MainPage = new Level_End_Pages.TryAgain_Page(); //Go to Try Again Page
            }
        }

    }
}