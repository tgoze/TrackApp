﻿using System;
using Xamarin.Forms;

using Android.Media;
using Android.Content.Res;
using TrackApp.Droid;

[assembly: Dependency(typeof(AudioService))]
namespace TrackApp.Droid
{
    public class AudioService : IAudio
    {
        public AudioService()
        {
        }

        public void PlayAudioFile(string fileName)
        {            
            var player = new MediaPlayer();
            var fd = global::Android.App.Application.Context.Assets.OpenFd(fileName);

            // Events to start audio file and release it (needed for repeated plays)
            player.Prepared += (s, e) =>
            {
                player.Start();
            };        
            player.Completion += (s, e) =>
            {
                player.Release();
            };

            player.SetDataSource(fd.FileDescriptor, fd.StartOffset, fd.Length);
            player.Prepare();            
        }
    }
}