using GalaSoft.MvvmLight;
using MyCloudMusic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCloudMusic.ViewModel
{
    public class SongViewModel:ViewModelBase
    {
        public SongModel songInfo;

        public SongModel SongInfo
        {
            get { return songInfo; }
            set { songInfo = value;RaisePropertyChanged(() => SongInfo); }
        }

        public SongViewModel()
        {
            if (IsInDesignMode)     // 如果是设计模式
            {
                songInfo = new SongModel() {
                    SongName = "歌曲1",
                    SongAuthor = "歌手1",
                    SongAlbum = "专辑1",
                    SongTime = 200,
                    SongSize = 200,
                    SongPath = "路径1" };
            }
            else    //  从数据库获取
            { 
                songInfo = new SongModel()
                {
                    SongName = "歌曲2",
                    SongAuthor = "歌手2",
                    SongAlbum = "专辑2",
                    SongTime = 200,
                    SongSize = 200,
                    SongPath = "路径2"
                };
            }
        }
    }
}
