using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Infinite_Korean.Categories_Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Vegetables_Category_Page : ContentPage
    {
        //Initialize Random
        Random MyRandom = new Random();

        //Variables

        //Category Variables
        int My_Button_Pressed = 0; //Track for which Button is pressed 
        string Loaded_Level; //Track what happen with Page - Is it Category, Transcription, Symbol or Translation Page

        //Levels Variables

        //Lists

        // Lists with Korean Symbols Meaning - Translation
        List<string> List_Fruit_Translate_Lvl1 = new List<string>();
        List<string> List_Fruit_Translate_Lvl2 = new List<string>();

        // Lists with Korean Fruit Transcription
        List<string> List_Fruit_Transcription_Lvl1 = new List<string>();
        List<string> List_Fruit_Transcription_Lvl2 = new List<string>();

        // Lists with Korean Fruit Symbol
        List<string> List_Fruit_Symbol_Lvl1 = new List<string>();
        List<string> List_Fruit_Symbol_Lvl2 = new List<string>();

        List<string> List_GuessWords = new List<string>(); //Levels GuessWord List
        List<string> List_Answers = new List<string>(); //Levels Answers List
        List<string> List_WorkList = new List<string>(); //Levels Work List for Random Generation Answers

        int GuessWord_ID; //Guess Word ID
        string GuessWord; //Guess Word
        string Correct_Answer;
        int CorAswButton_ID; //Button with Correct Asnwer ID
        string WrongAnswer1; //Wrong Answer 1
        string WrongAnswer2; //Wrong Answer 2

        //Score Variables for All Levels

        int PlayerScore_Correct; //Player Correct Score
        int PlayerScore_Wrong; //Player Wrong Score
        int Max_PlayerCorrectScore = 0; //Max Correct Score
        int Max_PlayerWrongScore = 0; //Max Wrong Score

        int Level2_Req = 15; //Requarment for Level 2
        int Level3_Req = 50; //Requarment for Level 3

        string Level_Choosed; //Level Choice

        public Vegetables_Category_Page()
        {
            InitializeComponent();
            //On Page Load
            Level_Load(); //Load Level UI
            Read_Vegetables_csv_files(); //Load & Read Fruit .csv files
        }

        private void Level_Load() //Page Load
        {
            //Set Buttons Texts
            LessonButton_Label.Text = "Lesson";
            Button1_Label.Text = "Transcription";
            Button2_Label.Text = "Symbols";
            Button3_Label.Text = "Translation";
            Title_Label.Text = "Vegetables";

            //Hide Levels Items
            GuessWordBGD.IsVisible = false; //Guess Word Background
            GuessWord_Label.IsVisible = false; //Guess Word
            Instruction_Label.IsVisible = false; //Instructions
            Scores_Grid.IsVisible = false; //Score Items 
            Level_Choice_Dropdown.IsVisible = false; //Symbol Level Combo Box

            Loaded_Level = "Categories"; //Set the Page is Category Page

            SetButtonsImg(); //Set Buttons Image

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

            //Set Buttons Text is Enabled
            Button1_Label.IsEnabled = true;
            Button2_Label.IsEnabled = true;
            Button3_Label.IsEnabled = true;
        }

        private void Read_Vegetables_csv_files()
        {
            //Get File Location\ Connect to Current Page
            var tmp = System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(Vegetables_Category_Page)).Assembly;

            //Get/Find .csv files
            Stream Translate_File = tmp.GetManifestResourceStream("Infinite_Korean.csv.Vegetables.Vegetables_Translate.csv");
            Stream Transcription_File = tmp.GetManifestResourceStream("Infinite_Korean.csv.Vegetables.Vegetables_Transcription.csv");
            Stream Symbol_File = tmp.GetManifestResourceStream("Infinite_Korean.csv.Vegetables.Vegetables_Symbols.csv");

            //Read .csv files
            StreamReader Translate_File_Reader = new StreamReader(Translate_File);
            StreamReader Transcription_File_Reader = new StreamReader(Transcription_File);
            StreamReader Symbol_File_Reader = new StreamReader(Symbol_File);

            int Current_Element = 0; //Track Elements Quantity in each List

            //Fill Translate List with Translate Words from .csv file
            while (Translate_File_Reader.ReadLine() is string word)
            {
                if (Current_Element < 7)
                {
                    List_Fruit_Translate_Lvl1.Add(word);
                }
                else
                {
                    List_Fruit_Translate_Lvl2.Add(word);
                }
                Current_Element++;
            }

            Current_Element = 0; //Clear Quantity | Start again counting

            //Fill Transcription List with Translate Words from .csv file
            while (Transcription_File_Reader.ReadLine() is string word)
            {
                if (Current_Element < 7)
                {
                    List_Fruit_Transcription_Lvl1.Add(word);
                }
                else
                {
                    List_Fruit_Transcription_Lvl2.Add(word);
                }
                Current_Element++;
            }

            Current_Element = 0; //Clear Quantity | Start again counting

            //Fill Symbol List with Translate Words from .csv file
            while (Symbol_File_Reader.ReadLine() is string word)
            {
                if (Current_Element < 7)
                {
                    List_Fruit_Symbol_Lvl1.Add(word);
                }
                else
                {
                    List_Fruit_Symbol_Lvl2.Add(word);
                }
                Current_Element++;
            }
        }

        private void BackButton_Clicked(object sender, EventArgs e)
        {
            BackFunc(); //Call Back Function
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
            Title_Label.Text = "Vegetables";
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

            List_GuessWords.Clear();
            List_Answers.Clear();
            List_WorkList.Clear();

            Scores_Grid.IsVisible = false; //Hide Scores Items

            Level_Choice_Dropdown.IsVisible = false; //Hide Level Choice Combo Box
            Level_Choice_Dropdown.SelectedItem = null; //Reset Level Choice Combo Box
            Levels_Choice_Btn.IsVisible = false; //Hide Level Choice Combo Box Button
            Level_Choice_BtnText.IsVisible = false; //Hide Level Choice Combo Box Button Text

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

            //Reset Levels Picker
            Level_Choice_Dropdown.SelectedIndex = -1;
            Level_Choosed = null;

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

        private void Lesson_Button_Clicked(object sender, EventArgs e) //On Lesson Button Clicked
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

            Build_Level(); //Build Lesson Page
        }

        private void My_Button1_Clicked(object sender, EventArgs e) //On Button1 Clicked
        {
            My_Button_Pressed = 1;

            if (Loaded_Level == "Categories")
            {
                My_Button1.Source = "Button_Correct.png"; //Set new Image on the Button
                Build_Level();
            }
            else if (Loaded_Level != "Categories")
            {
                if (Button1_Label.Text == Correct_Answer)
                {
                    ButtonCorrect();
                }
                else
                {
                    ButtonWrong();
                }
            }
        }

        private void My_Button2_Clicked(object sender, EventArgs e) //On Button1 Clicked
        {
            My_Button_Pressed = 2;

            if (Loaded_Level == "Categories")
            {
                My_Button2.Source = "Button_Correct.png"; //Set new Image on the Button
                Build_Level();
            }
            else if (Loaded_Level != "Categories")
            {
                if (Button2_Label.Text == Correct_Answer)
                {
                    ButtonCorrect();
                }
                else
                {
                    ButtonWrong();
                }

            }
        }

        private void My_Button3_Clicked(object sender, EventArgs e) //On Button3 Clicked
        {
            My_Button_Pressed = 3;

            if (Loaded_Level == "Categories")
            {
                My_Button3.Source = "Button_Correct.png"; //Set new Image on the Button
                Build_Level();
            }
            else if (Loaded_Level != "Categories")
            {
                if (Button3_Label.Text == Correct_Answer)
                {
                    ButtonCorrect();
                }
                else
                {
                    ButtonWrong();
                }
            }
        }

        private async void Build_Level() //Track Pressed Buttons and Load Levels
        {
            if (Loaded_Level == "Categories") //If Player is in the Category
            {
                switch (My_Button_Pressed)
                {
                    case 0: // If Lesson Button is Pressed
                        Loaded_Level = "Lesson"; //Set Loaded is Lesson
                        LessonText_Grid.IsVisible = true; //Show Lesson Text
                        break;

                    case 1: // If Transcription Button is Pressed

                        Loaded_Level = "Transcription"; //Set Loaded is Transcription
                        Level_End_Pages.Passed_Page.LevelAdress = "Transcription"; //Initialize Loaded Level is Transcription

                        Max_PlayerCorrectScore = 60; //Set Level Max Correct Score
                        Max_PlayerWrongScore = 5; //Set Level Max Wrong Score
                        CorrectScore_Req.Text = "/" + Max_PlayerCorrectScore; //Show in UI Max Correct Score
                        WrongScore_Req.Text = "/" + Max_PlayerWrongScore; //Show in UI Max Wrong Score
                        WrongScore_Req.Margin = new Thickness(0, 0, 30, 40); //Update Wrong Score Requarment Margin
                        PlayerScoreWrong_Label.Margin = new Thickness(0, 0, 60, 40); //Update Player Wrong Score Margin

                        List_GuessWords.AddRange(List_Fruit_Transcription_Lvl1);
                        List_Answers.AddRange(List_Fruit_Translate_Lvl1);

                        await Task.Delay(250); // 1/4 second waiting before continue
                        Levels_Design(); //Load Level Design & UI
                        Level_Start(); //Start Transription Level
                        break;

                    case 2: // If Symbol Button is Pressed

                        Loaded_Level = "Symbol"; //Set Loaded is Symbol
                        Level_End_Pages.Passed_Page.LevelAdress = "Symbol"; //Initialize Loaded Level is Symbol

                        Max_PlayerCorrectScore = 99; //Set Level Max Correct Score
                        Max_PlayerWrongScore = 15; //Set Level Max Wrong Score
                        CorrectScore_Req.Text = "/" + Max_PlayerCorrectScore; //Show in UI Max Correct Score
                        WrongScore_Req.Text = "/" + Max_PlayerWrongScore; //Show in UI Max Wrong Score
                        WrongScore_Req.Margin = new Thickness(0, 0, 26, 40); //Update Wrong Score Requarment Margin
                        PlayerScoreWrong_Label.Margin = new Thickness(0, 0, 70, 40); //Update Player Wrong Score Margin

                        List_GuessWords.AddRange(List_Fruit_Symbol_Lvl1);
                        List_Answers.AddRange(List_Fruit_Translate_Lvl1);

                        await Task.Delay(250); // 1/4 second waiting before continue

                        Level_Choice_Dropdown.IsVisible = true; //Show Level Choice Combo Box
                        Levels_Choice_Btn.IsVisible = true; //Show Level Choice Button
                        Level_Choice_BtnText.IsVisible = true; //Show Level Choice Button Text

                        Levels_Design(); //Load Level Design & UI
                        Level_Start(); //Start Symbol Level
                        break;

                    case 3: // If Translate Button is Pressed

                        Loaded_Level = "Translate";
                        Level_End_Pages.Passed_Page.LevelAdress = "Translate"; //Initialize Loaded Level is Translate

                        Max_PlayerCorrectScore = 99; //Set Level Max Correct Score
                        Max_PlayerWrongScore = 15; //Set Level Max Wrong Score
                        CorrectScore_Req.Text = "/" + Max_PlayerCorrectScore; //Show in UI Max Correct Score
                        WrongScore_Req.Text = "/" + Max_PlayerWrongScore; //Show in UI Max Wrong Score
                        WrongScore_Req.Margin = new Thickness(0, 0, 26, 40); //Update Wrong Score Requarment Margin
                        PlayerScoreWrong_Label.Margin = new Thickness(0, 0, 70, 40); //Update Player Wrong Score Margin

                        List_GuessWords.AddRange(List_Fruit_Translate_Lvl1);
                        List_Answers.AddRange(List_Fruit_Symbol_Lvl1);

                        await Task.Delay(250); // 1/4 second waiting before continue

                        Level_Choice_Dropdown.IsVisible = true; //Show Level Choice Combo Box
                        Levels_Choice_Btn.IsVisible = true;//Show Level Choice Button
                        Level_Choice_BtnText.IsVisible = true; //Show Level Choice Button Text

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

        private void Level_Start() //Level Start
        {
            Scores_Grid.IsVisible = true; //Show Scores Items

            SetButtonsImg(); //Call Function to Set to All Buttons Image

            //Set Player Score - Correct & Wrong
            PlayerScore_Correct = 0;
            PlayerScoreCorrect_Label.Text = PlayerScore_Correct.ToString();
            PlayerScore_Wrong = 0;
            PlayerScoreWrong_Label.Text = PlayerScore_Correct.ToString();

            List_WorkList.AddRange(List_Answers); //Fill Work List with Answers for Buttons

            Generate_GuessNum(); //Call Function to Generate Guess Word

        }

        private void BlockAllButtons() //Lock Button Func
        {
            //Set Buttons are DISABLED
            My_Button1.IsEnabled = false;
            My_Button2.IsEnabled = false;
            My_Button3.IsEnabled = false;
        }

        private void Generate_GuessNum() //Generate Random Korean Number
        {
            GuessWord_ID = MyRandom.Next(0, List_GuessWords.Count); //Generate Random Guess Word ID
            GuessWord = List_GuessWords[GuessWord_ID]; //Initialize Guess Word
            GuessWord_Label.Text = GuessWord; //Print it to Guess Word Space

            Generate_ButtonsAnswers(); //Call Function to Apply Correct and Wrong Answers to Buttons

        }

        private void Generate_ButtonsAnswers() //Generate Transcription Buttons Answers
        {
            Correct_Answer = List_Answers[GuessWord_ID]; //Initialize the Correct Answer
            List_WorkList.Remove(Correct_Answer); //Remove Correct Answer from Work List to PREVENT DUPLICATE ANSWERS

            //Choose which Button Label to contains the CORRECT Answer
            CorAswButton_ID = MyRandom.Next(3); //Genrate Random Number [0 - 2] EQUAL to Buttons Labels Quantity

            Random WrongAnswers_Random = new Random();
            int WrongAnswer1_ID = WrongAnswers_Random.Next(0, List_WorkList.Count); //Generate Random WrongAnswer1 ID from Work List
            WrongAnswer1 = List_WorkList[WrongAnswer1_ID]; //Initialize Random WrongAnswer1 in Work List
            List_WorkList.Remove(WrongAnswer1); //Remove WrongAnswer1 from Work List

            int WrongAnswer2_ID = WrongAnswers_Random.Next(0, List_WorkList.Count); //Generate Random WrongAnswer2 ID from Work List
            WrongAnswer2 = List_WorkList[WrongAnswer2_ID]; //Initialize Random WrongAnswer2 in Work List

            switch (CorAswButton_ID) //Distribute Buyttons Answers
            {
                case 0:
                    Button1_Label.Text = Correct_Answer; //Button1 Contains the Correct Answer

                    //Set Other Buttons Wrong Answers
                    Button2_Label.Text = WrongAnswer1;
                    Button3_Label.Text = WrongAnswer2;
                    break;

                case 1:
                    Button2_Label.Text = Correct_Answer; //Button2 Contains the Correct Answer

                    //Set Other Buttons Wrong Answers
                    Button1_Label.Text = WrongAnswer1;
                    Button3_Label.Text = WrongAnswer2;
                    break;

                case 2:
                    Button3_Label.Text = Correct_Answer; //Button3 Contains the Correct Answer

                    //Set Other Buttons Wrong Answers
                    Button1_Label.Text = WrongAnswer1;
                    Button2_Label.Text = WrongAnswer2;
                    break;
            }

            List_WorkList.Clear(); //Clear Work List
            List_WorkList.AddRange(List_Answers); //Fill Again Work List

        }

        private void ButtonCorrect() //Correct Button Answer
        {
            switch (My_Button_Pressed)
            {
                case 1:
                    My_Button1.Source = "Button_Correct.png"; //Set new Image on the Button
                    break;

                case 2:
                    My_Button2.Source = "Button_Correct.png"; //Set new Image on the Button
                    break;

                case 3:
                    My_Button3.Source = "Button_Correct.png"; //Set new Image on the Button
                    break;
            }

            PlayerScore_Correct++; //Update Correct Score
            PlayerScoreCorrect_Label.Text = PlayerScore_Correct.ToString(); //Update Player Score Label

            //Call Functions
            BlockAllButtons();
            DelayTime();
        }

        private void ButtonWrong() //Wrong Button Answer
        {
            switch (My_Button_Pressed)
            {
                case 1:
                    My_Button1.Source ="Button_Wrong.png"; //Set new Image on the Button
                    My_Button1.IsEnabled = false; //Disable the Button
                    Button1_Label.IsEnabled = false; //Disable Button Text
                    break;

                case 2:
                    My_Button2.Source ="Button_Wrong.png"; //Set new Image on the Button
                    My_Button2.IsEnabled = false; //Disable the Button
                    Button2_Label.IsEnabled = false; //Disable Button Text
                    break;

                case 3:
                    My_Button3.Source ="Button_Wrong.png"; //Set new Image on the Button
                    My_Button3.IsEnabled = false; //Disable the Button
                    Button3_Label.IsEnabled = false; //Disable Button Text
                    break;

            }

            PlayerScore_Wrong++; //Update Wrong Score
            PlayerScoreWrong_Label.Text= PlayerScore_Wrong.ToString(); //Update Player Wrong Label

            ScoreCheck(); //Call Function to Check Score
        }

        private async void DelayTime() //Next Round 
        {
            await Task.Delay(250); // 1/4 second waiting before continue

            //Call Funtions
            ScoreCheck(); //Track Score
            NewWord(); //Regenerate the entire level
        }

        private void NewWord() //Regenerate the entire level after Player Answer Correct
        {
            UpdateLevel(); //Call Function to Update the Level
            Generate_GuessNum(); //Call Function to Generate Guess Word
            Generate_ButtonsAnswers(); //Call Function to Apply Correct and Wrong Answers to Buttons

            SetButtonsImg(); //Call Function to Apply the Default Image to the Buttons 
        }

        private void UpdateLevel() //Increase the Difficulty of the level
        {
            switch (Loaded_Level)
            {
                case "Transcription":
                    if (PlayerScore_Correct == Level2_Req || Level_Choosed == "Lvl2")
                    {
                        List_GuessWords.AddRange(List_Fruit_Transcription_Lvl2); //Add Lvl2 Transcription Lvl2 Lists to Guess Word List            
                        List_Answers.AddRange(List_Fruit_Translate_Lvl2); //Add Lvl2 Translate Lists to Answers List
                    }
                    break;

                case "Symbol":
                    if (Level_Choosed == "Lvl1") //If Choosen Level is Lvl1
                    {
                        //Clear Level Lists
                        List_GuessWords.Clear();
                        List_Answers.Clear();

                        //Add Lvl1 Lists to Level List
                        List_GuessWords.AddRange(List_Fruit_Symbol_Lvl1);
                        List_Answers.AddRange(List_Fruit_Translate_Lvl1);
                    }
                    if (PlayerScore_Correct == Level2_Req || Level_Choosed == "Lvl2") //If Player Score reach Lvl2 Requarment or Choosen Level is Lvl2
                    {
                        //Clear Level Lists
                        List_GuessWords.Clear();
                        List_Answers.Clear();

                        //Add Symbols Lists to Guess Words List
                        List_GuessWords.AddRange(List_Fruit_Symbol_Lvl1);
                        List_GuessWords.AddRange(List_Fruit_Symbol_Lvl2);

                        //Add Translate Lists to Answers List
                        List_Answers.AddRange(List_Fruit_Translate_Lvl1);
                        List_Answers.AddRange(List_Fruit_Translate_Lvl2);

                    }
                    else if (PlayerScore_Correct == Level3_Req || Level_Choosed == "Lvl3") //If Player Score reach Lvl3 Requarment or Choosen Level is Lvl3
                    {
                        //Clear Level Lists
                        List_GuessWords.Clear();
                        List_Answers.Clear();

                        //Add Symbol Lists to Guess Words List
                        List_GuessWords.AddRange(List_Fruit_Symbol_Lvl1);
                        List_GuessWords.AddRange(List_Fruit_Symbol_Lvl2);

                        //Add Transcription Lists to Answers List
                        List_Answers.AddRange(List_Fruit_Transcription_Lvl1);
                        List_Answers.AddRange(List_Fruit_Transcription_Lvl2);
                    }
                    break;

                case "Translate":
                    if (Level_Choosed == "Lvl1") //If Choosen Level is Lvl1
                    {
                        //Clear Level Lists
                        List_GuessWords.Clear();
                        List_Answers.Clear();

                        //Add Lvl1 Lists to Level Lists
                        List_GuessWords.AddRange(List_Fruit_Translate_Lvl1);
                        List_Answers.AddRange(List_Fruit_Symbol_Lvl1);
                    }
                    if (PlayerScore_Correct == Level2_Req || Level_Choosed == "Lvl2") //If Player Score reach Lvl2 Requarment or Choosen Level is Lvl2
                    {
                        //Clear Level Lists
                        List_GuessWords.Clear();
                        List_Answers.Clear();

                        //Add Lvl1 Lists to the Lists
                        List_GuessWords.AddRange(List_Fruit_Translate_Lvl1);
                        List_Answers.AddRange(List_Fruit_Symbol_Lvl1);

                        //Add Lvl2 Lists to the Lists
                        List_GuessWords.AddRange(List_Fruit_Translate_Lvl2);
                        List_Answers.AddRange(List_Fruit_Symbol_Lvl2);

                    }
                    else if (PlayerScore_Correct == Level3_Req || Level_Choosed == "Lvl3") //If Player Score reach Lvl3 Requarment or Choosen Level is Lvl3
                    {
                        //Clear Level Lists
                        List_GuessWords.Clear();
                        List_Answers.Clear();

                        //Add Transcription Lists to Guess Word List 
                        List_GuessWords.AddRange(List_Fruit_Transcription_Lvl1);
                        List_GuessWords.AddRange(List_Fruit_Transcription_Lvl2);

                        //Add Symbol Lists to Answers List 
                        List_Answers.AddRange(List_Fruit_Symbol_Lvl1);
                        List_Answers.AddRange(List_Fruit_Symbol_Lvl2);
                    }
                    break;
            }
        }

        public async void ScoreCheck() //Track Player Scores
        {
            Level_End_Pages.Passed_Page.PageAdress = "Vegetables";

            if (PlayerScore_Correct == Max_PlayerCorrectScore) //If Player Correct Score = Max Allowed
            {
                if (PlayerScore_Wrong == 0) //If Player do not make Mistakes
                {
                    Level_End_Pages.Passed_Page.Stars = 3; // Player receive 3 Stars
                }
                else if (PlayerScore_Wrong > 0 && PlayerScore_Wrong <= Max_PlayerWrongScore / 2) //If Player do MAX 2 Mistakes 
                {
                    Level_End_Pages.Passed_Page.Stars = 2; // Player receive 2 Stars
                }
                else if (PlayerScore_Wrong > Max_PlayerWrongScore / 2 && PlayerScore_Wrong <= Max_PlayerWrongScore - 1) //If Player do more than 2 Mistakes 
                {
                    Level_End_Pages.Passed_Page.Stars = 1; // Player receive 1 Star
                }

                App.Current.MainPage = new Level_End_Pages.Passed_Page(); //Go to Congrats Page

            }

            if (PlayerScore_Wrong == Max_PlayerWrongScore) //If Player Wrong Score = Max Allowed
            {
                await Task.Delay(250); // 1/4 second waiting before continue
                App.Current.MainPage = new Level_End_Pages.TryAgain_Page(); //Go to Try Again Page
            }

        }

        private void Levels_Choice_Btn_Clicked(object sender, EventArgs e) //Levels Picker
        {
            if (Level_Choice_Dropdown.SelectedItem != null)
            {
                string LevelChoice = Level_Choice_Dropdown.SelectedItem.ToString();

                switch (LevelChoice)
                {
                    case "Vegetables Translation - Lvl1":
                        Level_Choosed = "Lvl1";
                        break;
                    case "Vegetables Translation - Lvl2":
                        Level_Choosed = "Lvl2";
                        break;
                    case "Vegetables Transcription - Lvl3":
                        Level_Choosed = "Lvl3";
                        break;
                }

                DisplayAlert("Chosen Level: ", LevelChoice, "Ok");

                PlayerScore_Correct = 0;
                PlayerScoreCorrect_Label.Text = PlayerScore_Correct.ToString(); //Update Player Score Label
                PlayerScore_Wrong = 0;
                PlayerScoreWrong_Label.Text = PlayerScore_Wrong.ToString(); //Show Player Score Label

                //Call Functions
                SetButtonsImg();
                UpdateLevel();
                Generate_GuessNum();
                Generate_ButtonsAnswers();
            }
        }
    }
}