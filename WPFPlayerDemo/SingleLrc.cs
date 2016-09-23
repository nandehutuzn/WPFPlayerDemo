using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPFPlayerDemo
{
    /// <summary>
    /// 单行歌词
    /// </summary>
    [Serializable]
    struct SingleLrc
    {
        /// <summary>
        /// 开始时间
        /// </summary>
        public int time;

        /// <summary>
        /// 持续时间
        /// </summary>
        public int during;

        /// <summary>
        /// 歌词数组
        /// </summary>
        public List<LrcWord> content;

        /// <summary>
        /// 显示宽度
        /// </summary>
        public double width;
    }
}
