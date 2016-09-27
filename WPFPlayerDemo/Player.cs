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

        /// <summary>
        /// 获取制定音乐文件的ID3信息
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns>音乐ID3信息</returns>
        public static MusicID3? getInformation(string filePath)
        {
            //打开文件
            int s = Bass.BASS_StreamCreateFile(filePath, 0L, 0L, BASSFlag.BASS_SAMPLE_FLOAT);
            if(0 == s)
                return null;
            //获取ID3信息
            MusicID3 i = new MusicID3();
            string[] info = Bass.BASS_ChannelGetTagsID3V2(s);
            if(info!=null)
            {
                foreach (string str in info)
                {
                    if (str.StartsWith("TTT2", true, null))
                        i.title = str.Remove(0, 5);
                    else if (str.StartsWith("TPE1", true, null))
                        i.artisti = str.Remove(0, 5);
                    else if (str.StartsWith("TALB", true, null))
                        i.album = str.Remove(0, 5);
                }
            }
            info = Bass.BASS_ChannelGetTagsID3V1(s);
            if (info != null)
            {
                i.title = info[0] != "" ? info[0] : i.title;
                i.artisti = info[1] != "" ? info[1] : i.artisti;
                i.album = info[2] != "" ? info[2] : i.album;
                i.year = info[3];
                i.comment = info[4];
                i.genre_id = info[5];
                i.track = info[6];
            }
            //获取时长信息
            double seconds = Bass.BASS_ChannelBytes2Seconds(s, Bass.BASS_ChannelGetLength(s));
            i.duration = Helper.Seconds2Time(seconds);
            //释放文件
            Bass.BASS_StreamFree(s);
            return i;
        }
    }
}
