using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Syncfusion.XForms.ProgressBar;

using TrackApp.ViewModels;
using System.Collections.Generic;
using TrackApp.Models;

namespace TrackApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Run : ContentPage
	{
        int SplitMin = 0;
        int SplitSec = 0;
        int SplitMil = 0;
        string startBtnSignal = "Start";

        public int RunnerNumber { get; internal set; }
        internal List<TimeSpan> Splits { get; set; }

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
            Runner1.Clicked += IndividualSplitRun;
            Runner2.Clicked += IndividualSplitRun;
            Runner3.Clicked += IndividualSplitRun;
            Runner4.Clicked += IndividualSplitRun;
            Runner5.Clicked += IndividualSplitRun;
            Runner6.Clicked += IndividualSplitRun;
        }

        private void SetAnimationDuration(object sender, ProgressValueEventArgs e)
        {
            if (e.Progress.Equals(this.progressBar.Maximum))
            {
                progressBar.AnimationDuration = 0;
            }
        }

        private void SetProgressBarColors()
        {
            RangeColorCollection rangeColors = new RangeColorCollection
            {
                new RangeColor() { Color = Color.FromHex("88A0D9EF"), IsGradient = true, Start = 0, End = progressBar.Maximum * .25 },
                new RangeColor() { Color = Color.FromHex("AA62C1E5"), IsGradient = true, Start = progressBar.Maximum * .25, End = progressBar.Maximum * .5 },
                new RangeColor() { Color = Color.FromHex("DD20A7DB"), IsGradient = true, Start = progressBar.Maximum * .5, End = progressBar.Maximum * .75 },
                new RangeColor() { Color = Color.FromHex("FF1C96C5"), IsGradient = true, Start = progressBar.Maximum * .75, End = progressBar.Maximum }
            };

            progressBar.RangeColors = rangeColors;
        }
           
        private void ShowPopup(object sender, EventArgs e)
        {           
            if ("Stop".Equals(startBtnSignal))
            {
                startBtnSignal = "Continue";
                NewRunBtn.Image = "round_play_arrow_white_48.png";
                NewRunBtn.SetBinding(Button.CommandProperty, "ContinueRunCommand");
            } else if ("Continue".Equals(startBtnSignal))
            {
                startBtnSignal = "Stop";
                NewRunBtn.Image = "round_pause_white_48.png";
                NewRunBtn.SetBinding(Button.CommandProperty, "StopRunCommand");

                
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
            NewRunBtn.Image = "round_play_arrow_white_48.png";

            ResetRunBtn.IsVisible = false;

            SplitRunBtn.IsVisible = false;

            SplitMin = 0;
            SplitSec = 0;
            SplitMil = 0;
            SplitField.IsVisible = false;

            Runner1.IsVisible = false;
            Runner2.IsVisible = false;
            Runner3.IsVisible = false;
            Runner4.IsVisible = false;
            Runner5.IsVisible = false;
            Runner6.IsVisible = false;
        }

        private void SplitRun(object sender, EventArgs e)
        {
            string[] CurrentTimeInputs = TimeLabel.Text.Split(':');

            int.TryParse(CurrentTimeInputs[0], out int CurrentTimeMin);
            int.TryParse(CurrentTimeInputs[1], out int CurrentTimeSec);
            int.TryParse(CurrentTimeInputs[2], out int CurrentTimeMil);


            System.TimeSpan current = new System.TimeSpan(0, 0, CurrentTimeMin, CurrentTimeSec, CurrentTimeMil);
            System.TimeSpan split = new System.TimeSpan(0, 0, SplitMin, SplitSec, SplitMil);
            System.TimeSpan NewSplit = current - split;

            SplitMin = CurrentTimeMin;
            SplitSec = CurrentTimeSec;
            SplitMil = CurrentTimeMil;
            SplitField.IsVisible = true;
            SplitField.Text = NewSplit.ToString(@"mm\:ss\:ff");

            
        }

        private void IndividualSplitRun(object sender, EventArgs e)
        {
            Models.Run run = new Models.Run();
            run.RunnerNumber = Int32.Parse(Runner1.Text);
            run.Splits.Add(TimeLabel.Text);
            run.TotalTime = "1:00";

        }

        private void StartRun(object sender, EventArgs e)
        {
            NewRunPopup.IsVisible = false;

            startBtnSignal = "Stop";
            NewRunBtn.Image = "round_pause_white_48.png";
            NewRunBtn.SetBinding(Button.CommandProperty, "StopRunCommand");

            //display individual runner split buttons
            if (NumberOfRunners.SelectedItem.Equals("2"))
            {
                Runner1.IsVisible = false;
                Runner2.IsVisible = false;
                Runner3.IsVisible = true;
                Runner3.Text = "2";
                Runner4.IsVisible = false;
                Runner5.IsVisible = true;
                Runner5.Text = "1";
                Runner6.IsVisible = false;
            }
            else if (NumberOfRunners.SelectedItem.Equals("3"))
            {
                Runner1.IsVisible = true;
                Runner1.Text = "1";
                Runner2.IsVisible = false;
                Runner3.IsVisible = true;
                Runner3.Text = "3";
                Runner4.IsVisible = false;
                Runner5.IsVisible = true;
                Runner5.Text = "2";
                Runner6.IsVisible = false;
            }
            else if (NumberOfRunners.SelectedItem.Equals("4"))
            {
                Runner1.IsVisible = false;
                Runner2.IsVisible = true;
                Runner2.Text = "2";
                Runner3.IsVisible = true;
                Runner3.Text = "3";
                Runner4.IsVisible = false;
                Runner5.IsVisible = true;
                Runner5.Text = "4";
                Runner6.IsVisible = true;
                Runner6.Text = "1";
            }
            else if (NumberOfRunners.SelectedItem.Equals("5"))
            {
                Runner1.IsVisible = true;
                Runner1.Text = "2";
                Runner2.IsVisible = true;
                Runner2.Text = "3";
                Runner3.IsVisible = true;
                Runner3.Text = "4";
                Runner4.IsVisible = false;
                Runner5.IsVisible = true;
                Runner5.Text = "5";
                Runner6.IsVisible = true;
                Runner6.Text = "1";
            }
            else if (NumberOfRunners.SelectedItem.Equals("6"))
            {
                Runner1.IsVisible = true;
                Runner1.Text = "1";
                Runner2.IsVisible = true;
                Runner2.Text = "2";
                Runner3.IsVisible = true;
                Runner3.Text = "3";
                Runner4.IsVisible = true;
                Runner4.Text = "4";
                Runner5.IsVisible = true;
                Runner5.Text = "5";
                Runner6.IsVisible = true;
                Runner6.Text = "6";
            }
            else {
                Runner1.IsVisible = false;
                Runner2.IsVisible = false;
                Runner3.IsVisible = false;
                Runner4.IsVisible = false;
                Runner5.IsVisible = false;
                Runner6.IsVisible = false;
            }

            ResetRunBtn.IsVisible = true;
            ResetRunBtn.SetBinding(Button.CommandProperty, "ResetRunCommand");

            SplitRunBtn.IsVisible = true;
        }

    }
}