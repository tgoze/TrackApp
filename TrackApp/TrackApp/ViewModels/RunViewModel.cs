using System;
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

        // Properties for UI 
        public event PropertyChangedEventHandler PropertyChanged;

        public string GoalTimeInput { get; set; }
        public int RunDistanceInput { get; set; }
        public int SplitDistanceInput { get; set; }
        public string NumberOfRunners { get; set; }
        public int SoundIndex { get; set;
        }

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
            ResetRunCommand = new Command(ResetRun);
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
            SwService.updateSound(SoundIndex);
            SwService.Start();
            UpdateTime(true);
        }

        private void ResetRun()
        {
            SwService.Reset();
            
        }

        private void StopRun()
        {            
            SwService.Stop();  
        }

        private void ContinueRun()
        { 
            if (SwService.SoundIndex != SoundIndex)
            {
                SwService.updateSound(SoundIndex);
            }
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
    }
}
