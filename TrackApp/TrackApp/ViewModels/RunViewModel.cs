using System;
using System.ComponentModel;
using TrackApp.Helper;
using Xamarin.Forms;

namespace TrackApp.ViewModels
{
    public class RunViewModel : INotifyPropertyChanged
    {
<<<<<<< refs/remotes/origin/amarkovic
<<<<<<< refs/remotes/origin/amarkovic
        // Properties for stopwatch        
        public int SplitTimeIntervalSec { get; set; }
        private int NumOfSplits;
        private StopwatchService SwService;       
=======
        private const double TIMER_INTERVAL_MILLISECONDS = 0.1;
=======
        private const double TIMER_INTERVAL_MILLISECONDS = 1;
>>>>>>> Adjusted DAO to reflect changes in webservice

        private bool ContinueTimer = false;

        Stopwatch StopWatch = new Stopwatch();
>>>>>>> Trying to fix timer bug

        // Properties for UI 
        public event PropertyChangedEventHandler PropertyChanged;

        public string GoalTimeInput { get; set; }
        public int RunDistanceInput { get; set; }
        public int SplitDistanceInput { get; set; }
        public string NumberOfRunners { get; set; }

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
<<<<<<< refs/remotes/origin/amarkovic
        }                    
=======
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
>>>>>>> Adjusted DAO to reflect changes in webservice

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
            StartRunCommand = new Command(StartRun);
            StopRunCommand = new Command(StopRun);
           // ResetRunCommand = new Command(ResetRun);
            ContinueRunCommand = new Command(ContinueRun);
        }                    

        private void StartRun()
        {            
            string[] TimeInputs = GoalTimeInput.Split(':');
            int.TryParse(TimeInputs[0], out int goalTimeMin);
            int.TryParse(TimeInputs[1], out int goalTimeSec);
            int goalTimeSeconds = (goalTimeMin * 60) + goalTimeSec;
            
                             
            NumOfSplits = RunDistanceInput / SplitDistanceInput;                        
            SplitTimeIntervalSec = goalTimeSeconds / NumOfSplits;
            MaxTime = SplitTimeIntervalSec * 1000;       

            SwService = new StopwatchService(SplitTimeIntervalSec);            
            SwService.Start();
            UpdateTime(true);
        }

        private void ResetRun()
        {
            SwService.Reset();
            CurrentTime = "0:00:00";
            CurrentProgress = 0;
            MaxTime = 0;
            SplitDistanceInput = 0;
            GoalTimeInput = "";
            RunDistanceInput = 0;
<<<<<<< refs/remotes/origin/amarkovic
        }

        private void StopRun()
        {            
            SwService.Stop();  
        }

        private void ContinueRun()
        { 
            SwService.Continue();
        }

        private void UpdateTime(bool continueUpdating)
        {
            Device.StartTimer(TimeSpan.FromTicks(1), () => 
            {
                CurrentTime = SwService.ToString();  
                CurrentProgress = SwService.StopWatch.Elapsed.TotalMilliseconds % (SplitTimeIntervalSec * 1000);                
                
                return continueUpdating;
            });
        }            
=======
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
>>>>>>> Adjusted DAO to reflect changes in webservice
    }
}