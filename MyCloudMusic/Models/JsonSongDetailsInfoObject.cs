using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCloudMusic.Models.JsonSongDetailsInfoObject
{
    [JsonObject(MemberSerialization.OptIn)]
    public class JsonSongDetailsInfoObject
    {
        [JsonProperty]
        public List<SongsItem> songs { get; set; }

        [JsonProperty]
        public List<PrivilegesItem> privileges { get; set; }

        [JsonProperty]
        public int code { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class ArItem
    {
        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> tns { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> @alias { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class Al
    {

        public int id { get; set; }

        public string name { get; set; }

        //  专辑封面url
        [JsonProperty]
        public string picUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> tns { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string pic_str { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int pic { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class H
    {
        /// <summary>
        /// 
        /// </summary>
        public int br { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int fid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int size { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int vd { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class M
    {
        /// <summary>
        /// 
        /// </summary>
        public int br { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int fid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int size { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int vd { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class L
    {
        /// <summary>
        /// 
        /// </summary>
        public int br { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int fid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int size { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int vd { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class SongsItem
    {
        /// <summary>
        /// 相依为命
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int pst { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int t { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<ArItem> ar { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> alia { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int pop { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int st { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string rt { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int fee { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int v { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string crbt { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string cf { get; set; }

        [JsonProperty]
        public Al al { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int dt { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public H h { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public M m { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public L l { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string a { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string cd { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int no { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string rtUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ftype { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> rtUrls { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int djId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int copyright { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int s_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int mark { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int cp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int rtype { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string rurl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int mst { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int mv { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int publishTime { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class PrivilegesItem
    {
        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int fee { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int payed { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int st { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int pl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int dl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int sp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int cp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int subp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string cs { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int maxbr { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int fl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string toast { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int flag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string preSell { get; set; }
    }
}
