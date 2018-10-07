using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Media;

using Xamarin.Forms;

using TrackApp.Droid;

[assembly: Dependency(typeof(BeepService))]
namespace TrackApp.Droid
{
    public class BeepService : IBeep
    {
        private MediaPlayer mediaPlayer; 
        public bool playBeep()
        {
            mediaPlayer = MediaPlayer.Create(global::Android.App.Application.Context, Resource.Raw.beep);
            mediaPlayer.Start();
            return true;
        }
    }
}