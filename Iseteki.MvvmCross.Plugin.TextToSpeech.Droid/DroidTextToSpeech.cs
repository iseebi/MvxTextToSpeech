using System;
using Cirrious.CrossCore.Droid;

namespace Iseteki.MvvmCross.Plugin.TextToSpeech.Droid
{
    public class DroidTextToSpeech : Java.Lang.Object, ITextToSpeech, Android.Speech.Tts.TextToSpeech.IOnInitListener
    {
        Android.Speech.Tts.TextToSpeech _tts;
        IMvxAndroidGlobals _globals;

        public DroidTextToSpeech(IMvxAndroidGlobals globals)
        {
            _globals = globals;
        }

        #region ITextToSpeech implementation

        public event EventHandler InitializeCompleted;

        public void Initialize()
        {
            if (_tts == null)
            {
                _tts = new Android.Speech.Tts.TextToSpeech(_globals.ApplicationContext, this);
            }
        }

        public void Release()
        {
            if (_tts != null)
            {
                _tts.Shutdown();
                _tts.Dispose();
                _tts = null;
                Initialized = false;
            }
        }

        public void Speech(string text)
        {
            if (Initialized == false)
            {
                throw new InvalidOperationException();
            }
            Java.Util.Locale locale = Java.Util.Locale.English;
            if (Locale == SpeechLocale.Japanease)
            {
                locale = Java.Util.Locale.Japanese;
            }
            switch (_tts.IsLanguageAvailable(locale))
            {
                case Android.Speech.Tts.LanguageAvailableResult.MissingData:
                case Android.Speech.Tts.LanguageAvailableResult.NotSupported:
                    throw new NotSupportedException();
                default:
                    _tts.SetLanguage(locale);
                    break;
            }
            _tts.Speak(text, Android.Speech.Tts.QueueMode.Flush, null);
        }

        public bool Initialized { get; private set; }

        public SpeechLocale Locale { get; set; }

        #endregion

        #region IOnInitListener implementation

        public void OnInit(Android.Speech.Tts.OperationResult status)
        {
            if (status == Android.Speech.Tts.OperationResult.Success)
            {
                Initialized = true;
                if (InitializeCompleted != null)
                {
                    InitializeCompleted(this, EventArgs.Empty);
                }
            }
        }

        #endregion
    }
}

