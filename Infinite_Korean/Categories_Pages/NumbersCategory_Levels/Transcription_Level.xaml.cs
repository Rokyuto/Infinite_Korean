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
    public partial class Transcription_Level : ContentPage
    {
        Random rand = new Random();

        //Variables
        string[] Numbers_Transcription_Arr = {"yeong","hana","dul","sam","ne","daseos"}; //Array with Korean Numbers Transcription
        char[] Numbers_Translation_Arr = {'0','1','2','3','4','5'}; //Array with Translation of Numbers
        int PlayerScore_Correct = 0, PlayerScore_Wrong = 0;
        int GenIndex;
        int CorAswIndex;

        public Transcription_Level()
        {
            InitializeComponent();

         /*   Button1.Source = "Button_Default.png";
            Button2.Source = "Button_Default.png";
            Button3.Source = "Button_Default.png"; */

            StartLevel();
        }

        private void StartLevel()
        {
            Generate_GuessNum(); //Call Function to Generate Guess Word
            Generate_ButtonsAswers(); //Call Function to Apply Correct and Wrong Answers to Buttons
        }

        private void Generate_GuessNum() //Generate Random Korean Number
        {
            GenIndex = rand.Next(0, 5); //Generate Random Number [0 - 5] EQUAL to Index of Numbers_Transcription_Arr
            GuessWord_Label.Text = Numbers_Transcription_Arr[GenIndex]; //Show the Random Array Element on GuessWord Label
        }
        private void Generate_ButtonsAswers()
        {
            //Choose witch Button Label to contains the CORRECT Answer
            CorAswIndex = rand.Next(1,3); //Genrate Random Number [1 - 3] EQUAL to Buttons Labels Quantity

            //Buttons are Free to apply Text
            bool IsButton1_Free = true;
            bool IsButton2_Free = true;
            bool IsButton3_Free = true;

            int WrongButton_Ans1; //First Button with Wrong Answer
            int WrongButton_Ans2; //Second Button with Wrong Answer

            switch (CorAswIndex)
            {
                case 1: //If Random Number is 1
                    Button1Text_Label.Text = GenIndex.ToString(); //Apply Correct Answer to Button1 Label 

                    //Update whitch Buttons are available 
                    IsButton1_Free = false;
                    IsButton2_Free = true;
                    IsButton3_Free = true;
                    break;
                case 2: //If Random Number is 2
                    Button2Text_Label.Text = GenIndex.ToString(); //Apply Correct Answer to Button2 Label 
                   
                    //Update whitch Buttons are available 
                    IsButton2_Free = false;
                    IsButton1_Free = true;
                    IsButton3_Free = true;

                    break;
                case 3: //If Random Number is 3
                    Button3Text_Label.Text = GenIndex.ToString(); //Apply Correct Answer to Button3 Label 
                    
                    //Update whitch Buttons are available 
                    IsButton3_Free = false;
                    IsButton1_Free = true;
                    IsButton2_Free = true;
                    break;
            }

            WrongButton_Ans1 = rand.Next(0, Numbers_Translation_Arr.Length - GenIndex); //Generate Wrong Answer 1
            WrongButton_Ans2 = rand.Next(0, Numbers_Translation_Arr.Length - GenIndex); //Generate Wrong Answer 2

            if(WrongButton_Ans1 == GenIndex)
            {
                WrongButton_Ans1 = rand.Next(0, Numbers_Translation_Arr.Length - GenIndex); //Generate Wrong Answer 1
            }
            if (WrongButton_Ans2 == WrongButton_Ans1 || WrongButton_Ans2 == GenIndex) //If Wrong Answer1 = Wrong Answer2
            {
                WrongButton_Ans2 = rand.Next(0, Numbers_Translation_Arr.Length - GenIndex); //Generate new Wrong Answer2
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
            App.Current.MainPage = new Numbers_Category_Page();
        }

        private void Button1_Clicked(object sender, EventArgs e)
        {
            if (Button1Text_Label.Text == GenIndex.ToString())
            {
                Button1.Source = "Button_Correct.png"; //Set new Image on the Button
                PlayerScore_Correct++;
                PlayerScoreCorrect_Label.Text = PlayerScore_Correct.ToString();
            }
            else
            {
                Button1.Source ="Button_Wrong.png";
                PlayerScore_Wrong++;
                PlayerScoreWrong_Label.Text= PlayerScore_Wrong.ToString();

            }
        }

        private void Button2_Clicked(object sender, EventArgs e)
        {
            if (Button2Text_Label.Text == GenIndex.ToString())
            {
                Button2.Source = "Button_Correct.png"; //Set new Image on the Button
                PlayerScore_Correct++;
                PlayerScoreCorrect_Label.Text = PlayerScore_Correct.ToString();
            }
            else
            {
                Button2.Source ="Button_Wrong.png";
                PlayerScore_Wrong++;
                PlayerScoreWrong_Label.Text= PlayerScore_Wrong.ToString();
            }
        }

        private void Button3_Clicked(object sender, EventArgs e)
        {
            if (Button3Text_Label.Text == GenIndex.ToString())
            {
                Button3.Source = "Button_Correct.png"; //Set new Image on the Button
                PlayerScore_Correct++;
                PlayerScoreCorrect_Label.Text = PlayerScore_Correct.ToString();
            }
            else
            {
                Button3.Source ="Button_Wrong.png";
                PlayerScore_Wrong++;
                PlayerScoreWrong_Label.Text= PlayerScore_Wrong.ToString();
            }
        }

    }
}