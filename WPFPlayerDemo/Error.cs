using System;
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

        public static Error getError(BASSError e)
        {
            Error error = new Error();
            switch (e)
            {
                case BASSError.BASS_ERROR_ACM_CANCEL:
                    break;
                case BASSError.BASS_ERROR_ALREADY:
                    break;
                case BASSError.BASS_ERROR_BUFLOST:
                    break;
                case BASSError.BASS_ERROR_BUSY:
                    break;
                case BASSError.BASS_ERROR_CAST_DENIED:
                    break;
                case BASSError.BASS_ERROR_CDTRACK:
                    break;
                case BASSError.BASS_ERROR_CODEC:
                    break;
                case BASSError.BASS_ERROR_CREATE:
                    break;
                case BASSError.BASS_ERROR_DECODE:
                    break;
                case BASSError.BASS_ERROR_DEVICE:
                    break;
                case BASSError.BASS_ERROR_DRIVER:
                    break;
                case BASSError.BASS_ERROR_DX:
                    break;
                case BASSError.BASS_ERROR_EMPTY:
                    break;
                case BASSError.BASS_ERROR_ENDED:
                    break;
                case BASSError.BASS_ERROR_FILEFORM:
                    break;
                case BASSError.BASS_ERROR_FILEOPEN:
                    break;
                case BASSError.BASS_ERROR_FORMAT:
                    break;
                case BASSError.BASS_ERROR_FREQ:
                    break;
                case BASSError.BASS_ERROR_HANDLE:
                    break;
                case BASSError.BASS_ERROR_ILLPARAM:
                    break;
                case BASSError.BASS_ERROR_ILLTYPE:
                    break;
                case BASSError.BASS_ERROR_INIT:
                    break;
                case BASSError.BASS_ERROR_MEM:
                    break;
                case BASSError.BASS_ERROR_MP4_NOSTREAM:
                    break;
                case BASSError.BASS_ERROR_NO3D:
                    break;
                case BASSError.BASS_ERROR_NOCD:
                    break;
                case BASSError.BASS_ERROR_NOCHAN:
                    break;
                case BASSError.BASS_ERROR_NOEAX:
                    break;
                case BASSError.BASS_ERROR_NOFX:
                    break;
                case BASSError.BASS_ERROR_NOHW:
                    break;
                case BASSError.BASS_ERROR_NONET:
                    break;
                case BASSError.BASS_ERROR_NOPAUSE:
                    break;
                case BASSError.BASS_ERROR_NOPLAY:
                    break;
                case BASSError.BASS_ERROR_NOTAUDIO:
                    break;
                case BASSError.BASS_ERROR_NOTAVAIL:
                    break;
                case BASSError.BASS_ERROR_NOTFILE:
                    break;
                case BASSError.BASS_ERROR_PLAYING:
                    break;
                case BASSError.BASS_ERROR_POSITION:
                    break;
                case BASSError.BASS_ERROR_SPEAKER:
                    break;
                case BASSError.BASS_ERROR_START:
                    break;
                case BASSError.BASS_ERROR_TIMEOUT:
                    break;
                case BASSError.BASS_ERROR_UNKNOWN:
                    break;
                case BASSError.BASS_ERROR_VERSION:
                    break;
                case BASSError.BASS_ERROR_WASAPI:
                    break;
                case BASSError.BASS_ERROR_WMA_CODEC:
                    break;
                case BASSError.BASS_ERROR_WMA_DENIED:
                    break;
                case BASSError.BASS_ERROR_WMA_INDIVIDUAL:
                    break;
                case BASSError.BASS_ERROR_WMA_LICENSE:
                    break;
                case BASSError.BASS_ERROR_WMA_WM9:
                    break;
                case BASSError.BASS_VST_ERROR_NOINPUTS:
                    break;
                case BASSError.BASS_VST_ERROR_NOOUTPUTS:
                    break;
                case BASSError.BASS_VST_ERROR_NOREALTIME:
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
