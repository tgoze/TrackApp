using System;
using System.ComponentModel;
using System.Windows.Input;
using TrackApp.Helper;
using TrackApp.Helper.Validations;
using TrackApp.Models.obj;
using Xamarin.Forms;

namespace TrackApp.ViewModels
{
    public class RunViewModel : BaseViewModel , INotifyPropertyChanged
    {
             
        public int SplitTimeIntervalSec { get; set; }
        private int NumOfSplits;
        private StopwatchService SwService;       

        
        public event PropertyChangedEventHandler PropertyChanged;

        public ValidatableObject<string> GoalTimeInput { get; set; }
        public int RunDistanceInput { get; set; }
       





        public int SplitDistanceInput { get; set; }
        public string NumberOfRunners { get; set; }

        public ICommand StartRunCommand { get; set; }
        public ICommand StartNutRunCmd { get; }
        public Command StopRunCommand { get; }
        public Command ResetRunCommand { get; }
        public Command ContinueRunCommand { get; }       

        Action propChangedCallBack => (StartRunCommand as Command).ChangeCanExecute;

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
            StartRunCommand = new Command( () => StartRun(NumberOfRunners), () => GoalTimeInput.IsValid);
            GoalTimeInput = new ValidatableObject<string>(propChangedCallBack, new TimeValidator());

            //StartRunCommand = new Command<object>(StartRun);
            StopRunCommand = new Command(StopRun);
            ResetRunCommand = new Command(ResetRun);
            ContinueRunCommand = new Command(ContinueRun);
        }

        private void StartRun(object numberOfRunners)
        {       
            string[] TimeInputs = GoalTimeInput.Value.Split(':');
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
            SwService.Stop();
            SwService.Reset();
            CurrentProgress = 0.0;
            CurrentTime = "00:00";
            
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

        
    }
}
