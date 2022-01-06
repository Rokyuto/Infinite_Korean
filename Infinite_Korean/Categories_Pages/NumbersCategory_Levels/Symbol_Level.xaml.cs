using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Infinite_Korean.Categories_Pages.NumbersCategory_Levels
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Symbol_Level : ContentPage
    {
        Random MyRandom = new Random();

        //Variables
        string[] Numbers_Symbol_Arr = { "영", "하나", "둘", "셋", "넷", "다섯" }; //Array with Korean Numbers Symbols - Guess Words
        string[] Numbers_Symbol_Lvl2_Arr = { "여섯", "일곱", "여덟", "아홉", "열" }; //Array with Korean Numbers Symbols Lvl 2 - Guess Words

        string[] Numbers_Translate_Arr = {"0","1","2","3","4","5"}; //Array with Korean Symbols Meaning - Answers
        string[] Numbers_Translate_Lvl2_Arr = {"6", "7", "8", "9", "10"}; //Array with Korean Symbol Meaning - Answers - Lvl 2

        string[] Numbers_Transcription_Arr = { "yeong", "hana", "dul", "set", "net", "daseot" }; //Array with Korean Numbers Transcription - Lvl 3
        string[] Numbers_Transcription_Lvl2_Arr = { "yeoseot", "ilgop", "yeodeol", "ahop", "yeol" }; //Array with Korean Numbers Transcription Lvl 3

        List<string> Numbers_Symbol_List = new List<string>();
        List<string> Numbers_Translate_List = new List<string>();
        List<string> Numbers_Transcription_List = new List<string>();

        int ListQuantity;

        int GuessWord;
        string MyCorrect_Answer;

        int PlayerCorrect_Score;
        int PlayerWrong_Score;
        int Max_PlayerCorrect_Score = 99;
        int Max_PlayerWrong_Score = 15;

        int Level2_Req = 10;
        int Level3_Req = 50;

        int My_Button_Pressed = 0; //Track for which Button is pressed 

        public static string PageAdress = "Numbers"; //Initialize to which Page to Append End Level Pages ( Passed Page and Try Again Page )

        public Symbol_Level()
        {
            InitializeComponent();

            //On Level Load
            StartLevel();
        }

        private void StartLevel()
        {
            ListQuantity = 6;
            for (int CurrItem = 0; CurrItem < ListQuantity; CurrItem++)
            {
                Numbers_Symbol_List.Add(Numbers_Symbol_Arr[CurrItem]); //Fill Number Symbol List - Guess Word List
                Numbers_Translate_List.Add(Numbers_Translate_Arr[CurrItem]); //Fill Number Translate List - Answers List
            }

            //Set Player Score
            PlayerCorrect_Score = 0;
            PlayerScoreCorrect_Label.Text = PlayerCorrect_Score.ToString();
            PlayerWrong_Score = 0;
            PlayerScoreWrong_Label.Text = PlayerWrong_Score.ToString();

            //Call Functions
            SetButtonsImg(); //Apply Buttons Images
            Gen_GuessWord(); //Generate Guess Word
            Gen_ButtAnswers(); //Generate Buttons Answers
        }

        private void SetButtonsImg() //Set Buttons Images
        {
            My_Button1.Source="Button_Default.png";
            My_Button2.Source="Button_Default.png";
            My_Button3.Source="Button_Default.png";
        }

        private void Gen_GuessWord() //Generate Guess Word
        {
            GuessWord = MyRandom.Next(Numbers_Symbol_List.Count); //Generate Guess Number
            GuessWord_Label.Text = Numbers_Symbol_List[GuessWord]; //Print it on Guessing Label
        }

        private void Gen_ButtAnswers() //Generate Buttons Answer
        {
            int MyCorrect_Button = MyRandom.Next(3); //Button ID witch will contains the correct answer

            if(PlayerCorrect_Score < Level3_Req)
            {
                MyCorrect_Answer = Numbers_Translate_List[GuessWord]; //Get Element which is correct answer
            }
            if(PlayerCorrect_Score >= Level3_Req)
            {
                MyCorrect_Answer = Numbers_Transcription_List[GuessWord]; //Get Element which is correct answer
            }

            //Buttons are Free to apply Text
            bool IsButton1_Free = true;
            bool IsButton2_Free = true;
            bool IsButton3_Free = true;

            switch (MyCorrect_Button)
            {
                case 0: //If ID is 0 => Button1 contains the correct answer
                    My_Button1Text_Label.Text = MyCorrect_Answer; //Print it on Button1 Label
                    IsButton1_Free = false;
                    break;
                case 1: //If ID is 1 => Button2 contains the correct answer
                    My_Button2Text_Label.Text = MyCorrect_Answer; //Print it on Button2 Label
                    IsButton2_Free = false;
                    break;
                case 2: //If ID is 2 => Button3 contains the correct answer
                    My_Button3Text_Label.Text = MyCorrect_Answer; //Print it on Button3 Label
                    IsButton3_Free = false;
                    break;
            }

            int WrongButton_Ans1 = MyRandom.Next(Numbers_Translate_List.Count); //Generate Wrong Answer 1
            int WrongButton_Ans2 = MyRandom.Next(Numbers_Translate_List.Count); //Generate Wrong Answer 2

            if (WrongButton_Ans1.ToString() == MyCorrect_Answer) //If Wrong Answer1 = Correct Answer
            {   
                WrongButton_Ans1 = MyRandom.Next(Numbers_Translate_List.Count); //Generate Wrong Answer 1
            }
            if (WrongButton_Ans2.ToString()  == WrongButton_Ans1.ToString()) //If Wrong Answer1 = Wrong Answer2
            {
                WrongButton_Ans2 = MyRandom.Next(Numbers_Translate_List.Count - WrongButton_Ans1); //Generate new Wrong Answer2
            }
            if (WrongButton_Ans2.ToString()  == MyCorrect_Answer) //If Wrong Answer2 = Correct Answer
            {
                WrongButton_Ans2 = MyRandom.Next(Numbers_Translate_List.Count); //Generate new Wrong Answer2
            }

            //Check witch Buttons are FREE to Apply Number
            if (IsButton1_Free == true && IsButton2_Free == true)
            {
                My_Button1Text_Label.Text = WrongButton_Ans1.ToString(); //Apply Wrong Answer to Button1 Label 
                My_Button2Text_Label.Text = WrongButton_Ans2.ToString(); //Apply Wrong Answer to Button2 Label   
            }
            if (IsButton1_Free == true && IsButton3_Free == true)
            {
                My_Button1Text_Label.Text = WrongButton_Ans1.ToString(); //Apply Wrong Answer to Button1 Label 
                My_Button3Text_Label.Text = WrongButton_Ans2.ToString(); //Apply Wrong Answer to Button3 Label   
            }
            if (IsButton2_Free == true && IsButton3_Free == true)
            {
                My_Button2Text_Label.Text = WrongButton_Ans1.ToString(); //Apply Wrong Answer to Button2 Label   
                My_Button3Text_Label.Text = WrongButton_Ans2.ToString(); //Apply Wrong Answer to Button3 Label   
            }
        }

        private void BackButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new Numbers_Category_Page(); //Return to Previous Page
        }

        private void Button1_Clicked(object sender, EventArgs e)
        {
            My_Button_Pressed = 1; 
            if (My_Button1Text_Label.Text == MyCorrect_Answer)
            {
                IsButtonCorrect();
            }
            else
            {
                IsButtonWrong();
            }
        }

        private void Button2_Clicked(object sender, EventArgs e)
        {
            My_Button_Pressed = 2;

            if (My_Button2Text_Label.Text == MyCorrect_Answer)
            {
                IsButtonCorrect();
            }
            else
            {
                IsButtonWrong();
            }
        }

        private void Button3_Clicked(object sender, EventArgs e)
        {
            My_Button_Pressed = 3;

            if (My_Button3Text_Label.Text == MyCorrect_Answer)
            {
                IsButtonCorrect();
            }
            else
            {
                IsButtonWrong();
            }
        }

        private void IsButtonCorrect()
        {
            switch (My_Button_Pressed)
            { 
                case 1:
                    My_Button1.Source = "Button_Correct.png"; //Set new Image on the Button
                    PlayerCorrect_Score++; //Update Correct Score
                    PlayerScoreCorrect_Label.Text = PlayerCorrect_Score.ToString(); //Update Player Score Label
                    break;
                case 2:
                    My_Button2.Source = "Button_Correct.png"; //Set new Image on the Button
                    PlayerCorrect_Score++; //Update Correct Score
                    PlayerScoreCorrect_Label.Text = PlayerCorrect_Score.ToString(); //Update Player Score Label
                    break;
                case 3:
                    My_Button3.Source = "Button_Correct.png"; //Set new Image on the Button
                    PlayerCorrect_Score++; //Update Correct Score
                    PlayerScoreCorrect_Label.Text = PlayerCorrect_Score.ToString(); //Update Player Score Label
                    break;
            }

            //Call Function
            BlockAllButtons();
            DelayTime();
        }

        private void IsButtonWrong()
        {
            switch (My_Button_Pressed)
            {
                case 1:
                    My_Button1.Source ="Button_Wrong.png"; //Set new Image on the Button
                    PlayerWrong_Score++; //Update Wrong Score
                    PlayerScoreWrong_Label.Text= PlayerWrong_Score.ToString(); //Update Player Wrong Label
                    My_Button1.IsEnabled = false; //Disable the Button
                    break;
                case 2:
                    My_Button2.Source = "Button_Wrong.png"; //Set new Image on the Button
                    PlayerWrong_Score++; //Update Correct Score
                    PlayerScoreWrong_Label.Text = PlayerWrong_Score.ToString(); //Update Player Score Label
                    My_Button2.IsEnabled = false; //Disable the Button
                    break;
                case 3:
                    My_Button3.Source = "Button_Wrong.png"; //Set new Image on the Button
                    PlayerWrong_Score++; //Update Correct Score
                    PlayerScoreWrong_Label.Text = PlayerWrong_Score.ToString(); //Update Player Wrong Label
                    My_Button3.IsEnabled = false; //Disable the Button
                    break;
            }

            ScoreCheck();
        }

        private void BlockAllButtons()
        {
            My_Button1.IsEnabled = false;
            My_Button2.IsEnabled = false;
            My_Button3.IsEnabled = false;
        }

        private async void DelayTime()
        {
            await Task.Delay(250); // 1/4 second waiting before continue

            //Call Funtions
            ScoreCheck(); //Track Score
            NewWord(); //Regenerate the entire level
        }

        private async void ScoreCheck() //async
        {
            if (PlayerCorrect_Score == Max_PlayerCorrect_Score)
            {
                 App.Current.MainPage = new Level_End_Pages.Passed_Page(); //Go to Congrats Page
            }
            if (PlayerWrong_Score == Max_PlayerWrong_Score)
            {
                await Task.Delay(250); // 1/4 second waiting before continue
                App.Current.MainPage = new Level_End_Pages.TryAgain_Page(); //Go to Try Again Page
            }
        }

        private void NewWord() //Regenerate the entire level after Player Answer Correct
        {
            UpdateLevel(); //Call Function to Update the Numbers to 10
            Gen_GuessWord(); //Call Function to Generate Guess Word
            Gen_ButtAnswers(); //Call Function to Apply Correct and Wrong Answers to Buttons

            SetButtonsImg(); //Call Function to Apply the Default Image to the Buttons 
        }

        private void UpdateLevel() //Update Level - Goes to the next Level
        {
            if (PlayerCorrect_Score == Level2_Req) //If Player Score equal to 10 
            {
                Numbers_Symbol_List.AddRange(Numbers_Symbol_Lvl2_Arr); //Add to Numbers list Numbers to 10 
                ListQuantity = 11; //Get a new Quantity of Numbers in the level
                Numbers_Translate_List.AddRange(Numbers_Translate_Lvl2_Arr);
            }
            else if (PlayerCorrect_Score == Level3_Req)
            {
                Numbers_Transcription_List.AddRange(Numbers_Transcription_Arr);
                Numbers_Transcription_List.AddRange(Numbers_Transcription_Lvl2_Arr);
            }
        }

    }
}