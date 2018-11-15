using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TrackApp.Helper
{
    public class StopwatchService
    {           
        private readonly TimeSpan Interval;
        private int SplitTimeIntervalSec;
        private CancellationTokenSource cts;
        private bool WaitToBeep;
        public Stopwatch StopWatch { get; }                                        

        public StopwatchService(int splitTimeIntervalSec)
        {
            StopWatch = new Stopwatch();           
            Interval = TimeSpan.FromMilliseconds(1);
            WaitToBeep = false;
            cts = new CancellationTokenSource();            
            SplitTimeIntervalSec = splitTimeIntervalSec;
        }        

        public void Start()
        {            
            var task = WatchStopwatchAsync(Interval, SplitTimeIntervalSec, cts.Token);
            StopWatch.Start();
        }

        public void Stop()
        {
            if (StopWatch.IsRunning)
                StopWatch.Stop();
        }

        public void Continue()
        {
            if (!StopWatch.IsRunning)
                StopWatch.Start();
        }

        public void Reset()
        {
            StopWatch.Reset();
            cts.Cancel();
        }
       
        public override string ToString()
        {
            return StopWatch.Elapsed.ToString(@"mm\:ss\:ff");
        }

        private void PlayBeep()
        {
            DependencyService.Get<IAudio>().PlayAudioFile("beep.mp3");
        }

        private async Task WatchStopwatchAsync(TimeSpan interval, int splitTimeInterval, CancellationToken cancellationToken)
        {
            while (true)
            {                                              
                if (StopWatch.Elapsed.TotalSeconds % splitTimeInterval == 0 
                    && StopWatch.Elapsed.TotalSeconds != 0)
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
