﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms; 
using Xamarin.Forms.Xaml;

using TrackApp.ViewModels;

namespace TrackApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Run : ContentPage
	{
        public String Signal = "Start";
        decimal SplitMin = 0m;
        decimal SplitSec = 0m;

        public Run()
		{
            InitializeComponent();
            
            BindingContext = new RunViewModel();
            NewRunBtn.Clicked += ShowPopup;
            StartNewRunBtn.Clicked += StartRun;
            CancelNewRunBtn.Clicked += HidePopup;
            ResetRunBtn.Clicked += ResetRun;
            TimeLabel.FontSize += 28;
            progressBar.Minimum = 0;
            SplitField.FontSize += 12;
            
            
            
        }
           
        private void ShowPopup(object sender, EventArgs e)
        {           
            if ("Stop".Equals(Signal))
            {
                Signal = "Continue";
                NewRunBtn.Image = "baseline_play_arrow_white_48.png";
                NewRunBtn.SetBinding(Button.CommandProperty, "ContinueRunCommand");
                ResetRunBtn.IsVisible = true;
                ResetRunBtn.Text = "Reset";
                ResetRunBtn.SetBinding(Button.CommandProperty, "ResetRunCommand");

            } else if ("Continue".Equals(Signal))
            {
                Signal = "Stop";
                NewRunBtn.Image = "baseline_pause_white_48.png";
                NewRunBtn.SetBinding(Button.CommandProperty, "StopRunCommand");


                ResetRunBtn.SetBinding(Button.CommandProperty, "Throwaway");


            } else
            {
                NewRunPopup.IsVisible = true;
                NewRunBtn.SetBinding(Button.CommandProperty, "StopRunCommand");
                ResetRunBtn.IsEnabled = true;
            }
                     
        }

        private void HidePopup(object sender, EventArgs e)
        {
            NewRunPopup.IsVisible = false;
        }

        private void ResetRun(object sender, EventArgs e)
        {
            NewRunBtn.Image = "baseline_play_arrow_white_48.png";
            Signal = "Start";
            ResetRunBtn.IsVisible = false;

            if (ResetRunBtn.Text.Equals("Reset"))
            {
                NewRunBtn.Text = "Start";
                ResetRunBtn.Text = "Split";
                ResetRunBtn.SetBinding(Button.CommandProperty, "Throwaway");
                ResetRunBtn.IsEnabled = false;
                SplitMin = 0m;
                SplitSec = 0m;
                SplitField.IsVisible = false;
            } else if (ResetRunBtn.Text.Equals("Split"))
            {
                string[] CurrentTimeInputs = TimeLabel.Text.Split(':');

                decimal.TryParse(CurrentTimeInputs[0], out decimal CurrentTimeMin);
                decimal.TryParse(CurrentTimeInputs[1], out decimal CurrentTimeSec);



                decimal NewSplitMin = CurrentTimeMin - SplitMin;
                decimal NewSplitSec = CurrentTimeSec - SplitSec;
                decimal Current = Convert.ToDecimal("" + CurrentTimeMin + CurrentTimeSec);
                decimal Split = Convert.ToDecimal("" + SplitMin + SplitSec);
                decimal CurSplit = Current - Split;
                SplitMin = CurrentTimeMin;
                SplitSec = CurrentTimeSec;
                SplitField.IsVisible = true;
                SplitField.Text = CurSplit.ToString();
            }
        }

        private void StartRun(object sender, EventArgs e)
        {
            NewRunPopup.IsVisible = false;
            NewRunBtn.Image = "baseline_pause_white_48.png";
            Signal = "Stop";
            GoalTimeInput.Value = "";
            RunDistanceInput.Value = "";
            SplitDistanceInput.Value = "";
            ResetRunBtn.RemoveBinding(Button.CommandProperty);
        }
    }
}