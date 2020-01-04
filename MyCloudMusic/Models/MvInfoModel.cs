using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCloudMusic.Models
{
    public class MvInfoModel
    {
        private double mvId;    //  mv的Id
        private string mvName;  //  mv的名字
        private string mvArtist;    //  mv的艺术家
        private string mvImgUrl;    //  mv封面的url地址
        private string mvUrl;   //  mv播放的url地址
        private double mvPlayCount; //  mv的播放次数


        public MvInfoModel() { }
        public MvInfoModel(double mvId, string mvName, string mvArtist, string mvImgUrl, string mvUrl, double mvPlayCount)
        {
            this.mvId = mvId;
            this.mvName = mvName;
            this.mvArtist = mvArtist;
            this.mvImgUrl = mvImgUrl;
            this.mvUrl = mvUrl;
            this.mvPlayCount = mvPlayCount;
        }

        public double MvId
        {
            get
            {
                return mvId;
            }

            set
            {
                mvId = value;
            }
        }

        public string MvName
        {
            get
            {
                return mvName;
            }

            set
            {
                mvName = value;
            }
        }

        public string MvArtist
        {
            get
            {
                return mvArtist;
            }

            set
            {
                mvArtist = value;
            }
        }

        public string MvImgUrl
        {
            get
            {
                return mvImgUrl;
            }

            set
            {
                mvImgUrl = value;
            }
        }

        public string MvUrl
        {
            get
            {
                return mvUrl;
            }

            set
            {
                mvUrl = value;
            }
        }

        public double MvPlayCount
        {
            get
            {
                return mvPlayCount;
            }

            set
            {
                mvPlayCount = value;
            }
        }

    }
}
