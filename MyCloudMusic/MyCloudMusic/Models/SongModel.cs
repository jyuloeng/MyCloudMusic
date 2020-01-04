using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCloudMusic.Models
{
    public class SongModel:ObservableObject
    {
        private string songName;
        private string songAuthor;
        private string songAlbum;
        private double songTime;
        private double songSize;
        private string songPath;

        public SongModel() { }
        public SongModel(string songName,string songAuthor,string songAlbum,
            double songTime,double songSize,string songPath)
        {
            this.songName = songName;
            this.songAuthor = songAuthor;
            this.songAlbum = songAlbum;
            this.songTime = songTime;
            this.songSize = songSize;
            this.songPath = songPath;
        }

        public string SongName
        {
            get
            {
                return songName;
            }

            set
            {
                songName = value; RaisePropertyChanged(() => SongName);
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
                songAuthor = value; RaisePropertyChanged(() => SongAuthor);
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
                songAlbum = value; RaisePropertyChanged(() => SongAlbum);
            }
        }

        public double SongTime
        {
            get
            {
                return songTime;
            }

            set
            {
                songTime = value; RaisePropertyChanged(() => SongTime);
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
                songSize = value; RaisePropertyChanged(() => SongSize);
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
                songPath = value; RaisePropertyChanged(() => SongPath);
            }
        }
    }
}
