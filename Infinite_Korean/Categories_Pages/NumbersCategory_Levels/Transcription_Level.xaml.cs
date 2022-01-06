using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Infinite_Korean.Categories_Pages.NumbersCategory_Levels
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Transcription_Level : ContentPage
    {
        Random rand = new Random();

        //Variables
        string[] Numbers_Transcription_Arr = { "yeong", "hana", "dul", "set", "net", "daseot" }; //Array with Korean Numbers Transcription
        string[] Numbers_Transcription_Lvl2_Arr = { "yeoseot", "ilgop", "yeodeol","ahop","yeol"}; //Array with Korean Numbers Transcription Lvl 2
        //char[] Numbers_Translation_Arr = { '0', '1', '2', '3', '4', '5' }; //Array with Translation of Numbers
        //string[] Numbers_Translation_Lvl2_Arr = { "6", "7", "8", "9","10"}; //Array with Translation of Numbers

        List<string> Numbers_Transcription_List = new List<string>(); //List with Korean Numbers

        int Elements_Quantity = 6; //Quantity of Numbers in the Level [0 - 5]
        int PlayerScore_Correct; //Player Correct Score
        int PlayerScore_Wrong; //Player Wrong Score
        int GenIndex; //GuessWord Number
        int CorAswIndex; //Number with Correct Answer
        int Max_PlayerCorrectScore = 60;
        int Max_PlayerWrongScore = 5;

        //Public for all files variable to Initialize to which Page to Append End Level Pages ( Passed Page and Try Again Page )
        public static string PageAdress = "Numbers";

        public Transcription_Level()
        {
            InitializeComponent();

            //On Level Load
            ApplyButtImg(); //Setup Buttons
            StartLevel(); //Start Game
        }

        private void StartLevel()
        {
            for(int i = 0; i < Elements_Quantity; i++)
            {
                Numbers_Transcription_List.Add(Numbers_Transcription_Arr[i]); //Fill Numbers List
            }
            Generate_GuessNum(); //Call Function to Generate Guess Word
            Generate_ButtonsAnswers(); //Call Function to Apply Correct and Wrong Answers to Buttons

            //Set Player Score - Correct & Wrong
            PlayerScore_Correct = 0;
            PlayerScoreCorrect_Label.Text = PlayerScore_Correct.ToString();
            PlayerScore_Wrong = 0;
            PlayerScoreWrong_Label.Text = PlayerScore_Correct.ToString();
        }

        private void ApplyButtImg()
        {
            //Apply Button Default Image 
            Button1.Source = "Button_Default.png";
            Button2.Source = "Button_Default.png";
            Button3.Source = "Button_Default.png";

            //Set Buttons are ENABLED
            Button1.IsEnabled = true;
            Button2.IsEnabled = true;
            Button3.IsEnabled = true;
        }

        private void BlockAllButtons()
        {
            //Set Buttons are DISABLED
            Button1.IsEnabled = false;
            Button2.IsEnabled = false;
            Button3.IsEnabled = false;
        }

        private void Generate_GuessNum() //Generate Random Korean Number
        {
            GenIndex = rand.Next(Elements_Quantity); //Generate Random Number EQUAL to Index of Numbers_Transcription_List
            GuessWord_Label.Text = Numbers_Transcription_List[GenIndex]; //Show the Random Array Element on GuessWord Label
            //GuessWord_Label.Text = Numbers_Translation_Arr2[GenIndex];
        }
        private void Generate_ButtonsAnswers()
        {
            //Choose witch Button Label to contains the CORRECT Answer
            CorAswIndex = rand.Next(3); //Genrate Random Number [0 - 2] EQUAL to Buttons Labels Quantity

            //Buttons are Free to apply Text
            bool IsButton1_Free = true;
            bool IsButton2_Free = true;
            bool IsButton3_Free = true;

            int WrongButton_Ans1; //First Button with Wrong Answer
            int WrongButton_Ans2; //Second Button with Wrong Answer

            switch (CorAswIndex)
            {
                case 0: //If Random Number is 0
                    Button1Text_Label.Text = GenIndex.ToString(); //Apply Correct Answer to Button1 Label 

                    //Update whitch Buttons are available 
                    IsButton1_Free = false;
                    break;
                case 1: //If Random Number is 1
                    Button2Text_Label.Text = GenIndex.ToString(); //Apply Correct Answer to Button2 Label 
                   
                    //Update whitch Buttons are available 
                    IsButton2_Free = false;
                    break;
                case 2: //If Random Number is 2
                    Button3Text_Label.Text = GenIndex.ToString(); //Apply Correct Answer to Button3 Label 
                    
                    //Update whitch Buttons are available 
                    IsButton3_Free = false;
                    break;
            }

            WrongButton_Ans1 = rand.Next(Numbers_Transcription_List.Count - GenIndex); //Generate Wrong Answer 1
            WrongButton_Ans2 = rand.Next(Numbers_Transcription_List.Count - GenIndex); //Generate Wrong Answer 2

            if(WrongButton_Ans1 == GenIndex) //If Wrong Answer1 = Correct Answer
            {
                WrongButton_Ans1 = rand.Next(0, Numbers_Transcription_List.Count - GenIndex); //Generate Wrong Answer 1
            }
            if (WrongButton_Ans2 == WrongButton_Ans1) //If Wrong Answer1 = Wrong Answer2
            {
                WrongButton_Ans2 = rand.Next(0, Numbers_Transcription_List.Count - WrongButton_Ans1); //Generate new Wrong Answer2
            }
            if(WrongButton_Ans2 == GenIndex) //If Wrong Answer2 = Correct Answer
            {
                WrongButton_Ans2 = rand.Next(0, Numbers_Transcription_List.Count - GenIndex); //Generate new Wrong Answer2
            }

            //Check witch Buttons are FREE to Apply Number
            if (IsButton1_Free == true && IsButton2_Free == true)
            {            
                Button1Text_Label.Text = WrongButton_Ans1.ToString(); //Apply Wrong Answer to Button1 Label 
                Button2Text_Label.Text = WrongButton_Ans2.ToString(); //Apply Wrong Answer to Button2 Label   
            }
            if (IsButton1_Free == true && IsButton3_Free == true)
            {
                Button1Text_Label.Text = WrongButton_Ans1.ToString(); //Apply Wrong Answer to Button1 Label 
                Button3Text_Label.Text = WrongButton_Ans2.ToString(); //Apply Wrong Answer to Button3 Label   
            }
            if(IsButton2_Free == true && IsButton3_Free == true)
            {
                Button2Text_Label.Text = WrongButton_Ans1.ToString(); //Apply Wrong Answer to Button2 Label   
                Button3Text_Label.Text = WrongButton_Ans2.ToString(); //Apply Wrong Answer to Button3 Label   
            }

        }

        private void BackButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new Numbers_Category_Page(); //Return to Previous Page
        }

        private void Button1_Clicked(object sender, EventArgs e)
        {
            if (Button1Text_Label.Text == GenIndex.ToString())
            {
                Button1.Source = "Button_Correct.png"; //Set new Image on the Button
                PlayerScore_Correct++; //Update Correct Score
                PlayerScoreCorrect_Label.Text = PlayerScore_Correct.ToString(); //Update Player Score Label

                //Call Functions
                BlockAllButtons();
                DelayTime();

            }
            else
            {
                Button1.Source ="Button_Wrong.png"; //Set new Image on the Button
                PlayerScore_Wrong++; //Update Wrong Score
                PlayerScoreWrong_Label.Text= PlayerScore_Wrong.ToString(); //Update Player Wrong Label
                Button1.IsEnabled = false; //Disable the Button

                ScoreCheck();
            }
        }

        private void Button2_Clicked(object sender, EventArgs e)
        {
            if (Button2Text_Label.Text == GenIndex.ToString())
            {
                Button2.Source = "Button_Correct.png"; //Set new Image on the Button
                PlayerScore_Correct++; //Update Correct Score
                PlayerScoreCorrect_Label.Text = PlayerScore_Correct.ToString(); //Update Player Score Label

                //Call Functions
                BlockAllButtons();
                DelayTime();

            }
            else
            {
                Button2.Source ="Button_Wrong.png"; //Set new Image on the Button
                PlayerScore_Wrong++; //Update Wrong Score
                PlayerScoreWrong_Label.Text= PlayerScore_Wrong.ToString(); //Update Player Wrong Label
                Button2.IsEnabled = false; //Disable the Button

                ScoreCheck();
            }
        }

        private void Button3_Clicked(object sender, EventArgs e)
        {
            if (Button3Text_Label.Text == GenIndex.ToString())
            {
                Button3.Source = "Button_Correct.png"; //Set new Image on the Button
                PlayerScore_Correct++; //Update Correct Score
                PlayerScoreCorrect_Label.Text = PlayerScore_Correct.ToString(); //Update Player Score Label

                //Call Functions
                BlockAllButtons();
                DelayTime();

            }
            else
            {
                Button3.Source ="Button_Wrong.png"; //Set new Image on the Button
                PlayerScore_Wrong++; //Update Wrong Score
                PlayerScoreWrong_Label.Text= PlayerScore_Wrong.ToString(); //Update Player Wrong Label
                Button3.IsEnabled = false; //Disable the Button

                ScoreCheck();
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
            Generate_ButtonsAnswers(); //Call Function to Apply Correct and Wrong Answers to Buttons

            ApplyButtImg(); //Call Function to Apply the Default Image to the Buttons 
        }

        private void UpdateLevel() //Increase the Difficulty of the level
        {
            if(PlayerScore_Correct == 10) //If Player Score equal to 10
            {
                Numbers_Transcription_List.AddRange(Numbers_Transcription_Lvl2_Arr); //Add to Numbers list Numers to 10 
                Elements_Quantity = 11; //Сet a new Quantity of Numbers in the level
            }

        }

        private async void ScoreCheck() //Track Player Scores
        {
            if(PlayerScore_Correct == Max_PlayerCorrectScore)
            {
                App.Current.MainPage = new Level_End_Pages.Passed_Page(); //Go to Congrats Page
            }
            if(PlayerScore_Wrong == Max_PlayerWrongScore)
            {
                await Task.Delay(250); // 1/4 second waiting before continue
                App.Current.MainPage = new Level_End_Pages.TryAgain_Page(); //Go to Try Again Page
            }
        }

    }
}