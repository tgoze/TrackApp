using System;

using Xamarin.Forms; 
using Xamarin.Forms.Xaml;

using Syncfusion.XForms.ProgressBar;

using TrackApp.ViewModels;

namespace TrackApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Run : ContentPage
	{
        int SplitMin = 0;
        int SplitSec = 0;
        int SplitMil = 0;
        string startBtnSignal = "Start";
        bool GoalText = false;
        bool RunText = false;
        bool SplitText = false;
        RunViewModel runview = new RunViewModel();

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

        private void OnTextChanged (object sender, ProgressValueEventArgs e)
        {






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

            

            runview.StartRunCommand.Execute(null);
            NewRunPopup.IsVisible = false;

            startBtnSignal = "Stop";
            NewRunBtn.Image = "round_pause_white_48.png";
            NewRunBtn.SetBinding(Button.CommandProperty, "StopRunCommand");

            

            ResetRunBtn.IsVisible = true;
            ResetRunBtn.SetBinding(Button.CommandProperty, "ResetRunCommand");

            SplitRunBtn.IsVisible = true;
        }

        private void GoalTimeInput_ValueChanged(object sender, Syncfusion.XForms.MaskedEdit.ValueChangedEventArgs eventArgs)
        {
            if (GoalText && RunText && SplitText)
            {
                StartNewRunBtn.IsVisible = true;
            }

            if( GoalTimeInput.Value != null)
            {
                GoalText = true;
            }
        }

        private void RunDistanceInput_ValueChanged(object sender, Syncfusion.SfNumericTextBox.XForms.ValueEventArgs e)
        {

            int test = (int)SplitDistanceInput.Value;
            if (GoalText && RunText && SplitText)
            {
                StartNewRunBtn.IsVisible = true;
            }


            if (RunDistanceInput.Value != null)
            {
                if ((int)SplitDistanceInput.Value >0)
                {
                    if ((int)RunDistanceInput.Value > (int)SplitDistanceInput.Value)
                    {
                        RunText = true;
                    }
                } else
                {
                    RunText = true;
                }
            }
        }

        private void SplitDistanceInput_ValueChanged(object sender, Syncfusion.SfNumericTextBox.XForms.ValueEventArgs e)
        {

            if (GoalText && RunText && SplitText)
            {
                StartNewRunBtn.IsVisible = true;
            }

            if (SplitDistanceInput.Value != null)
            {
                if(RunDistanceInput.Value != null)
                {
                    if ((int) SplitDistanceInput.Value < (int) RunDistanceInput.Value)
                    {
                        SplitText = true;
                    }
                } else
                {
                    SplitText = true;
                }
            }



        }
    }
}