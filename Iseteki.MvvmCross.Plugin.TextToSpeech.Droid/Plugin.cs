using System;
using Cirrious.CrossCore.Plugins;
using Cirrious.CrossCore;

namespace Iseteki.MvvmCross.Plugin.TextToSpeech.Droid
{
    public class Plugin
        : IMvxPlugin
    {
        public void Load()
        {
            Mvx.RegisterType<ITextToSpeech, DroidTextToSpeech>();
        }
    }
}

