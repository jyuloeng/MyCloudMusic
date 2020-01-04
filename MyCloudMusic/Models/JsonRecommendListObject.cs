using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCloudMusic.Models
{
    //  推荐歌单json实体类
    public class JsonRecommendListObject
    {
        public string hasTaste { get; set; }

        public double code { get; set; }

        public double category { get; set; }

        public List<ResultItem> result { get; set; }
    }

    public class ResultItem
    {
        //  歌单ID
        public double id { get; set; }

        public double type { get; set; }

        //  歌单名字
        public string name { get; set; }

        public string copywriter { get; set; }

        //  歌单相片
        public string picUrl { get; set; }

        //  
        public string canDislike { get; set; }

        public double trackNumberUpdateTime { get; set; }

        public double playCount { get; set; }

        public double trackCount { get; set; }

        public string highQuality { get; set; }

        public string alg { get; set; }
    }
}
