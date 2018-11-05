using System;
using System.ComponentModel;
using System.Diagnostics;
using Xamarin.Forms;

namespace TrackApp.ViewModels
{
    public class RunViewModel : INotifyPropertyChanged
    {
        private const double TIMER_INTERVAL_MILLISECONDS = 0.1;

        private bool ContinueTimer = false;        

        Stopwatch StopWatch = new Stopwatch();

        public event PropertyChangedEventHandler PropertyChanged;

        public string GoalTimeInput { get; set; }
        public int RunDistanceInput { get; set; }
        public int SplitDistanceInput { get; set; }

        public double _MaxTime = 0;
        public double MaxTime
        {
            set
            {
                _MaxTime = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MaxTime"));
            }
            get
            {
                return _MaxTime;
            }
        }        

        public int _NumOfSplits = 0;
        public int NumOfSplits
        {
            set
            {
                _NumOfSplits = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NumOfSplits"));
            }
            get
            {
                return _NumOfSplits;
            }
        }

        int SplitTimeInterval;

        public double _CurrentProgress = 0;
        public double CurrentProgress
        {
            set
            {
                _CurrentProgress = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CurrentProgress"));
            }

            get
            {
                return _CurrentProgress;
            }
        }

        public string _CurrentTime = "0:00.00";
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
            StopRunCommand = new Command(StopRun);
            ResetRunCommand = new Command(ResetRun);
            ContinueRunCommand = new Command(ContinueRun);
        }

        public Command AudioCommand { get; }
        public Command StartRunCommand { get; }
        public Command StopRunCommand { get; }
        public Command ResetRunCommand { get; }
        public Command ContinueRunCommand { get; }

        private void PlayBeep()
        {
            DependencyService.Get<IAudio>().PlayAudioFile("button.mp3");
        }

        private void ResetRun()
        {
            StopWatch.Stop();
            StopWatch.Reset();
            CurrentTime = "00:00.00";
            CurrentProgress = 0;
            MaxTime = 0;            
            SplitDistanceInput = 0;
            GoalTimeInput = "";
            RunDistanceInput = 0;            
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
            if (StopWatch.IsRunning)
                StopWatch.Stop();                   
        }

        protected void StartBeeper(int GoalTime, int MaxDistance, int SplitDistance)
        {
            //int.TryParse(TargetTimeMinEntry.Text, out int GoalTime);
            //int.TryParse(TargetTimeSecEntry.Text, out int targetTimeSec);
            //int.TryParse(TotalDistanceEntry.Text, out int MaxDistance);
            //int.TryParse(SplitDistanceEntry.Text, out int SplitDistance);

            int NumOfSplits = MaxDistance / SplitDistance;

            int GoalTimeSec = 0;
            int SplitTimeInterval = (GoalTime * 60 + GoalTimeSec) / NumOfSplits * 100;

            Device.StartTimer(TimeSpan.FromMilliseconds(TIMER_INTERVAL_MILLISECONDS), () =>
            {
                SplitCount++;
                TotalCount++;                

                //SplitLbl.Text = "Current split: " + (splitCount % 360000).ToString("N0") + ":" + ((splitCount % 600) / 10).ToString("N3");
                //TotalLbl.Text = "Total time: " + (totalCount % 360000).ToString("N0") + ":" + ((totalCount % 600) / 10).ToString("N3");

                //SplitLbl.Text = "Current split: " + TimeSpan.FromMilliseconds(splitCount).Minutes + ":" + TimeSpan.FromMilliseconds(splitCount).Seconds;
                CurrentTime = TimeSpan.FromMilliseconds(TotalCount).Minutes
                    + ":" + TimeSpan.FromMilliseconds(TotalCount).Seconds
                    + " " + TimeSpan.FromMilliseconds(TotalCount).Milliseconds; 

                if (TotalCount % SplitTimeInterval == 0)
                    DependencyService.Get<IAudio>().PlayAudioFile("button.mp3");

                return ContinueTimer;
            });            
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
