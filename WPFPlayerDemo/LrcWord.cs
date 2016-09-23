using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPFPlayerDemo
{
    /// <summary>
    /// 每个单词
    /// </summary>
    [Serializable]
    struct LrcWord
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
        /// 内容
        /// </summary>
        public string word;

        /// <summary>
        /// 当前词之前显示宽度
        /// </summary>
        public double widthBefore;

        /// <summary>
        /// 当前歌词显示宽度
        /// </summary>
        public double width;
    }
}
