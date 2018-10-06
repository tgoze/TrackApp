using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;

namespace TrackApp.ViewModels
{
    public class RunViewModel
    {
        public RunViewModel()
        {
            AudioCommand = new Command(PlayBeep);
        }

        public Command AudioCommand { get; }

        private void PlayBeep()
        {
            DependencyService.Get<IAudio>().PlayAudioFile("button.mp3");
        }
    }
}
