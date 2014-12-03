using System;
using MonoTouch.AVFoundation;

namespace Iseteki.MvvmCross.Plugin.TextToSpeech.Touch
{
    public class TouchTextToSpeech : ITextToSpeech
    {
        private AVSpeechSynthesizer _speechSynthesizer;

        public TouchTextToSpeech()
        {
        }

        #region ITextToSpeech implementation

        public event EventHandler InitializeCompleted;

        public void Initialize()
        {
            if (_speechSynthesizer == null)
            {
                _speechSynthesizer = new AVSpeechSynthesizer();
                if (InitializeCompleted != null)
                {
                    InitializeCompleted(this, EventArgs.Empty);
                }
            }
        }

        public void Release()
        {
            if (_speechSynthesizer != null)
            {
                _speechSynthesizer.Dispose();
                _speechSynthesizer = null;
            }
        }

        public void Speech(string text)
        {
            if (_speechSynthesizer == null)
            {
                throw new InvalidOperationException();
            }

            var utterance = new AVSpeechUtterance(text);
            switch (Locale)
            {
                case SpeechLocale.Japanease:
                    utterance.Voice = AVSpeechSynthesisVoice.FromLanguage("ja-JP");
                    break;
                default:
                    utterance.Voice = AVSpeechSynthesisVoice.FromLanguage("en-US");
                    break;
            }

            _speechSynthesizer.SpeakUtterance(utterance);
        }

        public bool Initialized
        {
            get { return _speechSynthesizer != null; }
        }

        public SpeechLocale Locale
        {
            get;
            set;
        }

        #endregion
    }
}

