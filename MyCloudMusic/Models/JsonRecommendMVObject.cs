using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCloudMusic.Models.JsonRecommendMVObject
{
    public class JsonRecommendMVObject
    {
        public int code { get; set; }

        public int category { get; set; }

        public List<ResultItem> result { get; set; }
    }

    public class ArtistsItem
    {

        public double id { get; set; }

        public string name { get; set; }
    }

    public class ResultItem
    {
        //  MV的Id
        public double id { get; set; }

        public double type { get; set; }
        
        public string name { get; set; }

        public string copywriter { get; set; }

        public string picUrl { get; set; }

        public string canDislike { get; set; }

        public string trackNumberUpdateTime { get; set; }

        public double duration { get; set; }

        public double playCount { get; set; }

        public string subed { get; set; }

        public List<ArtistsItem> artists { get; set; }

        public string artistName { get; set; }

        public double artistId { get; set; }

        public string alg { get; set; }
    }
}
