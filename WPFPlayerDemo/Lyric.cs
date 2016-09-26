using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows;
using System.Text.RegularExpressions;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net;
using WPFPlayerDemo.Template;
using zlib;

namespace WPFPlayerDemo
{
    /// <summary>
    /// 歌词类
    /// </summary>
    [Serializable]
    public class Lyric
    {
        /// <summary>
        /// 全部歌词
        /// </summary>
        private List<SingleLrc> text;

        /// <summary>
        /// 总时长
        /// </summary>
        private int time = 0;

        /// <summary>
        /// 时间偏移
        /// </summary>
        private int offset = 0;

        [NonSerialized]
        private FontFamily fontFamily = new FontFamily("Courier New");
        [NonSerialized]
        private FontStyle fontStyle = FontStyles.Normal;
        [NonSerialized]
        private FontWeight fontWeight = FontWeights.Bold;
        [NonSerialized]
        private FontStretch fontStretch = FontStretches.Normal;
        [NonSerialized]
        private double fontSize = 20;
        [NonSerialized]
        private Brush foreground = Brushes.Black;

        private string filePath = null;

        /// <summary>
        /// 歌词已经加载完毕
        /// </summary>
        private bool ready = false;

        /// <summary>
        /// 序列文件保存路径
        /// </summary>
        [NonSerialized]
        public string srcxPath = null;

        /// <summary>
        /// 歌词数据已被修改
        /// </summary>
        [NonSerialized]
        private bool lrcUpdated = false;

        /// <summary>
        /// 构造函数   - 直接解析歌词文本
        /// </summary>
        /// <param name="lrc">歌词数据文本</param>
        /// <param name="src">是否为src精准歌词</param>
        public Lyric(string lrc, bool src)
        {
            //计算时间偏移
            analyzeOffset(lrc);
            //解析歌词
            if (src) //src精准歌词文件
                analyzeSRC(lrc);
            else //lrc 普通歌词文件
                analyzeLRC(lrc);
        }

        /// <summary>
        /// 构造函数 - 加载歌词文件，通过扩展名判断src或lrc
        /// </summary>
        /// <param name="path">歌词文件路径</param>
        public Lyric(string path)
        {
            Regex ext = new Regex(@".+\.(.+)$", RegexOptions.Singleline | RegexOptions.CultureInvariant);
            MatchCollection mc = ext.Matches(path);
            string name = string.Empty;
            if (mc.Count > 0)
                name = mc[0].Groups[1].Value.Trim().ToLower();

            if (name != "src" && name != "lrc")
                throw new Exception("无效的歌词文件格式!");
            //打开文件
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            //读入文件
            byte[] data = new byte[fs.Length];
            fs.Read(data, 0, (int)fs.Length);
            //关闭文件
            fs.Flush();
            fs.Close();
            string lrc = Encoding.UTF8.GetString(data);
            //解析歌词
            analyzeOffset(lrc);
            if (name == "src")
                analyzeSRC(lrc);
            else if (name == "lrc")
                analyzeLRC(lrc);
            filePath = path;
        }

