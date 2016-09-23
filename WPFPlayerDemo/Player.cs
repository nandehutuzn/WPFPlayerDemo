using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Un4seen.Bass;

namespace WPFPlayerDemo
{
    /// <summary>
    /// 音乐播放类
    /// </summary>
    class Player
    {
        public readonly log4net.ILog _log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// 单例模式实例
        /// </summary>
        private static Player instance = null;

        /// <summary>
        /// 错误信息
        /// </summary>
        public Error error
        {
            get { return Error.getError(Bass.BASS_ErrorGetCode()); }
        }

        /// <summary>
        /// 互斥锁对象
        /// </summary>
        private static readonly object syncObject = new object();

        /// <summary>
        /// 单例模式私有化构造函数
        /// </summary>
        /// <param name="windowHandle"></param>
        private Player(IntPtr windowHandle)
        {
            if (BassNetRegistration.eMail != null && BassNetRegistration.registrationKey != null)
                BassNet.Registration(BassNetRegistration.eMail, BassNetRegistration.registrationKey);
            if (!Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, windowHandle))
            {
                Error error = this.error;
                System.Windows.MessageBox.Show(error.ToString(), error.title, System.Windows.MessageBoxButton.OK, 
                    System.Windows.MessageBoxImage.Error, System.Windows.MessageBoxResult.OK, System.Windows.MessageBoxOptions.ServiceNotification);
            }

            //默认音量
            volume = 100;
        }

        public static Player getInstance(IntPtr windowHandle)
        {
            //外出判断
            if (instance == null)
            {
                lock (syncObject)//互斥锁
                {
                    if (instance == null) //内层再判断一次
                    {
                        instance = new Player(windowHandle);
                    }
                }
            }
            return instance;
        }

        /// <summary>
        /// 析构函数
        /// </summary>
        ~Player()
        {
            //停止并释放音乐
            stop();
            //停止所有
            Bass.BASS_Stop();
            //释放Bass库
            Bass.BASS_Free();
        }

        /// <summary>
        /// 文件流
        /// </summary>
        private int stream = 0;

        /// <summary>
        /// 音量值记录
        /// </summary>
        private int _volumn = 100;

        /// <summary>
        /// 静音状态
        /// </summary>
        private bool _mute = false;

        /// <summary>
        /// 音量
        /// </summary>
        public int volume
        {
            get {
                float value = 100;
                if (Bass.BASS_ChannelGetAttribute(stream, BASSAttribute.BASS_ATTRIB_VOL, ref value))
                {
                    if (!_mute)
                        _volumn = (int)(Math.Round(value * 100));
                    return _volumn;
                }
                else
                    return 100;
            }
            set {
                //记录音量
                _volumn = value;
                //设置音量
                if (stream != 0)
                    Bass.BASS_ChannelSetAttribute(stream, BASSAttribute.BASS_ATTRIB_VOL, _mute ? 0 : (value / 100f));
            }
        }

        /// <summary>
        /// 停止播放
        /// </summary>
        public void stop()
        {
            if (stream != 0)
            {
                Bass.BASS_ChannelStop(stream);
                Bass.BASS_StreamFree(stream);
            }
            stream = 0;
        }
    }
}
