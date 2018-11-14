using System;
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
        int SplitMin = 0;
        int SplitSec = 0;
        int SplitMil = 0;
        public String startBtnSignal = "Start";
        public String resetBtnSignal = "Reset";
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
            if ("Stop".Equals(startBtnSignal))
            {
                startBtnSignal = "Continue";
                NewRunBtn.Image = "baseline_play_arrow_white_48.png";
                NewRunBtn.SetBinding(Button.CommandProperty, "ContinueRunCommand");
                ResetRunBtn.IsVisible = true;
                resetBtnSignal = "Reset";
                ResetRunBtn.Image = "baseline_replay_white_48.png";
                ResetRunBtn.SetBinding(Button.CommandProperty, "ResetRunCommand");

            } else if ("Continue".Equals(startBtnSignal))
            {
                startBtnSignal = "Stop";
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
            startBtnSignal = "Start";
            ResetRunBtn.IsVisible = false;

            if ("Reset".Equals(resetBtnSignal))
            {
                startBtnSignal = "Start";
                resetBtnSignal = "Split";
                ResetRunBtn.Image = "baseline_outlined_flag_white_48.png";
                ResetRunBtn.SetBinding(Button.CommandProperty, "Throwaway");
                ResetRunBtn.IsEnabled = false;
                SplitMin = 0;
                SplitSec = 0;
                SplitMil = 0;
                SplitField.IsVisible = false;
            } else if ("Split".Equals(resetBtnSignal))
            {
                string[] CurrentTimeInputs = TimeLabel.Text.Split(':');

                int.TryParse(CurrentTimeInputs[0], out int CurrentTimeMin);
                int.TryParse(CurrentTimeInputs[1], out int CurrentTimeSec);
                int.TryParse(CurrentTimeInputs[2], out int CurrentTimeMil);


                TimeSpan current = new TimeSpan(0, 0, CurrentTimeMin, CurrentTimeSec, CurrentTimeMil);
                TimeSpan split = new TimeSpan(0, 0, SplitMin, SplitSec, SplitMil);
                TimeSpan NewSplit = current - split;
                //decimal NewSplitMin = CurrentTimeMin - SplitMin;
                //decimal NewSplitSec = CurrentTimeSec - SplitSec;
                //decimal NewSplit = Convert.ToDecimal("" + NewSplitMin + NewSplitSec);
                //decimal Current = Convert.ToDecimal("" + CurrentTimeMin + CurrentTimeSec);
                // decimal Split = Convert.ToDecimal("" + SplitMin + SplitSec);
                // decimal CurSplit = Current - Split;
                SplitMin = CurrentTimeMin;
                SplitSec = CurrentTimeSec;
                SplitMil = CurrentTimeMil;
                SplitField.IsVisible = true;
                SplitField.Text = NewSplit.ToString(@"mm\:ss\:ff");
            }
        }

        private void StartRun(object sender, EventArgs e)
        {
            NewRunPopup.IsVisible = false;
            NewRunBtn.Image = "baseline_pause_white_48.png";
            startBtnSignal = "Stop";
            GoalTimeInput.Value = "";
            RunDistanceInput.Value = "";
            SplitDistanceInput.Value = "";
            ResetRunBtn.RemoveBinding(Button.CommandProperty);
        }
    }
}