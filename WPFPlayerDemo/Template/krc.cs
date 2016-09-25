using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WPFPlayerDemo.Template
{
    [DataContract]
    class krc
    {
        /// <summary>
        /// 返回码
        /// </summary>
        [DataMember]
        public int status { get; set; }

        /// <summary>
        /// 结果条数
        /// </summary>
        [DataMember]
        public int recordcount { get; set;}

        /// <summary>
        /// 结果数组
        /// </summary>
        [DataMember]
        public krcInfo[] data { get; set; }

        /// <summary>
        /// 默认id
        /// </summary>
        [DataMember]
        public string @default { get; set; }
    }
}
