using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCloudMusic.Models
{
    //  登陆json实体类
    public class JsonLoginObject
    {

        public int loginType { get; set; }

        public int code { get; set; }

        public Account account { get; set; }

        public Profile profile { get; set; }

        public List<BindingsItem> bindings { get; set; }
    }

    public class Account
    {
        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string userName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int whitelistAuthority { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public float createTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string salt { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int tokenVersion { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ban { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int baoyueVersion { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int donateVersion { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int vipType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int viptypeVersion { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string anonimousUser { get; set; }
    }

    public class Experts
    {
        public string name { get; set; }
        public string age { get; set; }
    }

    public class Profile
    {

        public string detailDescription { get; set; }

        public string followed { get; set; }

        public string description { get; set; }

        public string avatarImgIdStr { get; set; }

        public string backgroundImgIdStr { get; set; }

        public double userId { get; set; }

        public int gender { get; set; }

        public int accountStatus { get; set; }

        public int vipType { get; set; }

        public float avatarImgId { get; set; }

        public float birthday { get; set; }
        
        //  用户名
        public string nickname { get; set; }

        public int city { get; set; }

        public int userType { get; set; }

        public float backgroundImgId { get; set; }

        public string defaultAvatar { get; set; }

        //  用户头像
        public string avatarUrl { get; set; }

        public int province { get; set; }

        public int djStatus { get; set; }

        public Experts experts { get; set; }

        public string mutual { get; set; }

        public string remarkName { get; set; }

        public string expertTags { get; set; }

        public int authStatus { get; set; }

        public string backgroundUrl { get; set; }

        public string signature { get; set; }

        public int authority { get; set; }

        public int followeds { get; set; }

        public int follows { get; set; }

        public int eventCount { get; set; }

        public int playlistCount { get; set; }

        public int playlistBeSubscribedCount { get; set; }
    }

    public class BindingsItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string expired { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int refreshTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int userId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string tokenJsonStr { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public float bindingTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int expiresIn { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public float id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int type { get; set; }
    }

    
}
