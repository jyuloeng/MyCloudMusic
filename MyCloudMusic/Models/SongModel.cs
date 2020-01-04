using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCloudMusic.Models
{
    public class SongModel
    {
        private string songId;  //  歌曲Id
        private string songName;    //  歌曲名字
        private string songAuthor;  //  歌曲艺术家
        private string songAlbum;   //  歌曲专辑
        private string songTime;    //  歌曲时间
        private double songSize;    //  歌曲大小
        private string songPath;    //  歌曲路径
        private string songAlbumUrls;   //  歌曲封面url

        public SongModel() { }
        public SongModel(string songId,string songName, string songAuthor, string songAlbum,
            string songTime, double songSize, string songPath, string songAlbumUrls)
        {
            this.songId = songId;
            this.songName = songName;
            this.songAuthor = songAuthor;
            this.songAlbum = songAlbum;
            this.songTime = songTime;
            this.songSize = songSize;
            this.songPath = songPath;
            this.songAlbumUrls = songAlbumUrls;
        }

        public string SongId
        {
            get
            {
                return songId;
            }

            set
            {
                songId = value;
            }
        }
        public string SongName
        {
            get
            {
                return songName;
            }

            set
            {
                songName = value; 
            }
        }

        public string SongAuthor
        {
            get
            {
                return songAuthor;
            }

            set
            {
                songAuthor = value; 
            }
        }

        public string SongAlbum
        {
            get
            {
                return songAlbum;
            }

            set
            {
                songAlbum = value; 
            }
        }

        public string SongTime
        {
            get
            {
                return songTime;
            }

            set
            {
                songTime = value; 
            }
        }

        public double SongSize
        {
            get
            {
                return songSize;
            }

            set
            {
                songSize = value; 
            }
        }

        public string SongPath
        {
            get
            {
                return songPath;
            }

            set
            {
                songPath = value;
            }
        }
        public string SongAlbumUrls
        {
            get
            {
                return songAlbumUrls;
            }

            set
            {
                songAlbumUrls = value;
            }
        }
        
    }
}
