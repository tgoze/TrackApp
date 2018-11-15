using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TrackApp.ViewModels
{
    public class RunViewModel : INotifyPropertyChanged
    {
        // Properties for stopwatch
        TimeSpan Interval = TimeSpan.FromMilliseconds(1);
        int SplitTimeIntervalSec;
        CancellationTokenSource cts;
        Stopwatch StopWatch = new Stopwatch();
        bool WaitToBeep = false;       

        // Properties for UI 
        public event PropertyChangedEventHandler PropertyChanged;

        public string GoalTimeInput { get; set; }
        public int RunDistanceInput { get; set; }
        public int SplitDistanceInput { get; set; }

        public Command AudioCommand { get; }
        public Command StartRunCommand { get; }
        public Command StopRunCommand { get; }
        public Command ResetRunCommand { get; }
        public Command ContinueRunCommand { get; }

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

        public string _CurrentTime = "0:00:00";
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
        public string SplitTime 
        {
            set
            {
                SplitTime = CurrentTime;
            }
            get
            {
                return SplitTime;
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

        private void PlayBeep()
        {
            DependencyService.Get<IAudio>().PlayAudioFile("beep.mp3");
        }

        private void ResetRun()
        {
            CurrentTime = "00:00:00";
            CurrentProgress = 0;
            MaxTime = 0;            
            SplitDistanceInput = 0;
            GoalTimeInput = "";
            RunDistanceInput = 0;

            StopWatch.Stop();
            StopWatch.Reset();
            cts.Cancel();
        }         

        private void StartRun()
        {
            // Parse the input to seconds
            StopWatch.Reset();
            string[] TimeInputs = GoalTimeInput.Split(':');
            int.TryParse(TimeInputs[0], out int goalTimeMin);
            int.TryParse(TimeInputs[1], out int goalTimeSec);
            int goalTimeSeconds = (goalTimeMin * 60) + goalTimeSec;
            
            // Start the stopwatch with beeper                    
            NumOfSplits = RunDistanceInput / SplitDistanceInput;
            MaxTime = goalTimeSeconds;
            SplitTimeIntervalSec = goalTimeSeconds / NumOfSplits;
            cts = new CancellationTokenSource();
            StartStopwatch(Interval, SplitTimeIntervalSec, cts.Token);
        }

        private void StopRun()
        {                        
            if (StopWatch.IsRunning)
                StopWatch.Stop();           
        }

        private void ContinueRun()
        {
            if (!StopWatch.IsRunning)
                StopWatch.Start();
        }

        private void StartStopwatch(TimeSpan repeatInterval, int splitTimeInterval, CancellationToken cancellationToken)        
        {            
            var task = WatchStopwatchAsync(repeatInterval, splitTimeInterval, cancellationToken);
            StopWatch.Start();
        }

        private async Task WatchStopwatchAsync(TimeSpan interval, int splitTimeInterval, CancellationToken cancellationToken)
        {
            while (true)
            {
                CurrentProgress = StopWatch.Elapsed.Seconds;
                CurrentTime = StopWatch.Elapsed.ToString(@"mm\:ss\:ff");
                
                if (StopWatch.Elapsed.Seconds % splitTimeInterval == 0 && StopWatch.Elapsed.Seconds != 0)
                {
                    if (!WaitToBeep)
                    {
                        PlayBeep();
                        WaitToBeep = true;
                    }
                }
                else
                {
                    WaitToBeep = false;
                }
                
                await Task.Delay(interval, cancellationToken);                
            }
        }         
    }
}
