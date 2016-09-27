using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPFPlayerDemo
{
    /// <summary>
    /// 音乐ID3信息
    /// </summary>
    struct MusicID3
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string title;//max.  30 chars

        /// <summary>
        /// 艺术家
        /// </summary>
        public string artisti;  //max  30  chars

        /// <summary>
        /// 专辑
        /// </summary>
        public string album;  //max 30 chars

        /// <summary>
        /// 年份
        /// </summary>
        public string year;  //yyyy

        /// <summary>
        /// 评论
        /// </summary>
        public string comment;  //max  28 chars

        /// <summary>
        /// 标识码
        /// </summary>
        public string genre_id;

        /// <summary>
        /// 轨道
        /// </summary>
        public string track; // 0-255

        /// <summary>
        /// 音乐时长
        /// </summary>
        public string duration;  //非 ID3 属性
    }
}
