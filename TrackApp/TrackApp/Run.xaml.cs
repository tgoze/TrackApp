using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrackApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Run : ContentPage
    {
        private bool continueTimer = false;

        private int totalCount = 0;
        private int splitCount = 0;

        public Run()
        {
            InitializeComponent();
        }

        protected void StartBeeper(int timeInterval)
        {
            Device.StartTimer(TimeSpan.FromSeconds(timeInterval), () =>
            {
                SplitLbl.Text = (splitCount += timeInterval).ToString();
                TotalLbl.Text = (totalCount += timeInterval).ToString();

                DependencyService.Get<IAudio>().PlayAudioFile("button.mp3");

                return continueTimer;
            });
        }

        private void StartBtn_Clicked(object sender, EventArgs e)
        {
            if (StartBtn.Text.Equals("Start"))
            {
                StartBtn.Text = "Split";
                StopBtn.IsEnabled = true;
                StartBeeper(2);
                continueTimer = true;
            } else
            {
                splitCount = 0;
            }
        }

        private void StopBtn_Clicked(object sender, EventArgs e)
        {
            continueTimer = false;
        }

        private void BeepButton_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IAudio>().PlayAudioFile("button.mp3");
        }
    }
}