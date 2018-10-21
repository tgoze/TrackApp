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
        private const double TIMER_INTERVAL = 0.001;

        private bool continueTimer = false;

        private long totalCount = 0;
        private long splitCount = 0;

        public Run()
		{
            InitializeComponent();
            BindingContext = new RunViewModel();
		}

        protected void StartBeeper()
        {
            int.TryParse(TargetTimeMinEntry.Text, out int targetTimeMin);
            //int.TryParse(TargetTimeSecEntry.Text, out int targetTimeSec);
            int.TryParse(TotalDistanceEntry.Text, out int maxDistance);
            int.TryParse(SplitDistanceEntry.Text, out int splitDistance);

            int numOfSplits = maxDistance / splitDistance;

            int targetTimeSec = 0;
            int splitTimeInterval = (targetTimeMin * 60 + targetTimeSec) / numOfSplits * 1000;

            Device.StartTimer(TimeSpan.FromSeconds(TIMER_INTERVAL), () =>
            {
                splitCount++;
                totalCount++;

                //SplitLbl.Text = "Current split: " + (splitCount % 360000).ToString("N0") + ":" + ((splitCount % 600) / 10).ToString("N3");
                //TotalLbl.Text = "Total time: " + (totalCount % 360000).ToString("N0") + ":" + ((totalCount % 600) / 10).ToString("N3");

                SplitLbl.Text = "Current split: " + TimeSpan.FromMilliseconds(splitCount).Minutes + ":" + TimeSpan.FromMilliseconds(splitCount).Seconds;
                TotalLbl.Text = "Total time: " + totalCount;

                if (totalCount % splitTimeInterval == 0)
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
            }
            else
            {
                splitCount = 0;
            }
        }

        private void StopBtn_Clicked(object sender, EventArgs e)
        {
            StartBtn.Text = "Start";
            continueTimer = false;


            if (StopBtn.Text.Equals("Reset"))
            {
                TargetTimeMinEntry.Text = "";
                //TargetTimeSecEntry.Text = "";
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
    }
}