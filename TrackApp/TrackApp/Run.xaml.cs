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
        private const double TIME_INTERVAL = 0.01;

        private bool continueTimer = false;

        private double totalCount = 0;
        private double splitCount = 0;

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

            Device.StartTimer(TimeSpan.FromSeconds(TIME_INTERVAL), () =>
            {
                splitCount++;
                totalCount++; 

                SplitLbl.Text = "Current split: " + (splitCount % 360000).ToString("N0") + ":" + ((splitCount % 6000) / 100).ToString("N3");
                TotalLbl.Text = "Total time: " + (totalCount % 360000).ToString("N0") + ":" + ((totalCount % 6000) / 100).ToString("N3");

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