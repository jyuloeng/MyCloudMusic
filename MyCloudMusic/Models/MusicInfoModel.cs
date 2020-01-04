using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace TestListDemo
{
    public class MusicInfoModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;   //  调用接口
        public string musicId;   //  歌曲id
        private string musicName;   //  歌名
        private string musicArtists;    //  作者
        private string musicAlbum;  //  专辑
        private string musicDuration;   //  歌曲时间
        private string musicSize;   //  歌曲大小
        private string musicPath;   //  歌曲路径
        private string musicAlbumUrls;
        private BitmapImage source;
        public int num = 0; //  序号

        public MusicInfoModel() { }
        public MusicInfoModel(string musicName,string musicArtists,string musicAlbum,
            string musicDuration, string musicSize,string musicPath)
        {
            this.musicName = musicName;
            this.musicArtists = musicArtists;
            this.musicAlbum = musicAlbum;
            this.musicDuration = musicDuration;
            this.musicSize = musicSize;
            this.musicPath = musicPath;
        }


        public MusicInfoModel(string musicName, string musicArtists, string musicAlbum,
            string musicDuration, string musicPath)
        {
            this.musicName = musicName;
            this.musicArtists = musicArtists;
            this.musicAlbum = musicAlbum;
            this.musicDuration = musicDuration;
            this.musicPath = musicPath;
        }
        public MusicInfoModel(string musicName, string musicArtists, string musicAlbum,
            string musicDuration, string musicPath,string musicAlbumUrls ,int i)
        {
            this.musicName = musicName;
            this.musicArtists = musicArtists;
            this.musicAlbum = musicAlbum;
            this.musicDuration = musicDuration;
            this.musicPath = musicPath;
            this.musicAlbumUrls = musicAlbumUrls;
        }

       
        public string MusicId
        {
            get { return musicId; }
            set
            {
                musicName = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("MusicId"));
            }
        }

        public string MusicName {
            get { return musicName; }
            set { musicName = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("MusicName")); }
        }

        public string MusicArtists
        {
            get { return musicArtists; }
            set
            {
                musicArtists = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("MusicArtists"));
            }
        }

        public string MusicAlbum
        {
            get { return musicAlbum; }
            set
            {
                musicAlbum = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("MusicAlbum"));
            }
        }

        public string MusicDuration
        {
            get { return musicDuration; }
            set
            {
                musicDuration = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("MusicDuration"));
            }
        }

        public string MusicSize
        {
            get { return musicSize; }
            set
            {
                musicSize = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("MusicSize"));
            }
        }

        public string MusicPath
        {
            get { return musicPath; }
            set
            {
                musicPath = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("MusicPath"));
            }
        }
        public string MusicAlbumUrls
        {
            get { return musicAlbumUrls; }
            set
            {
                musicPath = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("MusicAlbumUrls"));
            }
        }
        public BitmapImage Source
        {
            get { return source; }
            set
            {
                source = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Source"));
            }
        }

    }
}
