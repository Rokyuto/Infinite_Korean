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
        string[] Numbers_Translate_Arr = { "0", "1", "2", "3", "4", "5" }; //Array with Korean Symbols Meaning - Answers
        string[] Numbers_Translate_Lvl2_Arr = { "6", "7", "8", "9", "10" }; //Array with Korean Symbol Meaning - Answers - Lvl 2

        //Lists
        List<string> Numbers_Transcription_List = new List<string>(); //Transcription List
        List<string> Numbers_Symbol_List = new List<string>(); //Symbol List 
        List<string> Numbers_Translate_List = new List<string>(); //Translate List

        //Mutual for All Levels Variables 
        int Elements_Quantity = 6; //Quantity of Numbers in the list [0 - 5]
        int GenIndex; //Generate Guess Word
        int CorAswIndex; //Button with Correct Answer
        string SymbolCorrect_Ans; //Symbol Level Correct Answer
        string TranslateCorrect_Ans; //Translate Level Correct Answer

        int PlayerScore_Correct; //Player Correct Score
        int PlayerScore_Wrong; //Player Wrong Score
        int Level2_Req = 10; //Requarment for Level 2

        //Score Requarments for the Levels
        int Max_PlayerCorrectScore = 0;
        int Max_PlayerWrongScore = 0;

        //Score Requarments for Symbol Level
        int Level3_Req = 50;//Requarment for Level 3 in Symbol Level
        string Level_Choosed;

        public static string PageAdress; //Initialize to which Page to Append End Level Pages ( Passed Page and Try Again Page )
        public static string LevelAdress; //Initialize to which Level to Append End Level Pages ( Passed Page and Try Again Page )

        public Numbers_Category_Page()
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
            Title_Label.Text = "Numbers";

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
            Title_Label.Text = "Numbers";
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
            Level_Choice_Dropdown.IsVisible = false; //Hide Level Choice Combo Box
            Level_Choice_Dropdown.SelectedItem = null; //Reset Level Choice Combo Box
            Symbol_Level_Choice_Btn.IsVisible = false; //Hide Level Choice Combo Box Button
            Level_Choice_BtnText.IsVisible = false; //Hide Level Choice Combo Box Button Text
            Symbol_Level_Choice_Btn.IsVisible = false;
            Level_Choice_BtnText.IsVisible = false;

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

            if (Button1_Label.Text ==  GenIndex.ToString() || Button1_Label.Text == SymbolCorrect_Ans || Button1_Label.Text == TranslateCorrect_Ans)
            {
                ButtonCorrect();
            }
            else
            {
                ButtonWrong();
            }
        }

        private void My_Button2_Clicked(object sender, EventArgs e)
        {
            My_Button_Pressed = 2;
            Build_Level();

            if (Button2_Label.Text ==  GenIndex.ToString() || Button2_Label.Text ==  SymbolCorrect_Ans || Button2_Label.Text == TranslateCorrect_Ans)
            {
                ButtonCorrect();
            }
            else
            {
                ButtonWrong();
            }
        }

        private void My_Button3_Clicked(object sender, EventArgs e)
        {
            My_Button_Pressed = 3;
            Build_Level();

            if (Button3_Label.Text == GenIndex.ToString() || Button3_Label.Text == SymbolCorrect_Ans || Button3_Label.Text == TranslateCorrect_Ans)
            {
                ButtonCorrect();
            }
            else
            {
                ButtonWrong();
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
                        Max_PlayerCorrectScore = 60; //Set Level Max Correct Score
                        Max_PlayerWrongScore = 5; //Set Level Max Wrong Score
                        CorrectScore_Req.Text = "/" + Max_PlayerCorrectScore; //Show in UI Max Correct Score
                        WrongScore_Req.Text = "/" + Max_PlayerWrongScore; //Show in UI Max Wrong Score
                        WrongScore_Req.Margin = new Thickness(0, 0, 30, 40); //Update Wrong Score Requarment Margin
                        PlayerScoreWrong_Label.Margin = new Thickness(0, 0, 60,40); //Update Player Wrong Score Margin
                        LevelAdress = "Transcription"; //Initialize Loaded Level is Transcription
                        await Task.Delay(250); // 1/4 second waiting before continue
                        Levels_Design(); //Load Level Design & UI
                        Level_Start(); //Start Transription Level
                        break;

                    case 2: // If Symbol Button is Pressed

                        Loaded_Level = "Symbol"; //Set Loaded is Symbol
                        Max_PlayerCorrectScore = 99; //Set Level Max Correct Score
                        Max_PlayerWrongScore = 15; //Set Level Max Wrong Score
                        CorrectScore_Req.Text = "/" + Max_PlayerCorrectScore; //Show in UI Max Correct Score
                        WrongScore_Req.Text = "/" + Max_PlayerWrongScore; //Show in UI Max Wrong Score
                        WrongScore_Req.Margin = new Thickness(0,0,23,40); //Update Wrong Score Requarment Margin
                        PlayerScoreWrong_Label.Margin = new Thickness(0, 0, 70, 40); //Update Player Wrong Score Margin
                        LevelAdress = "Symbol"; //Initialize Loaded Level is Symbol
                        await Task.Delay(250); // 1/4 second waiting before continue
                        Level_Choice_Dropdown.IsVisible = true; //Show Level Choice Combo Box
                        Symbol_Level_Choice_Btn.IsVisible = true; //Show Level Choice Button
                        Level_Choice_BtnText.IsVisible = true; //Show Level Choice Button Text
                        Levels_Design(); //Load Level Design & UI
                        Level_Start(); //Start Symbol Level
                        break;

                    case 3: // If Translate Button is Pressed
                        Loaded_Level = "Translate";
                        Max_PlayerCorrectScore = 99; //Set Level Max Correct Score
                        Max_PlayerWrongScore = 15; //Set Level Max Wrong Score
                        CorrectScore_Req.Text = "/" + Max_PlayerCorrectScore; //Show in UI Max Correct Score
                        WrongScore_Req.Text = "/" + Max_PlayerWrongScore; //Show in UI Max Wrong Score
                        WrongScore_Req.Margin = new Thickness(0, 0, 23, 40); //Update Wrong Score Requarment Margin
                        PlayerScoreWrong_Label.Margin = new Thickness(0, 0, 70, 40); //Update Player Wrong Score Margin
                        LevelAdress = "Translate"; //Initialize Loaded Level is Translate
                        await Task.Delay(250); // 1/4 second waiting before continue
                        Level_Choice_Dropdown.IsVisible = true; //Show Level Choice Combo Box
                        Symbol_Level_Choice_Btn.IsVisible = true;//Show Level Choice Button
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

        private void Level_Start()
        {
            Scores_Grid.IsVisible = true;

            SetButtonsImg(); //Call Function to Set to All Buttons Image 
            Elements_Quantity = 6;

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
            if (Loaded_Level == "Transcription")
            {
                GenIndex = MyRandom.Next(Elements_Quantity); //Generate Random Number EQUAL to Index of Numbers_Transcription_List
                GuessWord_Label.Text = Numbers_Transcription_List[GenIndex]; //Show the Random Array Element on GuessWord Label
            }
            else if (Loaded_Level == "Symbol")
            {
                GenIndex = MyRandom.Next(Elements_Quantity);
                GuessWord_Label.Text = Numbers_Symbol_List[GenIndex];
            }
            else if(Loaded_Level == "Translate")
            {
                //Three Levels
                if (PlayerScore_Correct < Level3_Req || Level_Choosed == "Lvl2") //Levels 1 & 2 - Guess Word is int Number - Translation of the Number
                {
                    GenIndex = MyRandom.Next(Elements_Quantity);
                    GuessWord_Label.Text = Numbers_Translate_List[GenIndex];
                }
                if (PlayerScore_Correct >= Level3_Req || Level_Choosed == "Lvl3") //Level 3 - Guess Word is string Transcription of the Number
                {
                    GenIndex = MyRandom.Next(Elements_Quantity);
                    GuessWord_Label.Text = Numbers_Transcription_List[GenIndex];
                }
                
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

            //Wrong Buttons Answers
            int WrongButton_Ans1;
            int WrongButton_Ans2;
            string Translate_WrongButton1;
            string Translate_WrongButton2;

            if (Loaded_Level == "Transcription")
            {
                Generate_TranscrAnswers();
            }
            else if (Loaded_Level == "Symbol")
            {
                if (PlayerScore_Correct < Level3_Req || Level_Choosed == "Lvl2")
                {
                    SymbolCorrect_Ans = Numbers_Translate_List[GenIndex]; //Get Element which is correct answer
                    Generate_SymbolsAnswers_Lvl1_Lvl2();
                }
                if (PlayerScore_Correct >= Level3_Req || Level_Choosed == "Lvl3")
                {
                    SymbolCorrect_Ans = Numbers_Transcription_List[GenIndex]; //Get Element which is correct answer
                    Generate_SymbolsAnswers_Lvl3();
                }

                switch (CorAswIndex)
                {
                    case 0: //If ID is 0 => Button1 contains the correct answer
                        Button1_Label.Text = SymbolCorrect_Ans; //Print it on Button1 Label
                        IsButton1_Free = false;
                        break;
                    case 1: //If ID is 1 => Button2 contains the correct answer
                        Button2_Label.Text = SymbolCorrect_Ans; //Print it on Button2 Label
                        IsButton2_Free = false;
                        break;
                    case 2: //If ID is 2 => Button3 contains the correct answer
                        Button3_Label.Text = SymbolCorrect_Ans; //Print it on Button3 Label
                        IsButton3_Free = false;
                        break;
                }
            }
            else if (Loaded_Level == "Translate")
            {
                TranslateCorrect_Ans = Numbers_Symbol_List[GenIndex]; //Get Element which is correct answer
                
                switch (CorAswIndex)
                {
                    case 0: //If ID is 0 => Button1 contains the correct answer
                        Button1_Label.Text = TranslateCorrect_Ans; //Print it on Button1 Label
                        IsButton1_Free = false;
                        break;
                    case 1: //If ID is 1 => Button2 contains the correct answer
                        Button2_Label.Text = TranslateCorrect_Ans; //Print it on Button2 Label
                        IsButton2_Free = false;
                        break;
                    case 2: //If ID is 2 => Button3 contains the correct answer
                        Button3_Label.Text = TranslateCorrect_Ans; //Print it on Button3 Label
                        IsButton3_Free = false;
                        break;
                }
                Generate_TranslateAnswers();
            }

            void Generate_TranscrAnswers()
            {
                switch (CorAswIndex)
                {
                    case 0: //If Random Number is 0
                        Button1_Label.Text = GenIndex.ToString(); //Apply Correct Answer to Button1 Label 
                        IsButton1_Free = false; //Update whitch Buttons are available 
                        break;
                    case 1: //If Random Number is 1
                        Button2_Label.Text = GenIndex.ToString(); //Apply Correct Answer to Button2 Label 
                        IsButton2_Free = false; //Update whitch Buttons are available 
                        break;
                    case 2: //If Random Number is 2
                        Button3_Label.Text = GenIndex.ToString(); //Apply Correct Answer to Button3 Label  
                        IsButton3_Free = false; //Update whitch Buttons are available 
                        break;
                }

                WrongButton_Ans1 = MyRandom.Next(Numbers_Transcription_List.Count); //Generate Wrong Answer 1
                WrongButton_Ans2 = MyRandom.Next(Numbers_Transcription_List.Count); //Generate Wrong Answer 2

                if (WrongButton_Ans1 == GenIndex) //If Wrong Answer1 = Correct Answer
                {
                    WrongButton_Ans1 = MyRandom.Next(Numbers_Transcription_List.Count - GenIndex); //Generate Wrong Answer 1
                }
                if (WrongButton_Ans2 == WrongButton_Ans1) //If Wrong Answer1 = Wrong Answer2
                {
                    WrongButton_Ans2 = MyRandom.Next(Numbers_Transcription_List.Count - WrongButton_Ans1); //Generate new Wrong Answer2
                }
                if (WrongButton_Ans2 == GenIndex) //If Wrong Answer2 = Correct Answer
                {
                    WrongButton_Ans2 = MyRandom.Next(Numbers_Transcription_List.Count - GenIndex); //Generate new Wrong Answer2
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

            void Generate_SymbolsAnswers_Lvl1_Lvl2()
            {
                WrongButton_Ans1 = MyRandom.Next(Numbers_Translate_List.Count); //Generate Wrong Answer 1
                WrongButton_Ans2 = MyRandom.Next(Numbers_Translate_List.Count); //Generate Wrong Answer 2

                if (WrongButton_Ans1.ToString() == SymbolCorrect_Ans) //If Wrong Answer1 = Correct Answer
                {
                    WrongButton_Ans1 = MyRandom.Next(Numbers_Translate_List.Count); //Generate Wrong Answer 1
                }
                if (WrongButton_Ans2.ToString() == WrongButton_Ans1.ToString()) //If Wrong Answer1 = Wrong Answer2
                {
                    WrongButton_Ans2 = MyRandom.Next(Numbers_Translate_List.Count - WrongButton_Ans1); //Generate new Wrong Answer2
                }
                if (WrongButton_Ans2.ToString() == SymbolCorrect_Ans) //If Wrong Answer2 = Correct Answer
                {
                    WrongButton_Ans2 = MyRandom.Next(Numbers_Translate_List.Count); //Generate new Wrong Answer2
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

            void Generate_SymbolsAnswers_Lvl3()
            {
                WrongButton_Ans1 = MyRandom.Next(Numbers_Transcription_List.Count); //Generate Wrong Answer 1
                WrongButton_Ans2 = MyRandom.Next(Numbers_Transcription_List.Count); //Generate Wrong Answer 2

                if (WrongButton_Ans1.ToString() == SymbolCorrect_Ans) //If Wrong Answer1 = Correct Answer
                {
                    WrongButton_Ans1 = MyRandom.Next(Numbers_Transcription_List.Count); //Generate Wrong Answer 1
                }
                if (WrongButton_Ans2.ToString() == WrongButton_Ans1.ToString()) //If Wrong Answer1 = Wrong Answer2
                {
                    WrongButton_Ans2 = MyRandom.Next(Numbers_Transcription_List.Count - WrongButton_Ans1); //Generate new Wrong Answer2
                }
                if (WrongButton_Ans2.ToString() == SymbolCorrect_Ans) //If Wrong Answer2 = Correct Answer
                {
                    WrongButton_Ans2 = MyRandom.Next(Numbers_Transcription_List.Count); //Generate new Wrong Answer2
                }

                //Check witch Buttons are FREE to Apply Number
                if (IsButton1_Free == true && IsButton2_Free == true)
                {
                    Button1_Label.Text = Numbers_Transcription_List[WrongButton_Ans1]; //Apply Wrong Answer to Button1 Label 
                    Button2_Label.Text = Numbers_Transcription_List[WrongButton_Ans2]; //Apply Wrong Answer to Button2 Label   
                }
                if (IsButton1_Free == true && IsButton3_Free == true)
                {
                    Button1_Label.Text = Numbers_Transcription_List[WrongButton_Ans1]; //Apply Wrong Answer to Button1 Label 
                    Button3_Label.Text = Numbers_Transcription_List[WrongButton_Ans2]; //Apply Wrong Answer to Button3 Label   
                }
                if (IsButton2_Free == true && IsButton3_Free == true)
                {
                    Button2_Label.Text = Numbers_Transcription_List[WrongButton_Ans1]; //Apply Wrong Answer to Button2 Label   
                    Button3_Label.Text = Numbers_Transcription_List[WrongButton_Ans2]; //Apply Wrong Answer to Button3 Label   
                }
            }

            void Generate_TranslateAnswers()
            {
                WrongButton_Ans1 = MyRandom.Next(Numbers_Symbol_List.Count); //Generate Wrong Answer 1
                WrongButton_Ans2 = MyRandom.Next(Numbers_Symbol_List.Count); //Generate Wrong Answer 2
                Translate_WrongButton1 = Numbers_Symbol_List[WrongButton_Ans1];
                Translate_WrongButton2 = Numbers_Symbol_List[WrongButton_Ans2];

                if (Translate_WrongButton1 == TranslateCorrect_Ans) //If Wrong Answer1 = Correct Answer
                {
                    WrongButton_Ans1 = MyRandom.Next(Numbers_Symbol_List.Count); //Generate Wrong Answer 1
                    Translate_WrongButton1 = Numbers_Symbol_List[WrongButton_Ans1];
                }
                if (Translate_WrongButton2 == WrongButton_Ans1.ToString()) //If Wrong Answer1 = Wrong Answer2
                {
                    WrongButton_Ans2 = MyRandom.Next(Numbers_Symbol_List.Count - WrongButton_Ans1); //Generate new Wrong Answer2
                    Translate_WrongButton2 = Numbers_Symbol_List[WrongButton_Ans2];
                }
                if (Translate_WrongButton2 == TranslateCorrect_Ans) //If Wrong Answer2 = Correct Answer
                {
                    WrongButton_Ans2 = MyRandom.Next(Numbers_Symbol_List.Count); //Generate new Wrong Answer2
                    Translate_WrongButton2 = Numbers_Symbol_List[WrongButton_Ans2];
                }

                //Check witch Buttons are FREE to Apply Number
                if (IsButton1_Free == true && IsButton2_Free == true)
                {
                    Button1_Label.Text = Translate_WrongButton1; //Apply Wrong Answer to Button1 Label 
                    Button2_Label.Text = Translate_WrongButton2; //Apply Wrong Answer to Button2 Label   
                }
                if (IsButton1_Free == true && IsButton3_Free == true)
                {
                    Button1_Label.Text = Translate_WrongButton1; //Apply Wrong Answer to Button1 Label 
                    Button3_Label.Text = Translate_WrongButton2; //Apply Wrong Answer to Button3 Label   
                }
                if (IsButton2_Free == true && IsButton3_Free == true)
                {
                    Button2_Label.Text = Translate_WrongButton1; //Apply Wrong Answer to Button2 Label   
                    Button3_Label.Text = Translate_WrongButton2; //Apply Wrong Answer to Button3 Label   
                }
            }

        }

        private void ButtonCorrect()
        {
            switch(My_Button_Pressed)
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
            switch(My_Button_Pressed)
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
                if (PlayerScore_Correct == Level2_Req) //If Player Score equal to 10
                {
                    Numbers_Transcription_List.AddRange(Numbers_Transcription_Lvl2_Arr); //Add to Numbers list Numers to 10 
                    Elements_Quantity = 11; //Get a new Quantity of Numbers in the level
                }
            }
            else if (Loaded_Level == "Symbol")
            {
                if (PlayerScore_Correct == Level2_Req || Level_Choosed == "Lvl2") //If Player Score equal to 10
                {
                    Numbers_Symbol_List.AddRange(Numbers_Symbol_Lvl2_Arr);
                    Elements_Quantity = 11; //Get a new Quantity of Numbers in the level
                    Numbers_Translate_List.AddRange(Numbers_Translate_Lvl2_Arr);
                }
                else if (PlayerScore_Correct == Level3_Req || Level_Choosed == "Lvl3")
                {
                    Elements_Quantity = 11; //Get a new Quantity of Numbers in the level
                    Numbers_Translate_List.AddRange(Numbers_Translate_Lvl2_Arr);
                    Numbers_Transcription_List.AddRange(Numbers_Transcription_Lvl2_Arr);
                }
            }
            else if(Loaded_Level == "Translate")
            {
                if (PlayerScore_Correct == Level2_Req || Level_Choosed == "Lvl2") //If Player Score equal to 10
                {
                    Numbers_Translate_List.AddRange(Numbers_Translate_Lvl2_Arr);
                    Elements_Quantity = 11; //Get a new Quantity of Numbers in the level
                    Numbers_Transcription_List.AddRange(Numbers_Transcription_Lvl2_Arr);
                }
                else if (PlayerScore_Correct == Level3_Req || Level_Choosed == "Lvl3")
                {
                    Elements_Quantity = 11; //Get a new Quantity of Numbers in the level
                    Numbers_Transcription_List.AddRange(Numbers_Transcription_Lvl2_Arr);
                    Numbers_Symbol_List.AddRange(Numbers_Symbol_Lvl2_Arr);
                }
            }
            else if(Loaded_Level == "Translate")
            {
                if (PlayerScore_Correct == Level2_Req || Level_Choosed == "Lvl2") //If Player Score equal to 10
                {
                    Numbers_Translate_List.AddRange(Numbers_Translate_Lvl2_Arr);
                    Elements_Quantity = 11; //Get a new Quantity of Numbers in the level
                    Numbers_Transcription_List.AddRange(Numbers_Transcription_Lvl2_Arr);
                }
                else if (PlayerScore_Correct == Level3_Req || Level_Choosed == "Lvl3")
                {
                    Numbers_Symbol_List.AddRange(Numbers_Symbol_Lvl2_Arr);
                }
            }
        }

        public async void ScoreCheck() //Track Player Scores
        {
            PageAdress = "Numbers";
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

        private void Symbol_Level_Choice_Btn_Clicked(object sender, EventArgs e)
        {
            //check Loaded Level

            if(Level_Choice_Dropdown.SelectedItem != null)
            {
                string LevelChoice = Level_Choice_Dropdown.SelectedItem.ToString();

                if (Loaded_Level == "Symbol")
                {
                    switch (LevelChoice)
                    {
                        case "Level 1 - Translate Numbers [0 - 5]":
                            Level_Choosed = "Lvl1";
                            DisplayAlert("Chosen Level: ", LevelChoice, "Ok");
                            Generate_ButtonsAnswers();
                            break;
                        case "Level 2 - Translate Numbers [0 - 10]":
                            Level_Choosed = "Lvl2";
                            //IsLvl2Choosen
                            DisplayAlert("Chosen Level: ", LevelChoice, "Ok");
                            Generate_ButtonsAnswers();
                            break;
                        case "Lvl3 - Transcription Numbers [0 - 10]":
                            Level_Choosed = "Lvl3";
                            DisplayAlert("Chosen Level: ", LevelChoice, "Ok");
                            Generate_ButtonsAnswers();
                            break;
                    }
                }
                else if (Loaded_Level == "Translate")
                {
                    switch (LevelChoice)
                    {
                        case "Level 1 - Translate Numbers [0 - 5]":
                            Level_Choosed = "Lvl1";
                            Generate_ButtonsAnswers();
                            DisplayAlert("Chosen Level: ", LevelChoice, "Ok");
                            break;
                        case "Level 2 - Translate Numbers [0 - 10]":
                            Level_Choosed = "Lvl2";
                            Generate_ButtonsAnswers();
                            DisplayAlert("Chosen Level: ", LevelChoice, "Ok");
                            break;
                        case "Lvl3 - Transcription Numbers [0 - 10]":
                            Level_Choosed = "Lvl3";
                            Generate_ButtonsAnswers();
                            DisplayAlert("Chosen Level: ", LevelChoice, "Ok");
                            break;
                    }
                }
                else if (Loaded_Level == "Translate")
                {
                    switch (LevelChoice)
                    {
                        case "Level 1 - Transcription Numbers [0 - 5]":
                            Level_Choosed = "Lvl1";
                            Generate_ButtonsAnswers();
                            DisplayAlert("Chosen Level: ", LevelChoice, "Ok");
                            break;
                        case "Level 2 - Transcription Numbers [0 - 10]":
                            Level_Choosed = "Lvl2";
                            Generate_ButtonsAnswers();
                            DisplayAlert("Chosen Level: ", LevelChoice, "Ok");
                            break;
                        case "Lvl3 - Symbols Numbers [0 - 10]":
                            Level_Choosed = "Lvl3";
                            Generate_ButtonsAnswers();
                            DisplayAlert("Chosen Level: ", LevelChoice, "Ok");
                            break;
                    }
                }
                PlayerScore_Correct = 0;
                PlayerScoreCorrect_Label.Text = PlayerScore_Correct.ToString(); //Update Player Score Label
                PlayerScore_Wrong = 0;
                PlayerScoreWrong_Label.Text = PlayerScore_Wrong.ToString(); //Show Player Score Label

                SetButtonsImg();
                Generate_GuessNum();
            }

        }

    }
}