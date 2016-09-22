using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Un4seen.Bass;

namespace WPFPlayerDemo
{
    /// <summary>
    /// 音乐播放类
    /// </summary>
    class Player
    {
        /// <summary>
        /// 单例模式实例
        /// </summary>
        private static Player instance = null;

        /// <summary>
        /// 互斥锁对象
        /// </summary>
        private static readonly object syncObject = new object();

        private Player(IntPtr windowHandle)
        {
            if (BassNetRegistration.eMail != null && BassNetRegistration.registrationKey != null)
                BassNet.Registration(BassNetRegistration.eMail, BassNetRegistration.registrationKey);
            if (!Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, windowHandle))
                ;
        }
    }
}
