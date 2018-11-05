using System;
using System.ComponentModel;
using System.Diagnostics;
using Xamarin.Forms;

namespace TrackApp.ViewModels
{
    public class RunViewModel : INotifyPropertyChanged
    {
        private const double TIMER_INTERVAL_MILLISECONDS = 1;

        private bool ContinueTimer = false;

        private long TotalCount = 0;
        private long SplitCount = 0;

        Stopwatch StopWatch = new Stopwatch();

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
            ContinueRunCommand = new Command(ContinueRun);
        }

        public Command AudioCommand { get; }
        public Command StartRunCommand { get; }
        public Command StopRunCommand { get; }
        public Command ResetRunCommand { get; }
        public Command ContinueRunCommand { get; }

        private void ResetRun()
        {
            StopWatch.Stop();
            StopWatch.Reset();
            CurrentTime = "00:00.00";
            CurrentProgress = 0;
            MaxTime = 0;
            SplitCount = 0;
            SplitDistanceInput = 0;
            GoalTimeInput = "";
            RunDistanceInput = 0;
            TotalCount = 0;
        }

        private void PlayBeep()
        {
            DependencyService.Get<IAudio>().PlayAudioFile("button.mp3");
        }

        

        private void StartRun()
        {                    
            // Parse the input to seconds
            string[] TimeInputs = GoalTimeInput.Split(':');
            int.TryParse(TimeInputs[0], out int goalTimeMin);
            int.TryParse(TimeInputs[1], out int goalTimeSec);
            int goalTimeSeconds = (goalTimeMin * 60) + goalTimeSec;
            // Start the stopwatch with beeper
            StartBeeper(goalTimeSeconds, RunDistanceInput, SplitDistanceInput);                        
        }

        private void StopRun()
        {            
            ContinueTimer = false;
            StopWatch.Stop();            
        }
        private void ContinueRun()
        {
            ContinueTimer = true;
        }

        protected void StartBeeper(int goalTime, int maxDistance, int splitDistance)
        {
            int numOfSplits = maxDistance / splitDistance;            
            int splitTimeInterval = goalTime / numOfSplits;

            ContinueTimer = true;
            StopWatch.Start();

            // Had to use this variable because checking StopWatch.Elapsed was acting strange
            bool wait = false;

            Device.StartTimer(TimeSpan.FromMilliseconds(TIMER_INTERVAL_MILLISECONDS), () =>
            {                            
                CurrentTime = StopWatch.Elapsed.ToString(@"mm\:ss\.ff");
                
                if (StopWatch.Elapsed.Seconds % splitTimeInterval == 0 && StopWatch.Elapsed.Seconds != 0)
                {                    
                    if (!wait)
                    {
                        PlayBeep();
                        wait = true;
                    }                    
                } else
                {
                    wait = false;
                }                    

                CurrentProgress = TimeSpan.FromMilliseconds(TotalCount).Milliseconds;
                return ContinueTimer;
            });
        }        
    }
}
