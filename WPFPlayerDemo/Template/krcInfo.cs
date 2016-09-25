using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WPFPlayerDemo.Template
{
    [DataContract]
    class krcInfo
    {
        [DataMember]
        public string kid { get; set; }

        [DataMember]
        public int timelength { get; set; }

        [DataMember]
        public string uid { get; set; }

        [DataMember]
        public int grade { get; set;}

        [DataMember]
        public string singer { get; set; }

        [DataMember]
        public string song { get; set; }
    }
}
