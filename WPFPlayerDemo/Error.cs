﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Un4seen.Bass;

namespace WPFPlayerDemo
{
    class Error
    {
        public int code;
        public string title;
        public string content;

        private Error() { }

        public override string ToString()
        {
            return string.Format("code: {0}     content: {1} ", code.ToString(), content);
        }

        public static Error getError(BASSError e)
        {
            Error error = new Error();
            switch (e)
            {
                case BASSError.BASS_ERROR_ACM_CANCEL:
                    error.code = 2000;
                    error.title = "BassEnc: ACM codec selection cancelled";
                    error.content = "ACM 编解码器选项已被取消!";
                    break;
                case BASSError.BASS_ERROR_ALREADY:
                    error.code = 14;
                    error.title = "Already initialized/paused/whatever";
                    error.content = "操作已完成!";
                    break;
                case BASSError.BASS_ERROR_BUFLOST:
                    error.code = 4;
                    error.title = "The sample buffer was lost";
                    error.content = "样本缓冲丢失！";
                    break;
                case BASSError.BASS_ERROR_BUSY:
                    error.code = 46;
                    error.title = "The device is busy (eg. in \"exclusive\" use by another process)";
                    error.content = "设备正在使用中！";
                    break;
                case BASSError.BASS_ERROR_CAST_DENIED:
                    error.code = 2100;
                    error.title = "BassEnc: Access denied (invalid password)";
                    error.content ="无效的密码，没有权限!";
                    break;
                case BASSError.BASS_ERROR_CDTRACK:
                    error.code =13;
                    error.title = "Invalid track number";
                    error.content = "无效的CD轨道!";
                    break;
                case BASSError.BASS_ERROR_CODEC:
                    error.code=44;
                    error.title = "Codec is not available/supported";
                    error.content = "编码器/解码器不可用!";
                    break;
                case BASSError.BASS_ERROR_CREATE:
                    error.code = 33;
                    error.title = "Couldn't create the file";
                    error.content = "创建文件失败";
                    break;
                case BASSError.BASS_ERROR_DECODE:
                    error.code = 38;
                    error.title="The channel is a 'decoding channel'";
                    error.content = "该频道为解码频道!";
                    break;
                case BASSError.BASS_ERROR_DEVICE:
                    error.code=23;
                    error.title = "Illegal device number";
                    error.content = "非法的设备编号!";
                    break;
                case BASSError.BASS_ERROR_DRIVER:
                    error.code = 3;
                    error.title = "Can't find a free/valid driver";
                    error.content = "找不到可用的设备!";
                    break;
                case BASSError.BASS_ERROR_DX:
                    error.code = 39;
                    error.title = "A sufficient DirectX version is not installed";
                    error.content = "DirectX版本太低！";
                    break;
                case BASSError.BASS_ERROR_EMPTY:
                    error.code = 31;
                    error.title = "The MOD music has no sequence data";
                    error.content = "此MOD音乐序列数据为空！";
                    break;
                case BASSError.BASS_ERROR_ENDED:
                    error.code = 45;
                    error.title = "The channel/file has ended";
                    error.content = "该频道已被终止!";
                    break;
                case BASSError.BASS_ERROR_FILEFORM:
                    error.code = 41;
                    error.title = "Unsupported file format";
                    error.content = "文件格式不支持！";
                    break;
                case BASSError.BASS_ERROR_FILEOPEN:
                    error.code = 2;
                    error.title = "Can't open the file";
                    error.content = "无法打开文件!";
                    break;
                case BASSError.BASS_ERROR_FORMAT:
                    error.code =6;
                    error.title ="Unsupported sample format";
                    error.content ="样本格式不支持！";
                    break;
                case BASSError.BASS_ERROR_FREQ:
                    error.code =25;
                    error.title = "Illegal sample rate";
                    error.content = "样本速度非法!";
                    break;
                case BASSError.BASS_ERROR_HANDLE:
                    error.code=5;
                    error.title = "Invalid handle";
                    error.content = "无效的句柄!";
                    break;
                case BASSError.BASS_ERROR_ILLPARAM:
                    error.code=20;
                    error.title = "An illegal parameter was specified";
                    error.content = "非法的参数!";
                    break;
                case BASSError.BASS_ERROR_ILLTYPE:
                    error.code = 19;
                    error.title ="An illegal type was specified";
                    error.content = "非法的类型!";
                    break;
                case BASSError.BASS_ERROR_INIT:
                    error.code = 8;
                    error.title="BASS_Init has not been successfully called";
                    error.content = "初始化失败!";
                    break;
                case BASSError.BASS_ERROR_MEM:
                    error.code = 1;
                    error.title = "Memory error";
                    error.content ="内存错误!";
                    break;
                case BASSError.BASS_ERROR_MP4_NOSTREAM:
                    error.code = 6000;
                    error.title = "BASS_AAC: non-streamable due to MP4 atom order ('mdat' before 'moov')";
                    error.content = "非流化由于MP4原子订单（前“MOOV'MDAT'）";
                    break;
                case BASSError.BASS_ERROR_NO3D:
                    error.code = 21;
                    error.title = "No 3D support";
                    error.content = "不支持3D音效!";
                    break;
                case BASSError.BASS_ERROR_NOCD:
                    error.code = 12;
                    error.title = "No CD in drive";
                    error.content = "请将CD插入驱动器!";
                    break;
                case BASSError.BASS_ERROR_NOCHAN:
                    error.code = 18;
                    error.title = "Can't get a free channel";
                    error.content = "找不到空闲频道!";
                    break;
                case BASSError.BASS_ERROR_NOEAX:
                    error.code = 22;
                    error.title = "No EAX support";
                    error.content ="不支持EAX音效!";
                    break;
                case BASSError.BASS_ERROR_NOFX:
                    error.code =34;
                    error.title = "Effects are not available";
                    error.content = "不支持音效插件!";
                    break;
                case BASSError.BASS_ERROR_NOHW:
                    error.code = 29;
                    error.title = "No hardware voices available";
                    error.content = "硬件音量不支持!";
                    break;
                case BASSError.BASS_ERROR_NONET:
                    error.code = 32;
                    error.title = "No internet connection could be opened";
                    error.content = "无法连接到网络!";
                    break;
                case BASSError.BASS_ERROR_NOPAUSE:
                    error.code = 16;
                    error.title = "Not paused";
                    error.content = "不在暂停状态!";
                    break;
                case BASSError.BASS_ERROR_NOPLAY:
                    error.code = 24;
                    error.title = "Not playing";
                    error.content ="不在播放状态!";
                    break;
                case BASSError.BASS_ERROR_NOTAUDIO:
                    error.code = 17;
                    error.title = "Not an audio track";
                    error.content ="并非音频轨道!";
                    break;
                case BASSError.BASS_ERROR_NOTAVAIL:
                    error.code = 37;
                    error.title = "Requested data is not available";
                    error.content = "请求的数据不可用!";
                    break;
                case BASSError.BASS_ERROR_NOTFILE:
                    error.code = 27;
                    error.title= "The stream is not a file stream";
                    error.content ="并非文件流!";
                    break;
                case BASSError.BASS_ERROR_PLAYING:
                    error.code = 35;
                    error.title = "The channel is playing";
                    error.content = "该频道正在播放！";
                    break;
                case BASSError.BASS_ERROR_POSITION:
                    error.code = 7;
                    error.title = "Invalid playback position";
                    error.content = "错误的播放位置！";
                    break;
                case BASSError.BASS_ERROR_SPEAKER:
                    error.code = 42;
                    error.title = "Unavailable speaker";
                    error.content = "扬声器不可用!";
                    break;
                case BASSError.BASS_ERROR_START:
                    error.code =9;
                    error.title ="BASS_Start has not been successfully called";
                    error.content ="播放失败!";
                    break;
                case BASSError.BASS_ERROR_TIMEOUT:
                    error.code = 40;
                    error.title = "Connection timedout";
                    error.content = "连接超时!";
                    break;
                case BASSError.BASS_ERROR_UNKNOWN:
                    error.code = -1;
                    error.title = "Some other mystery error";
                    error.content = "其他谜之问题!";
                    break;
                case BASSError.BASS_ERROR_VERSION:
                    error.code = 43;
                    error.title = "Invalid BASS version (used by add-ons)";
                    error.content = "BASS版本不正确!";
                    break;
                case BASSError.BASS_ERROR_WASAPI:
                    error.code = 5000;
                    error.title = "BASSWASAPI: no WASAPI available";
                    error.content = "不支持WASAPI！";
                    break;
                case BASSError.BASS_ERROR_WMA_CODEC:
                    error.code=1003;
                    error.title ="BassWma: no appropriate codec is installed";
                    error.content ="没有可用的WMA解码器!";
                    break;
                case BASSError.BASS_ERROR_WMA_DENIED:
                    error.code=1002;
                    error.title = "BassWma: access denied (user/pass is invalid)";
                    error.content = "WMA许可无效!";
                    break;
                case BASSError.BASS_ERROR_WMA_INDIVIDUAL:
                    error.code = 1004;
                    error.title ="BassWma: individualization is needed";
                    error.content ="需要个性化！";
                    break;
                case BASSError.BASS_ERROR_WMA_LICENSE:
                    error.code=1000;
                    error.title ="BassWma: the file is protected";
                    error.content = "WMA文件受到保护!";
                    break;
                case BASSError.BASS_ERROR_WMA_WM9:
                    error.code = 1001;
                    error.title = "BassWma: WM9 is required";
                    error.content = "需要升级Windows Media Player 9或以上版本！";
                    break;
                case BASSError.BASS_VST_ERROR_NOINPUTS:
                    error.code=3000;
                    error.title = "BassVst: the given effect has no inputs and is probably a VST instrument and no effect";
                    error.content ="给定的音效没有输入，可能是一个VST乐器！";
                    break;
                case BASSError.BASS_VST_ERROR_NOOUTPUTS:
                    error.code=3001;
                    error.title ="BassVst: the given effect has no outputs";
                    error.content ="给定的音效没有输出!";
                    break;
                case BASSError.BASS_VST_ERROR_NOREALTIME:
                    error.code = 3002;
                    error.title = "BassVst: the given effect does not support realtime processing";
                    error.content ="给定的音效不支持实时处理！";
                    break;
                case BASSError.BASS_OK:
                default:
                    error.code = 0;
                    error.title = "All is OK";
                    error.content = "一切正常!";
                    break;
            }
            return error;
        }
    }
}
