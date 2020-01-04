using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCloudMusic.Models
{
    //  用户歌单json实体类
    [JsonObject(MemberSerialization.OptIn)]
    public class JsonUserSongsListObject
    {
        [JsonProperty]
        public bool more { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty]
        public List<PlaylistItem> playlist { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty]
        public double code { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class CreatorItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string defaultAvatar { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int province { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int authStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string followed { get; set; }
        /// <summary>
        /// 歌单创建者头像
        /// </summary>
        [JsonProperty]
        public string avatarUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int accountStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int gender { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int city { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int birthday { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int userId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int userType { get; set; }
        /// <summary>
        /// 歌单创建者
        /// </summary>
        [JsonProperty]
        public string nickname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string signature { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string detailDescription { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int avatarImgId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int backgroundImgId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string backgroundUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int authority { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string mutual { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string expertTags { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string experts { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int djStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int vipType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string remarkName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string avatarImgIdStr { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string backgroundImgIdStr { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class PlaylistItem
    {
        /// <summary>
        /// 
        /// </summary>
        public List<string> subscribers { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool subscribed { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Creator creator { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string artists { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string tracks { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string updateFrequency { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double backgroundCoverId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string backgroundCoverUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double titleImage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string titleImageUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string englishTitle { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool opRecommend { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double subscribedCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double cloudTrackCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double trackNumberUpdateTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> tags { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public string description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool ordered { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double adType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double updateTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double coverImgId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool newImported { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool anonimous { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double specialType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string commentThreadId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double privacy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double trackUpdateTime { get; set; }
        /// <summary>
        /// 歌曲数
        /// </summary>
        [JsonProperty]
        public double trackCount { get; set; }
        /// <summary>
        /// 封面Url
        /// </summary>
        [JsonProperty]
        public string coverImgUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double totalDuration { get; set; }
        /// <summary>
        /// 播放次数
        /// </summary>
        [JsonProperty]
        public double playCount { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [JsonProperty]
        public double createTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool highQuality { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double userId { get; set; }
        /// <summary>
        /// 送温暖的大红帽丶喜欢的音乐
        /// </summary>
        [JsonProperty]
        public string name { get; set; }
        /// <summary>
        /// 歌单Id
        /// </summary>
        [JsonProperty]
        public double id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string coverImgId_str { get; set; }
    }
}
