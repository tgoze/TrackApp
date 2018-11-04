using System.ComponentModel;
using System.Timers;
using Xamarin.Forms;

namespace TrackApp.ViewModels
{
    public class RunViewModel : INotifyPropertyChanged
    {
        private const double TIMER_INTERVAL_MILLISECONDS = 0.1;

        private bool ContinueTimer = false;

        private long TotalCount = 0;
        private long SplitCount = 0;

        public event PropertyChangedEventHandler PropertyChanged;

        public string GoalTimeInput { get; set; }
        public int RunDistanceInput { get; set; }
        public int SplitDistanceInput { get; set; }

        public string _CurrentTime = "0:00 00";
        public string CurrentTime
        {
            set
            {
                _CurrentTime = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CurrentTime"));
            }
            get
            {
                return _CurrentTime;
            }
        }

        public RunViewModel()
        {
            AudioCommand = new Command(PlayBeep);
            StartRunCommand = new Command(StartRun);
        }

        public Command AudioCommand { get; }
        public Command StartRunCommand { get; }
        public Command StopRunCommand { get; }

        private void PlayBeep()
        {
            DependencyService.Get<IAudio>().PlayAudioFile("button.mp3");
        }

        private void StartRun()
        {
            string[] TimeInputs = GoalTimeInput.Split(':');
            int.TryParse(TimeInputs[0], out int GoalTime);
            StartBeeper(GoalTime, RunDistanceInput, SplitDistanceInput);
            ContinueTimer = true;
        }

        private void StopRun()
        {
            ContinueTimer = false;
        }

        protected void StartBeeper(int GoalTime, int MaxDistance, int SplitDistance)
        //{
        //    //int.TryParse(TargetTimeMinEntry.Text, out int GoalTime);
        //    //int.TryParse(TargetTimeSecEntry.Text, out int targetTimeSec);
        //    //int.TryParse(TotalDistanceEntry.Text, out int MaxDistance);
        //    //int.TryParse(SplitDistanceEntry.Text, out int SplitDistance);

        //    int NumOfSplits = MaxDistance / SplitDistance;

        //    int GoalTimeSec = 0;
        //    int SplitTimeInterval = (GoalTime * 60 + GoalTimeSec) / NumOfSplits * 100;

        //    Task t = Task.Factory.StartNew(() =>
        //    {
        //        Device.StartTimer(TimeSpan.FromMilliseconds(TIMER_INTERVAL_MILLISECONDS), () =>
        //        {
        //            SplitCount++;
        //            TotalCount++;

        //            //SplitLbl.Text = "Current split: " + (splitCount % 360000).ToString("N0") + ":" + ((splitCount % 600) / 10).ToString("N3");
        //            //TotalLbl.Text = "Total time: " + (totalCount % 360000).ToString("N0") + ":" + ((totalCount % 600) / 10).ToString("N3");

        //            //SplitLbl.Text = "Current split: " + TimeSpan.FromMilliseconds(splitCount).Minutes + ":" + TimeSpan.FromMilliseconds(splitCount).Seconds;
        //            //CurrentTime = TimeSpan.FromMilliseconds(TotalCount).Minutes
        //            //+ ":" + TimeSpan.FromMilliseconds(TotalCount).Seconds
        //            //+ " " + TimeSpan.FromMilliseconds(TotalCount).Milliseconds;

        //            CurrentTime = TimeSpan.FromMilliseconds(TotalCount).Seconds.ToString();

        //            if (TotalCount % SplitTimeInterval == 0)
        //                DependencyService.Get<IAudio>().PlayAudioFile("button.mp3");

        //            return ContinueTimer;
        //        });
        //    });
        //}
        {
            Timer timer = new Timer
            {
                Interval = 1
            };
            timer.Start();
            timer.Elapsed += Timer_Elapsed;

            int NumOfSplits = MaxDistance / SplitDistance;

            int GoalTimeSec = 0;
            int SplitTimeInterval = (GoalTime * 60 + GoalTimeSec) / NumOfSplits * 100;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            TotalCount++;
            if (TotalCount % 1000 == 0)
                DependencyService.Get<IAudio>().PlayAudioFile("button.mp3");
        }

        //    private void StartBtn_Clicked(object sender, EventArgs e)
        //    {
        //        if (StartBtn.Text.Equals("Start"))
        //        {
        //            StartBtn.Text = "Split";
        //            StopBtn.IsEnabled = true;
        //            StartBeeper();
        //            continueTimer = true;
        //            StopBtn.Text = "Stop";
        //        }
        //        else
        //        {
        //            splitCount = 0;
        //        }
        //    }

        //    private void StopBtn_Clicked(object sender, EventArgs e)
        //    {
        //        StartBtn.Text = "Start";
        //        continueTimer = false;


        //        if (StopBtn.Text.Equals("Reset"))
        //        {
        //            TargetTimeMinEntry.Text = "";
        //            //TargetTimeSecEntry.Text = "";
        //            TotalDistanceEntry.Text = "";
        //            SplitDistanceEntry.Text = "";

        //            splitCount = 0;
        //            totalCount = 0;

        //            StopBtn.Text = "Stop";
        //            SplitLbl.Text = "Current split: " + ((splitCount / 60)).ToString("D2") + ":" + (splitCount % 60).ToString("D2");
        //            TotalLbl.Text = "Total time: " + ((totalCount / 60)).ToString("D2") + ":" + (totalCount % 60).ToString("D2");
        //        }
        //        StopBtn.Text = "Reset";
        //    }
    }
}