        /// <summary>
        /// 构造函数  - 自动搜索歌词 （来源：酷狗音乐）
        /// </summary>
        /// <param name="title">音乐标题</param>
        /// <param name="singer">艺术家</param>
        /// <param name="fileHash">文件MD5校验</param>
        /// <param name="time">音乐时长（毫秒）</param>
        /// <param name="savePath">是否保存为文本文件，保存路径</param>
        public Lyric(string title, string singer, string fileHash, int time, string savePath = null)
        {
            try
            {
                //查询地址
                string url = string.Format(
                    @"http://mobilecdn.kugou.com/new/app/i/krc.php?cmd=201&keyword=""{0}""-""{1}""&timelength={2}&hash={3}",
                    Helper.urlEncode(singer, "%20"),
                    Helper.urlEncode(title, "%20"),
                    "" + time, fileHash);
                string urlDownload = @"http://mobilecdn.kugou.com/new/app/i/krc.php?cmd=201&kid={0}";
                //下载歌词
                using (WebClient wc = new WebClient())
                {
                    //查询歌词
                    wc.Encoding = Encoding.UTF8;
                    wc.DownloadStringCompleted += new DownloadStringCompletedEventHandler(
                        (object sender, DownloadStringCompletedEventArgs e) =>
                        {
                            if (!e.Cancelled && e.Error == null)
                            {
                                //解析查询结果
                                krc list = Json.parse<krc>(e.Result);
                                if (list.@default == null || list.@default.Length == 0)
                                {
                                    ready = true;
                                    return;
                                }
                                //下载歌词
                                using (WebClient download = new WebClient())
                                {
                                    download.DownloadDataCompleted += new DownloadDataCompletedEventHandler(
                                        (s, ed) =>
                                        {
                                            if (!ed.Cancelled && ed.Error == null)
                                            {
                                                //歌词解密
                                                byte[] data = decodeKRC(ed.Result);
                                                if (data == null)
                                                    return;
                                                //保存歌词
                                                if (savePath != null)
                                                {
                                                    FileStream fs = new FileStream(savePath, FileMode.Create, FileAccess.Write, FileShare.None);
                                                    fs.Write(data, 0, data.Length);
                                                    fs.Flush();
                                                    fs.Close();
                                                    filePath = savePath;
                                                }
                                                string lrc = Encoding.UTF8.GetString(data);
                                                //解析歌词
                                                analyzeOffset(lrc);
                                                analyzeSRC(lrc);
                                            }
                                        });
                                    download.DownloadDataAsync(new Uri(string.Format(urlDownload, list.@default)));
                                }
                            }
                        });
                    //异步执行
                    wc.DownloadStringAsync(new Uri(url));
                }
            }
            catch (Exception ex)
            { 
            
            }
        }

        ~Lyric()
        {
            //保存序列文件
            if (lrcUpdated && srcxPath != null)
                saveSRCX(srcxPath, this);
        }

        /// <summary>
        /// 解析时间偏移
        /// </summary>
        /// <param name="lrc">歌词数据文本</param>
        private void analyzeOffset(string lrc)
        {
            Regex regOffset = new Regex(@"^\[offset:(-*\d+)\]", RegexOptions.Multiline | RegexOptions.CultureInvariant);
            MatchCollection mc = regOffset.Matches(lrc);
            if (mc.Count > 0)
                offset = int.Parse(mc[0].Groups[1].Value.Trim());
        }

        /// <summary>
        /// 解析LRC普通歌词
        /// </summary>
        /// <param name="lrc">歌词数据文本</param>
        private void analyzeLRC(string lrc)
        {
            //行匹配
            Regex regLine = new Regex(@"^((\[\d+:\d+\.\d+\])+)(.*?)$", RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.CultureInvariant);
            //时间匹配
            Regex regTime = new Regex(@"\[\d+:\d+.\d+\]", RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.CultureInvariant);
            //歌词表
            text = new List<SingleLrc>();
            foreach (Match line in regLine.Matches(lrc))
            {
                //歌词文本
                LrcWord lw;
                lw.word = line.Groups[3].Value.Trim();
                lw.time = 0;
                lw.during = 0;
                lw.width = double.MinValue;
                lw.widthBefore = double.MinValue;
                //这一行歌词出现的时间
                foreach (Match time in regTime.Matches(line.Groups[1].Value.Trim()))
                {
                    //单行歌词
                    SingleLrc sl;
                    sl.time = getmm(time.Groups[0].Value.Trim());
                    sl.content = new List<LrcWord>();
                    sl.content.Add(lw);
                    sl.width = double.MinValue;
                    sl.time = 0;
                    sl.during = 0;
                    text.Add(sl);
                }
            }
            //起始时间排序
            sort();
            //每一句
            SingleLrc[] slArray = text.ToArray();
            for (int i = 0; i < slArray.Length - 1; i++)
            {
                //每一词
                LrcWord[] lwArray = slArray[i].content.ToArray();
                for (int j = 0; j < lwArray.Length; j++)
                {
                    slArray[i].during = lwArray[j].during = slArray[i + 1].time - slArray[i].time;
                }
                slArray[i].content.Clear();
                slArray[i].content.AddRange(lwArray);
            }
            //更新歌词数据
            text.Clear();
            text.AddRange(slArray);
            //歌词全排序
            sort();
            //就绪
            ready = true;
            //保存序列文件
            if (srcxPath != null)
                saveSRCX(srcxPath, this);
        }

