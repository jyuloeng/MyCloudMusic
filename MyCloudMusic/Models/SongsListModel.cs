using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCloudMusic.Models
{
    public class SongsListModel
    {
        private double songsListId; //  歌单id
        private string nickname; 
        private string songsListName;   // 歌单标题
        private string songsListUrl;   // 歌单封面url
        private double songsListCount;   // 歌单歌曲数
        private double songsListPlayCount;   // 歌单播放次数
        private double songsListCreateTime;   // 歌单创建时间；
        private string songsListNickName;   // 歌单创建者名
        private string songsListAvatarUrl;   // 歌单创建者头像url

        public SongsListModel() { }
        public SongsListModel(double songsListId, string songsListName, string songsListUrl, double songsListCount, double songsListPlayCount, double songsListCreateTime, string songsListNickName, string songsListAvatarUrl )
        {
            this.songsListId = songsListId;
            this.songsListName = songsListName;
            this.songsListUrl = songsListUrl;
            this.songsListCount = songsListCount;
            this.songsListPlayCount = songsListPlayCount;
            this.songsListCreateTime = songsListCreateTime;
            this.songsListNickName = songsListNickName;
            this.songsListAvatarUrl = songsListAvatarUrl;
            
        }

        public string SongsListName
        {
            get
            {
                return songsListName;
            }

            set
            {
                songsListName = value;
            }
        }

        public string SongsListUrl
        {
            get
            {
                return songsListUrl;
            }

            set
            {
                songsListUrl = value;
            }
        }

        public double SongsListCount
        {
            get
            {
                return songsListCount;
            }

            set
            {
                songsListCount = value;
            }
        }

        public double SongsListPlayCount
        {
            get
            {
                return songsListPlayCount;
            }

            set
            {
                songsListPlayCount = value;
            }
        }

        public double SongsListCreateTime
        {
            get
            {
                return songsListCreateTime;
            }

            set
            {
                songsListCreateTime = value;
            }
        }

        public string SongsListNickName
        {
            get
            {
                return songsListNickName;
            }

            set
            {
                songsListNickName = value;
            }
        }

        public string SongsListAvatarUrl
        {
            get
            {
                return songsListAvatarUrl;
            }

            set
            {
                songsListAvatarUrl = value;
            }
        }
        public string Nickname
        {
            get
            {
                return nickname;
            }

            set
            {
                nickname = value;
            }
        }
        public double SongsListId
        {
            get
            {
                return songsListId;
            }

            set
            {
                songsListId = value;
            }
        }
    }
}
