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
            // Parse the input to seconds
            string[] TimeInputs = GoalTimeInput.Split(':');
            int.TryParse(TimeInputs[0], out int goalTimeMin);
            int.TryParse(TimeInputs[1], out int goalTimeSec);
            int goalTimeSeconds = (goalTimeMin * 60) + goalTimeSec;

            // Start the stopwatch with beeper                    
            NumOfSplits = RunDistanceInput / SplitDistanceInput;
            MaxTime = goalTimeSeconds;
            SplitTimeInterval = goalTimeSeconds / NumOfSplits;
            StartDeviceStopwatch(TIMER_INTERVAL_MILLISECONDS, SplitTimeInterval);
        }

        private void StopRun()
        {
            ContinueTimer = false;
            if (StopWatch.IsRunning)
                StopWatch.Stop();
        }

        private void ContinueRun()
        {
            if (!StopWatch.IsRunning)
                StartDeviceStopwatch(TIMER_INTERVAL_MILLISECONDS, SplitTimeInterval);
        }

        protected void StartDeviceStopwatch(double repeatInterval, int splitTimeInterval)
        {
            // Had to use this variable because Stopwatch and Device.StartTimer don't interact well
            bool wait = false;

            ContinueTimer = true;
            StopWatch.Start();

            Device.StartTimer(TimeSpan.FromMilliseconds(repeatInterval), () =>
            {
                CurrentProgress = StopWatch.Elapsed.Seconds;
                CurrentTime = StopWatch.Elapsed.ToString(@"mm\:ss\.ff");

                if (MaxTime <= StopWatch.Elapsed.Seconds)
                {
                    StopRun();
                    return ContinueTimer;
                }
                else
                {

                    if (StopWatch.Elapsed.Seconds % splitTimeInterval == 0 && StopWatch.Elapsed.Seconds != 0)
                    {
                        if (!wait)
                        {
                            PlayBeep();
                            wait = true;
                        }
                    }
                    else
                    {
                        wait = false;
                    }
                    return ContinueTimer;
                }
            });
        }
    }
}