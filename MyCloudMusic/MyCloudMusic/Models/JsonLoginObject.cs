using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCloudMusic.Models
{
    public class JsonLoginObject 
    {

        public double loginType { get; set; }

        public double code { get; set; }

        public Account account { get; set; }

        public Profile profile { get; set; }

        public List<BindingsItem> bindings { get; set; }
    }

    public class Account
    {
        /// <summary>
        /// 
        /// </summary>
        public double id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string userName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double whitelistAuthority { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double createTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string salt { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double tokenVersion { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double ban { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double baoyueVersion { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double donateVersion { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double vipType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double viptypeVersion { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string anonimousUser { get; set; }
    }

    public class Experts
    {
    }

    public class Profile
    {
        /// <summary>
        /// 
        /// </summary>

        public string backgroundUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double city { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double birthday { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double avatarImgId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double userType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double backgroundImgId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double userId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double accountStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double vipType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double gender { get; set; }
        /// <summary>
        /// 哈根达斯的杯具
        /// </summary>
        public string nickname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string defaultAvatar { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string avatarUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double province { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double djStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string description { get; set; }
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
        public string detailDescription { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string followed { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Experts experts { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string mutual { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string remarkName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string expertTags { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double authStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string signature { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double authority { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double followeds { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double follows { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double eventCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double playlistCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double playlistBeSubscribedCount { get; set; }
    }

    public class BindingsItem
    {
        /// <summary>
        /// 
        /// </summary>
        public double userId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double bindingTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string tokenJsonStr { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double expiresIn { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string expired { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double refreshTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double type { get; set; }
    }




}
