using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Syncfusion.XForms.ProgressBar;

using TrackApp.ViewModels;
using static Xamarin.Forms.Device;
using System.Collections.Generic;

namespace TrackApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Run : ContentPage
	{
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
            TimeLabel.FontSize += 28;
            progressBar.Minimum = 0;
            SplitField.FontSize += 12;                        
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
                SoundSettings.IsEnabled = true;
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
                SoundSettings.IsEnabled = false;
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

        private void OpenPicker(object sender, EventArgs e)
        {
            SoundPicker.IsEnabled = true;
            SoundPicker.Focus();
        }

        private void HidePopup(object sender, EventArgs e)
        {
            NewRunPopup.IsVisible = false;
        }        

        private void ResetRun(object sender, EventArgs e)
        {
            NewRunBtn.SetBinding(Button.CommandProperty, "FalseFunction");
            SoundSettings.IsEnabled = true;
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
            SplitField.IsVisible = false;

            Runner1.IsVisible = false;
            Runner2.IsVisible = false;
            Runner3.IsVisible = false;
            Runner4.IsVisible = false;
            Runner5.IsVisible = false;
            Runner6.IsVisible = false;            
        }

        private void StartRun(object sender, EventArgs e)
        {
            SoundSettings.IsEnabled = false;

            NewRunPopup.IsVisible = false;
            SplitField.IsVisible = true;

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