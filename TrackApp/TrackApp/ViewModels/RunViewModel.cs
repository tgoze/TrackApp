using System;
using System.Collections.Generic;
using System.ComponentModel;
using TrackApp.Helper;
using Xamarin.Forms;

namespace TrackApp.ViewModels
{
    public class RunViewModel : INotifyPropertyChanged
    {
        // Properties for stopwatch        
        public int SplitTimeIntervalSec { get; set; }
        private int NumOfSplits;
        private StopwatchService SwService;

        // Properties for calculating splits
        private Dictionary<int, TimeSpan> LastSplitTimes = new Dictionary<int, TimeSpan>();
        private Dictionary<int, Models.Run> Runs = new Dictionary<int, Models.Run>();

        // Properties for UI 
        public event PropertyChangedEventHandler PropertyChanged;

        public string GoalTimeInput { get; set; }
        public int RunDistanceInput { get; set; }
        public int SplitDistanceInput { get; set; }        

        public Command StartRunCommand { get; private set; }
        public Command StopRunCommand { get; }
        public Command ResetRunCommand { get; }
        public Command ContinueRunCommand { get; }
        public Command SplitRunnerCommand { get; private set; }
        public Command SplitAllRunnersCommand { get; private set; }

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

        public string _SplitTime = "0:00.00";
        public string SplitTime 
        {
            set
            {
                _SplitTime = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SplitTime"));
            }
            get
            {
                return _SplitTime;
            }
        }

        public RunViewModel()
        {            
            StartRunCommand = new Command<object>(StartRun);
            StopRunCommand = new Command(StopRun);
            ResetRunCommand = new Command(ResetRun);
            ContinueRunCommand = new Command(ContinueRun);
            SplitRunnerCommand = new Command<string>(SplitRunner);
            SplitAllRunnersCommand = new Command<object>(SplitAllRunners);
        }                    

        private void StartRun(object numberOfRunners)
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

            // Declare all the run objects based on the number of runners
            int numRunners = int.Parse(numberOfRunners.ToString());                    
            for (int i = 1; i <= numRunners; i++)
            {
                Models.Run run = new Models.Run(i);
                Runs.Add(i, run);
                LastSplitTimes.Add(i, new TimeSpan());
            }                       
        }

        private void ResetRun()
        {
            SwService.Reset();
            Runs.Clear();
            LastSplitTimes.Clear();
        }

        private void StopRun()
        {            
            SwService.Stop();  
        }

        private void ContinueRun()
        { 
            SwService.Continue();
        }

        private void SplitAllRunners(object numberOfRunners)
        {            
            int numRunners = int.Parse(numberOfRunners.ToString());
            for (int i = 1; i <= numRunners; i++)
            {
                TimeSpan split = SplitRun(LastSplitTimes[i], i);
                Runs[i].Splits.Add(split.ToString(@"mm\:ss\.ff"));
            }
        }

        private void SplitRunner(string pRunnerID)
        {
            // Split time for this runner
            int.TryParse(pRunnerID, out int runnerID);
            TimeSpan split = SplitRun(LastSplitTimes[runnerID], runnerID);
            Runs[runnerID].Splits.Add(split.ToString(@"mm\:ss\.ff"));            
        }

        private TimeSpan SplitRun(TimeSpan lastSplitTime, int runnerID)
        {
            TimeSpan currentTime = SwService.StopWatch.Elapsed;
            TimeSpan newSplit = currentTime - lastSplitTime;

            // Update the global variable
            LastSplitTimes[runnerID] = currentTime;

            SplitTime = newSplit.ToString(@"mm\:ss\.ff");
            return newSplit;
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
    }
}
