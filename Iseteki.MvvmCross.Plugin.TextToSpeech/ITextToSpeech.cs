using System;

namespace Iseteki.MvvmCross.Plugin.TextToSpeech
{
    public interface ITextToSpeech
    {
        /// <summary>
        /// Text To Speech が初期化されているかどうか
        /// </summary>
        bool Initialized { get; }

        /// <summary>
        /// 読み上げのロケール
        /// </summary>
        SpeechLocale Locale { get; set; }

        /// <summary>
        /// Text To Speech を初期化する
        /// </summary>
        void Initialize();

        /// <summary>
        /// Text To Speech を解放する
        /// </summary>
        void Release();

        /// <summary>
        /// Text To Speech が初期化されたら呼び出される
        /// </summary>
        event EventHandler InitializeCompleted;

        /// <summary>
        /// 読み上げを実行する
        /// </summary>
        /// <param name="text">Text.</param>
        void Speech(string text);
    }

    /// <summary>
    /// 読み上げロケールのリスト
    /// </summary>
    public enum SpeechLocale
    {
        English,
        Japanease
    }
}

