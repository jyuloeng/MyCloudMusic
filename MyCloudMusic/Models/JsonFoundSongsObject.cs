using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCloudMusic.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class JsonFoundSongsObject
    {
        [JsonProperty]
        public Result result { get; set; }

        [JsonProperty]
        public int code { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class ArtistsItem
    {

        public int id { get; set; }

        //  歌手名
        [JsonProperty]
        public string name { get; set; }

        public string picUrl { get; set; }

        public List<string> @alias { get; set; }

        public int albumSize { get; set; }

        public int picId { get; set; }
 
        public string img1v1Url { get; set; }

        public int img1v1 { get; set; }

        public string trans { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class Artist
    {
 
        public int id { get; set; }

        public string name { get; set; }
   
        public string picUrl { get; set; }

        public List<string> @alias { get; set; }
  
        public int albumSize { get; set; }
  
        public int picId { get; set; }

        public string img1v1Url { get; set; }
 
        public int img1v1 { get; set; }
 
        public string trans { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class Album
    {
 
        public int id { get; set; }

        //  专辑名
        [JsonProperty]
        public string name { get; set; }

        [JsonProperty]
        public Artist artist { get; set; }

        public int publishTime { get; set; }
    
        public int size { get; set; }
        
        public int copyrightId { get; set; }
      
        public int status { get; set; }
       
        public int picId { get; set; }
        
        public int mark { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class SongsItem
    {

        //  歌曲Id
        [JsonProperty]
        public double id { get; set; }

        //  歌曲名
        [JsonProperty]
        public string name { get; set; }

        [JsonProperty]
        public List<ArtistsItem> artists { get; set; }

        [JsonProperty]
        public Album album { get; set; }

        //  歌曲时长
        [JsonProperty]
        public double duration { get; set; }
        
        public int copyrightId { get; set; }
        
        public int status { get; set; }
        
        public List<string> @alias { get; set; }
        
        public int rtype { get; set; }
        
        public int ftype { get; set; }
        
        public int mvid { get; set; }
        
        public int fee { get; set; }
        
        public string rUrl { get; set; }
        
        public int mark { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class Result
    {
        
        public List<string> queryCorrected { get; set; }

        [JsonProperty]
        public List<SongsItem> songs { get; set; }

        [JsonProperty]
        public double songCount { get; set; }
    }
}
