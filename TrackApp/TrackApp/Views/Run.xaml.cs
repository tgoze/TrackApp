using System;

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
        String startBtnSignal = "Start";

        public Run()
		{
            InitializeComponent();
            
            BindingContext = new RunViewModel();
            NewRunBtn.Clicked += ShowPopup;
            StartNewRunBtn.Clicked += StartRun;
            CancelNewRunBtn.Clicked += HidePopup; 
            ResetRunBtn.Clicked += ResetRun;
            SplitRunBtn.Clicked += SplitRun;
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
            } else if ("Continue".Equals(startBtnSignal))
            {
                startBtnSignal = "Stop";
                NewRunBtn.Image = "baseline_pause_white_48.png";
                NewRunBtn.SetBinding(Button.CommandProperty, "StopRunCommand");

                //change Throwaway
                //ResetRunBtn.SetBinding(Button.CommandProperty, "Throwaway");
            } else
            {
                NewRunPopup.IsVisible = true;
            }
                     
        }

        private void HidePopup(object sender, EventArgs e)
        {
            NewRunPopup.IsVisible = false;
        }

        private void ResetRun(object sender, EventArgs e)
        {
            startBtnSignal = "Start";
            NewRunBtn.Image = "baseline_play_arrow_white_48.png";

            ResetRunBtn.IsVisible = false;

            SplitRunBtn.IsVisible = false;

            SplitMin = 0;
            SplitSec = 0;
            SplitMil = 0;
            SplitField.IsVisible = false;
        }

        private void SplitRun(object sender, EventArgs e)
        {
            string[] CurrentTimeInputs = TimeLabel.Text.Split(':');

            int.TryParse(CurrentTimeInputs[0], out int CurrentTimeMin);
            int.TryParse(CurrentTimeInputs[1], out int CurrentTimeSec);
            int.TryParse(CurrentTimeInputs[2], out int CurrentTimeMil);


            TimeSpan current = new TimeSpan(0, 0, CurrentTimeMin, CurrentTimeSec, CurrentTimeMil);
            TimeSpan split = new TimeSpan(0, 0, SplitMin, SplitSec, SplitMil);
            TimeSpan NewSplit = current - split;

            SplitMin = CurrentTimeMin;
            SplitSec = CurrentTimeSec;
            SplitMil = CurrentTimeMil;
            SplitField.IsVisible = true;
            SplitField.Text = NewSplit.ToString(@"mm\:ss\:ff");
        }
        private void StartRun(object sender, EventArgs e)
        {
            NewRunPopup.IsVisible = false;

            startBtnSignal = "Stop";
            NewRunBtn.Image = "baseline_pause_white_48.png";
            NewRunBtn.SetBinding(Button.CommandProperty, "StopRunCommand");

            GoalTimeInput.Value = "";
            RunDistanceInput.Value = "";
            SplitDistanceInput.Value = "";

            ResetRunBtn.IsVisible = true;
            ResetRunBtn.SetBinding(Button.CommandProperty, "ResetRunCommand");

            SplitRunBtn.IsVisible = true;
        }
    }
}