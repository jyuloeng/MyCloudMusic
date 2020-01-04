using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCloudMusic.Models
{
    //  歌单详情json实体类
    public class JsonSongsListObject
    {
        public double code { get; set; }

        public string relatedVideos { get; set; }

        public Playlist playlist { get; set; }

        public string urls { get; set; }

        public List<PrivilegesItem> privileges { get; set; }
    }

    //  
    public class Creator
    {

        public string defaultAvatar { get; set; }

        public double province { get; set; }

        public double authStatus { get; set; }

        public string followed { get; set; }
 
        //  头像url
        public string avatarUrl { get; set; }

        public double accountStatus { get; set; }

        public double gender { get; set; }
   
        public double city { get; set; }

        public double birthday { get; set; }

        public double userId { get; set; }

        public double userType { get; set; }

        // 歌单创建者名字
        public string nickname { get; set; }

        public string signature { get; set; }

        public string description { get; set; }

        public string detailDescription { get; set; }

        public double avatarImgId { get; set; }

        public double backgroundImgId { get; set; }

        public string backgroundUrl { get; set; }

        public double authority { get; set; }

        public string mutual { get; set; }

        public List<string> expertTags { get; set; }

        //public List<string> experts { get; set; }

        public double djStatus { get; set; }

        public double vipType { get; set; }

        public string remarkName { get; set; }
 
        public string backgroundImgIdStr { get; set; }
 
        public string avatarImgIdStr { get; set; }
    }


    public class ArItem
    {

        public double id { get; set; }

        //  歌手名
        public string name { get; set; }

        public List<string> tns { get; set; }

        public List<string> @alias { get; set; }
    }

    public class Al
    {

        public double id { get; set; }

        //  专辑名
        public string name { get; set; }
 
        //  专辑封面
        public string picUrl { get; set; }

        public List<string> tns { get; set; }
 
        public string pic_str { get; set; }

        public double pic { get; set; }
    }

    public class H
    {

        public double br { get; set; }

        public double fid { get; set; }

        public double size { get; set; }

        public double vd { get; set; }
    }

    public class M
    {

        public double br { get; set; }

        public double fid { get; set; }

        public double size { get; set; }
 
        public double vd { get; set; }
    }

    public class L
    {

        public double br { get; set; }

        public double fid { get; set; }

        public double size { get; set; }

        public double vd { get; set; }
    }

    //  歌曲详情
    public class TracksItem
    {
        //  歌名
        public string name { get; set; }

        public double id { get; set; }

        public double pst { get; set; }

        public double t { get; set; }

        public List<ArItem> ar { get; set; }

        public List<string> alia { get; set; }

        public double pop { get; set; }

        public double st { get; set; }

        public string rt { get; set; }

        public double fee { get; set; }

        public double v { get; set; }

        public string crbt { get; set; }

        public string cf { get; set; }

        public Al al { get; set; }

        //  歌曲时长
        public double dt { get; set; }

        public H h { get; set; }

        public M m { get; set; }

        public L l { get; set; }
 
        public string a { get; set; }
 
        public string cd { get; set; }

        public double no { get; set; }

        public string rtUrl { get; set; }
 
        public double ftype { get; set; }

        public List<string> rtUrls { get; set; }
 
        public double djId { get; set; }

        public double copyright { get; set; }
   
        public double s_id { get; set; }

        public double mark { get; set; }

        public double rtype { get; set; }
   
        public string rurl { get; set; }
        
        public double mst { get; set; }
       
        public double cp { get; set; }
        
        public double mv { get; set; }
        
        public double publishTime { get; set; }
    }

    public class TrackIdsItem
    {

        public double id { get; set; }

        public double v { get; set; }

        public string alg { get; set; }
    }

    //
    public class Playlist
    {

        public List<SubscribersItem> subscribers { get; set; }

        public bool subscribed { get; set; }

        public Creator creator { get; set; }

        //  歌曲详情
        public List<TracksItem> tracks { get; set; }

        public List<TrackIdsItem> trackIds { get; set; }
  
        public string updateFrequency { get; set; }

        public double backgroundCoverId { get; set; }

        public string backgroundCoverUrl { get; set; }

        public double titleImage { get; set; }

        public string titleImageUrl { get; set; }

        public string englishTitle { get; set; }
  
        public string opRecommend { get; set; }

        public double subscribedCount { get; set; }

        public double cloudTrackCount { get; set; }

        public double adType { get; set; }

        public double trackNumberUpdateTime { get; set; }

        //  创建时间
        public double createTime { get; set; }

        public string highQuality { get; set; }

        public double userId { get; set; }

        public double updateTime { get; set; }

        public double coverImgId { get; set; }

        public string newImported { get; set; }

        public double specialType { get; set; }

        //  歌单封面
        public string coverImgUrl { get; set; }

        public double privacy { get; set; }

        public double trackUpdateTime { get; set; }

        //  歌曲数
        public double trackCount { get; set; }
 
        public string commentThreadId { get; set; }

        //  播放次数
        public double playCount { get; set; }

        public string ordered { get; set; }

        public string description { get; set; }

        public List<string> tags { get; set; }

        public double status { get; set; }

        //  歌单名字  
        public string name { get; set; }

        public double id { get; set; }

        public double shareCount { get; set; }

        public string coverImgId_str { get; set; }

        public double commentCount { get; set; }
    }

    //
    public class PrivilegesItem
    {
        //  歌曲id
        public double id { get; set; }

        public double fee { get; set; }

        public double payed { get; set; }

        public double st { get; set; }

        public double pl { get; set; }

        public double dl { get; set; }

        public double sp { get; set; }

        public double cp { get; set; }
 
        public double subp { get; set; }

        public string cs { get; set; }

        public double maxbr { get; set; }

        public double fl { get; set; }

        public string toast { get; set; }

        public double flag { get; set; }

        public string preSell { get; set; }
    }
    public class SubscribersItem
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
        /// 
        /// </summary>
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
        public double birthday { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int userId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int userType { get; set; }
        /// <summary>
        /// 阿喵真的会发光
        /// </summary>
        public string nickname { get; set; }
        /// <summary>
        /// 我喜欢猫
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
        public double avatarImgId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double backgroundImgId { get; set; }
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
        /// <summary>
        /// 
        /// </summary>
        public string avatarImgId_str { get; set; }
    }
}