        /// <summary>
        /// 时间转毫秒
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        private int getmm(string time)
        {
            Regex r = new Regex(@"\[(\d+):(\d+)\.(\d+)\]", RegexOptions.Multiline | RegexOptions.CultureInvariant);
            MatchCollection mc = r.Matches(time);
            if (mc.Count == 0)
                return 0;
            return int.Parse(mc[0].Groups[1].Value.Trim()) * 60000
                + int.Parse(mc[0].Groups[2].Value.Trim()) * 1000
                + int.Parse(mc[0].Groups[3].Value.Trim()) * 10;
        }

        /// <summary>
        /// 解析SRC精准歌词
        /// </summary>
        /// <param name="lrc">歌词数据文本</param>
        private void analyzeSRC(string lrc)
        {
            //行匹配
            Regex regLine = new Regex(@"^\[(\d+),(\d+)\](.*?)$", RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.CultureInvariant);
            //单次匹配
            Regex regWords = new Regex(@"<(\d+),(\d+),\d+>([^<\[]+)", RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.CultureInvariant);
            //歌词表
            text = new List<SingleLrc>();
            foreach (Match line in regLine.Matches(lrc))
            {
                //单行歌词
                SingleLrc sl;
                sl.width = double.MinValue;
                sl.time = int.Parse(line.Groups[1].Value.Trim());
                sl.during = int.Parse(line.Groups[2].Value.Trim());
                sl.content = new List<LrcWord>();
                //每个单词
                foreach(Match word in regWords.Matches(line.Groups[3].Value.Trim()))
                {
                    LrcWord lw;
                    lw.time = int.Parse(word.Groups[1].Value.Trim());
                    lw.during = int.Parse(word.Groups[2].Value.Trim());
                    lw.word = word.Groups[3].Value;
                    lw.width = double.MinValue;
                    lw.widthBefore = double.MinValue;
                    sl.content.Add(lw);
                }
                text.Add(sl);
            }
            //歌词全排序
            sort();
            //就绪
            ready = true;
            if (srcxPath != null)
                saveSRCX(srcxPath, this);

        }
        
        /// <summary>
        /// 序列化存储歌词
        /// </summary>
        /// <param name="path">保存路径</param>
        /// <param name="obj"></param>
        public static void saveSRCX(string path, Lyric obj)
        {
            //文件流
            Stream fStream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite, FileShare.None);
            //二进制序列化器
            BinaryFormatter binFormat = new BinaryFormatter();
            //序列化对象
            binFormat.Serialize(fStream, obj);
            //关闭文件
            fStream.Flush();
            fStream.Close();
        }

        /// <summary>
        /// 歌词排序
        /// </summary>
        public void sort()
        {
            //每行排序
            text.Sort((left, right) =>
                {
                    if (left.time > right.time)
                        return 1;
                    else if (left.time < right.time)
                        return -1;
                    else
                        return 0;
                });

            //每行每次排序
            foreach (SingleLrc sl in text)
            {
                sl.content.Sort((left, right) =>
                    {
                        if (left.time > right.time)
                            return 1;
                        else if (left.time < right.time)
                            return -1;
                        else
                            return 0;
                    });
            }
            lrcUpdated = true;
        }

        /// <summary>
        /// KRC歌词解密
        /// </summary>
        /// <param name="data">歌词加密数据</param>
        /// <returns></returns>
        private byte[] decodeKRC(byte[] data)
        {
            if (data[0] != 107 || data[1] != 114 || data[2] != 99 || data[3] != 49)
                return null;
            byte[] key = { 64, 71, 97, 119, 94, 50, 116, 71, 81, 54, 49, 45, 206, 210, 110, 105 }; //秘钥
            //解密
            for (int i = 4; i < data.Length; i++)
                data[i - 4] = (byte)(data[i] ^ key[(i - 4) % 16]);
            //zlib解压
            MemoryStream outfile = new MemoryStream();
            ZOutputStream outZStream = new ZOutputStream(outfile);
            byte[] ret;
            try
            {
                outZStream.Write(data, 0, data.Length - 4);
                outZStream.Flush();
                outfile.Flush();
                ret = outfile.ToArray();
            }
            finally
            {
                outZStream.Close();
            }
            return ret;
        }
    }
}
