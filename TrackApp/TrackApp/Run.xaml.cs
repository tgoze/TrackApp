using System;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrackApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Run : ContentPage
    {
        private bool continueTimer = false;

        private int totalCount = 0;
        private int splitCount = 0;

        public Run()
        {
            InitializeComponent();
        }

        protected void StartBeeper()
        {
            int.TryParse(TargetTimeMinEntry.Text, out int targetTimeMin);
            int.TryParse(TargetTimeSecEntry.Text, out int targetTimeSec);
            int.TryParse(TotalDistanceEntry.Text, out int maxDistance);
            int.TryParse(SplitDistanceEntry.Text, out int splitDistance);

            int numOfSplits = maxDistance / splitDistance;

            int timeInterval = (targetTimeMin * 60 + targetTimeSec) / numOfSplits;

            Regex timeFormat = new Regex(@"(\d\d)(\d\d)");

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                splitCount++;
                totalCount++; 

                SplitLbl.Text = "Current split: " + ((splitCount / 60)).ToString("D2") + ":" + (splitCount % 60).ToString("D2");
                TotalLbl.Text = "Total time: " + ((totalCount / 60)).ToString("D2") + ":" + (totalCount % 60).ToString("D2");

                if (totalCount % timeInterval == 0)
                    DependencyService.Get<IAudio>().PlayAudioFile("button.mp3");

                return continueTimer;
            });
        }

        private void StartBtn_Clicked(object sender, EventArgs e)
        {
            if (StartBtn.Text.Equals("Start"))
            {
                StartBtn.Text = "Split";
                StopBtn.IsEnabled = true;
                StartBeeper();
                continueTimer = true;
                StopBtn.Text = "Stop";
            } else
            {
                splitCount = 0;
            }
        }

        private void StopBtn_Clicked(object sender, EventArgs e)
        {
            StartBtn.Text = "Start";
            continueTimer = false;
            
            
            if (StopBtn.Text.Equals("Reset")) {
                TargetTimeMinEntry.Text = "";
                TargetTimeSecEntry.Text = "";
                TotalDistanceEntry.Text = "";
                SplitDistanceEntry.Text = "";

                splitCount = 0;
                totalCount = 0;

                StopBtn.Text = "Stop";
                SplitLbl.Text = "Current split: " + ((splitCount / 60)).ToString("D2") + ":" + (splitCount % 60).ToString("D2");
                TotalLbl.Text = "Total time: " + ((totalCount / 60)).ToString("D2") + ":" + (totalCount % 60).ToString("D2");


            }
            StopBtn.Text = "Reset";
        }

        private void BeepButton_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IAudio>().PlayAudioFile("button.mp3");
        }
    }
}