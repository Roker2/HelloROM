﻿using System;
using Xamarin.Forms;
using Android.Media;
using Android.Content.Res;

[assembly: Dependency(typeof(HelloROM.Droid.AudioService))]

namespace HelloROM.Droid
{
    public class AudioService : IAudio
    {
        public void PlayAudioFile(string fileName)
        {
            var player = new MediaPlayer();
            var fd = global::Android.App.Application.Context.Assets.OpenFd(fileName);
            player.Prepared += (s, e) =>
            {
                player.Start();
            };
            player.SetDataSource(fd.FileDescriptor, fd.StartOffset, fd.Length);
            player.Prepare();
        }
    }
}