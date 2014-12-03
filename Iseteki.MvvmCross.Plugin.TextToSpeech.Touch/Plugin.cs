using System;
using Cirrious.CrossCore.Plugins;
using Cirrious.CrossCore;

namespace Iseteki.MvvmCross.Plugin.TextToSpeech.Touch
{
    public class Plugin
        : IMvxPlugin          
    {
        public void Load()
        {
            // ここにIoCコンテナへの登録処理を記述する
            Mvx.RegisterType<ITextToSpeech, TouchTextToSpeech>(); // 追加
        }
    }
}

