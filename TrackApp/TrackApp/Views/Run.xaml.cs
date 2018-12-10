using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Syncfusion.XForms.ProgressBar;

using TrackApp.ViewModels;
using static Xamarin.Forms.Device;
using System.Collections.Generic;
using TrackApp.Models;
using System.Collections;

namespace TrackApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Run : ContentPage
	{
        TimeSpan SplitTime;
        string startBtnSignal = "Start";

        List<Models.Run> runs = new List<Models.Run>();
        //public int RunnerNumber { get; internal set; }
        //internal List<TimeSpan> Splits { get; set; }


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
                NewRunBtn.SetBinding(Button.CommandProperty, "ContinueRunCommand");
                if (RuntimePlatform == Device.Android)
                {
                    NewRunBtn.Image = "round_play_arrow_white_48.png";
                } else if (RuntimePlatform == Device.iOS)
                {
                    NewRunBtn.Image = "round_play_arrow_white_48pt";
                }
            } else if ("Continue".Equals(startBtnSignal))
            {
                startBtnSignal = "Stop";
                NewRunBtn.SetBinding(Button.CommandProperty, "StopRunCommand");
                if (RuntimePlatform == Device.Android)
                {
                    NewRunBtn.Image = "round_pause_white_48.png";
                }
                else if (RuntimePlatform == Device.iOS)
                {
                    NewRunBtn.Image = "round_pause_white_48pt";
                }
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
            if (RuntimePlatform == Device.Android)
            {
                NewRunBtn.Image = "round_play_arrow_white_48.png";
            }
            else if (RuntimePlatform == Device.iOS)
            {
                NewRunBtn.Image = "round_play_arrow_white_48pt";
            }

            ResetRunBtn.IsVisible = false;

            SplitRunBtn.IsVisible = false;

            SplitTime = TimeSpan.FromSeconds(0);
            SplitField.IsVisible = false;

            Runner1.IsVisible = false;
            Runner2.IsVisible = false;
            Runner3.IsVisible = false;
            Runner4.IsVisible = false;
            Runner5.IsVisible = false;
            Runner6.IsVisible = false;
        }

        // Prints the current split time
        private void SplitRun(object sender, EventArgs e)
        {
            TimeSpan NewSplit = SplitRun(SplitTime);
            
            SplitField.IsVisible = true;
            SplitField.Text = NewSplit.ToString(@"mm\:ss\:ff");
        }

        // Stores the split time in an object
        private void IndividualSplitRun(object sender, EventArgs e)
        {
            var button = sender as Button;
            runs[int.Parse(button.Text) - 1].RunnerNumber = int.Parse(button.Text);
            runs[int.Parse(button.Text) - 1].Splits.Add(SplitRun(SplitTime).ToString(@"mm\:ss\:ff"));
            runs[int.Parse(button.Text) - 1].TotalTime = TimeLabel.Text;
        }

        private TimeSpan SplitRun(TimeSpan splitTime)
        {
            string[] CurrentTimeInputs = TimeLabel.Text.Split(':');

            int.TryParse(CurrentTimeInputs[0], out int CurrentTimeMin);
            int.TryParse(CurrentTimeInputs[1], out int CurrentTimeSec);
            int.TryParse(CurrentTimeInputs[2], out int CurrentTimeMil);

            System.TimeSpan current = new System.TimeSpan(0, 0, CurrentTimeMin, CurrentTimeSec, CurrentTimeMil);
            System.TimeSpan NewSplit = current - splitTime;

            // Update the global variable
            SplitTime = current;

            return NewSplit;
        }

        private void StartRun(object sender, EventArgs e)
        {
            NewRunPopup.IsVisible = false;

            startBtnSignal = "Stop";
            if (RuntimePlatform == Device.Android)
            {
                NewRunBtn.Image = "round_pause_white_48.png";
            }
            else if (RuntimePlatform == Device.iOS)
            {
                NewRunBtn.Image = "round_pause_white_48pt";
            }
            NewRunBtn.SetBinding(Button.CommandProperty, "StopRunCommand");

            int CurrentNumberOfRunners = Int32.Parse(NumberOfRunners.Value.ToString());

            for (int i = 1; i <= CurrentNumberOfRunners; i++)
            {
                runs.Add(new Models.Run());
            }

            //display individual runner split buttons
            if (NumberOfRunners.Value.ToString().Equals("2"))
            {
                Runner1.IsVisible = true;
                Runner1.Text = "1";
                Runner2.IsVisible = true;
                Runner2.Text = "2";
                Runner3.IsVisible = false;
                Runner4.IsVisible = false;
                Runner5.IsVisible = false;
                Runner6.IsVisible = false;
            }
            else if (NumberOfRunners.Value.ToString().Equals("3"))
            {
                Runner1.IsVisible = true;
                Runner1.Text = "1";
                Runner2.IsVisible = true;
                Runner2.Text = "2";
                Runner3.IsVisible = true;
                Runner3.Text = "3";
                Runner4.IsVisible = false;
                Runner5.IsVisible = false;
                Runner6.IsVisible = false;
            }
            else if (NumberOfRunners.Value.ToString().Equals("4"))
            {
                Runner1.IsVisible = true;
                Runner1.Text = "1";
                Runner2.IsVisible = true;
                Runner2.Text = "2";
                Runner3.IsVisible = true;
                Runner3.Text = "3";
                Runner4.IsVisible = true;
                Runner4.Text = "4";
                Runner5.IsVisible = false;
                Runner6.IsVisible = false;
            }
            else if (NumberOfRunners.Value.ToString().Equals("5"))
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
                Runner6.IsVisible = false;
            }
            else if (NumberOfRunners.Value.ToString().Equals("6"))
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