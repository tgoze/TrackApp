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
        public int _MaxTime = 0;
        public int MaxTime
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
        }

        public Command AudioCommand { get; }
        public Command StartRunCommand { get; }
        public Command StopRunCommand { get; }
        public Command ResetRunCommand { get; }

        private void ResetRun()
        {
            CurrentTime = "0:00:00";
            CurrentProgress = 0;
            MaxTime = 0;
            SplitCount = 0;
            SplitDistanceInput = 0;
            GoalTimeInput = "";
            RunDistanceInput = 0;
            TotalCount = 0;
           // _CurrentTime = 0;
            
            

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
            string[] TimeInputs = GoalTimeInput.Split(':');

            int NumOfSplits = MaxDistance / SplitDistance;

            int GoalTimeSec = 0;
            int SplitTimeInterval = (GoalTime * 60 + GoalTimeSec) / NumOfSplits * 100;

            MaxTime = SplitTimeInterval;

            Device.StartTimer(TimeSpan.FromMilliseconds(TIMER_INTERVAL_MILLISECONDS), () =>
            {
                SplitCount++;
                TotalCount++;

                CurrentProgress = TimeSpan.FromMilliseconds(TotalCount).Milliseconds;
                CurrentTime = TimeSpan.FromMilliseconds(TotalCount).Minutes
                    + ":" + TimeSpan.FromMilliseconds(TotalCount).Seconds
                    + "." + TimeSpan.FromMilliseconds(TotalCount).Milliseconds; 

                if (TotalCount % SplitTimeInterval == 0)
                    DependencyService.Get<IAudio>().PlayAudioFile("button.mp3");

                return ContinueTimer;
            });            
        }

      
    }
}
