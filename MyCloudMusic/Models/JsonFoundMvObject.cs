using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCloudMusic.Models.JsonFoundMvObject
{
    public class JsonFoundMvObject
    {
        public double count { get; set; }

        public string hasMore { get; set; }

        public List<DataItem> data { get; set; }

        public int code { get; set; }
    }
    public class ArtistsItem
    {

        public double id { get; set; }

        public string name { get; set; }
 
        public List<string> @alias { get; set; }

        public List<string> transNames { get; set; }
    }

    public class DataItem
    {
        //  mv的ID
        public double id { get; set; }

        //  mv的封面url
        public string cover { get; set; }

        //  mv的名字
        public string name { get; set; }

        //  mv的播放次数
        public double playCount { get; set; }

        public string briefDesc { get; set; }

        public string desc { get; set; }

        //  mv作者
        public string artistName { get; set; }

        public double artistId { get; set; }

        public double duration { get; set; }

        public double mark { get; set; }

        public string subed { get; set; }
 
        public List<ArtistsItem> artists { get; set; }
    }
}
