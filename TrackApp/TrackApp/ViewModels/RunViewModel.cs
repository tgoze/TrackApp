using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace TrackApp.ViewModels
{
    public class RunViewModel : INotifyPropertyChanged
    {
        private const double TIMER_INTERVAL_MILLISECONDS = 1;

        private bool ContinueTimer = false;

        private long TotalCount = 0;
        private long SplitCount = 0;

        public event PropertyChangedEventHandler PropertyChanged;

        public string GoalTimeInput { get; set; }
        public int RunDistanceInput { get; set; }
        public int SplitDistanceInput { get; set; }

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
        }

        public Command AudioCommand { get; }
        public Command StartRunCommand { get; }
        public Command StopRunCommand { get; }
        public Command ResetRunCommand { get; }

        private void ResetRun()
        {
            CurrentTime = "0:00.00";
            //GoalTimeInput = "";
            

    }

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
        {
            

            int NumOfSplits = MaxDistance / SplitDistance;

            int GoalTimeSec = 0;
            int SplitTimeInterval = (GoalTime * 60 + GoalTimeSec) / NumOfSplits * 100;

            Device.StartTimer(TimeSpan.FromMilliseconds(TIMER_INTERVAL_MILLISECONDS), () =>
            {
                SplitCount++;
                TotalCount++;                

                
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
