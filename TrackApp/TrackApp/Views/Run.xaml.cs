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
            
            if ("Stop".Equals(NewRunBtn.Text))
            {
                NewRunBtn.Text = "Continue";
                NewRunBtn.SetBinding(Button.CommandProperty, "ContinueRunCommand");
                ResetRunBtn.Text = "Reset";
                ResetRunBtn.SetBinding(Button.CommandProperty, "ResetRunCommand");
                //ResetRunBtn.RemoveBinding(Button.CommandProperty);

                // ResetRunBtn.IsVisible = true;

            } else if ("Continue".Equals(NewRunBtn.Text))
            {
                NewRunBtn.Text = "Stop";
                ResetRunBtn.Text = "Split";
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

            if (ResetRunBtn.Text.Equals("Reset"))
            {
                NewRunBtn.Text = "Start";
                ResetRunBtn.Text = "Split";
                ResetRunBtn.SetBinding(Button.CommandProperty, "Throwaway");
                ResetRunBtn.IsEnabled = false;
                SplitMin = 0;
                SplitSec = 0;
                SplitMil = 0;
                SplitField.IsVisible = false;
            } else if (ResetRunBtn.Text.Equals("Split"))
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
        }

        private void StartRun(object sender, EventArgs e)
        {
            NewRunPopup.IsVisible = false;
            NewRunBtn.Text = "Stop";
            GoalTimeInput.Value = "";
            RunDistanceInput.Value = "";
            SplitDistanceInput.Value = "";
            ResetRunBtn.RemoveBinding(Button.CommandProperty);
        }
    }
}