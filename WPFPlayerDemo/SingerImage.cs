﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;

namespace WPFPlayerDemo
{
    /// <summary>
    /// 歌手图片
    /// </summary>
    class SingerImage
    {
        /// <summary>
        /// 不允许实例化
        /// </summary>
        private SingerImage() { }

        /// <summary>
        /// 文件保存路径
        /// </summary>
        public static string path;

        /// <summary>
        /// 当前获取的id
        /// </summary>
        public static int getid = 0;

        /// <summary>
        /// 歌手图片回调函数
        /// </summary>
        /// <param name="filepath">文件路径</param>
        public delegate void imageFile(string filepath);

        /// <summary>
        /// 获取歌手图片（来源：酷我音乐）
        /// </summary>
        /// <param name="artist">歌手</param>
        /// <param name="getid"></param>
        /// <param name="ret"></param>
        public static void getImage(string artist, int getid, imageFile ret)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            int hash = artist.LastIndexOf('/');
            if (hash >= 0)
                artist = artist.Substring(hash + 1);
            //本地查找
            artist = Helper.pathClear(artist);
            string[] files = Directory.GetFiles(path, artist + "_*.jpg", SearchOption.TopDirectoryOnly);
            if (files.Length > 0 && getid == SingerImage.getid)
            {
                ret(files[Helper.random.Next(files.Length)]);
                return;
            }
            //网络查询
            try
            { 
                //查询地址
                string url = string.Format(
                    @"http://artistpicserver.kuwo.cn/pic.web?user=863581011700668&prod=kwplayer_ar_6.4.6.0&corp=kuwo&source=kwplayer_ar_6.4.6.0_qq.apk&type=big_artist_pic&pictype=url&content=list&id=0&name={0}&width=1024&height=768",
                    artist);
                //查询图片路径
                using(WebClient wc = new WebClient())
                {
                    //查询图片
                    wc.DownloadStringCompleted += (sender, e)=>
                        {
                            if (!e.Cancelled && e.Error == null)
                            { 
                                //解析查询结果
                                string[] images = e.Result.Split(new char[] { '\r', '\n' });
                                //下载图片
                                int id = 0;
                                foreach (string image in images)
                                {
                                    if (!image.StartsWith("http"))
                                        continue;
                                    using (WebClient download = new WebClient())
                                    {
                                        download.DownloadDataCompleted += (s, ed) =>
                                            {
                                                if (!ed.Cancelled && ed.Error == null)
                                                { 
                                                    //保存图片
                                                    FileStream fs = new FileStream(path + "\\" + artist + "_" + id++ + ".jpg", FileMode.Create, FileAccess.Write, FileShare.None);
                                                    fs.Write(ed.Result, 0, ed.Result.Length);
                                                    fs.Flush();
                                                    fs.Close();
                                                    //返回第一个文件的路径
                                                    if (id == 1 && getid == SingerImage.getid)
                                                        ret(path + "\\" + artist + "_0.jpg");
                                                }
                                            };
                                        download.DownloadDataAsync(new Uri(image));
                                    }
                                }
                            }
                        };
                    wc.DownloadStringAsync(new Uri(url));
                }
            }
            catch(Exception){}
        }
    }
}
