using MyCloudMusic.Models;
using MyCloudMusic.Models.JsonSongDetailsInfoObject;
using MyCloudMusic.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestListDemo;
using SongsItem = MyCloudMusic.Models.SongsItem;

namespace MyCloudMusic.Views
{
    /// <summary>
    /// 搜索结果页面 的交互逻辑
    /// </summary>
    /// 
    public delegate void FoundValue(SongModel str);
    public partial class PageFoundSongs : Page
    {
        private string value;   //  搜索的内容
        private static string limit = "&limit=30"; //  限定只获得30首单曲
        private static string type = "&type=1"; //  限定获得内容为单曲

        private string result;  //  返回的json结果

        private List<Models.SongsItem> songs;  //  搜索结果歌曲集合
        private ObservableCollection<SongModel> SongsList = new ObservableCollection<SongModel>();  //  歌单的歌曲集合
        private List<double> songIds = new List<double>();  //  歌曲Id集合
        private List<string> songNames = new List<string>();    //  歌曲名集合
        private List<string> songArtisits = new List<string>();    //  歌曲作者集合
        private List<string> songAlbums = new List<string>();    //  歌曲专辑集合
        private List<string> songAlbumUrls = new List<string>();    //  歌曲专辑封面集合
        private List<double> songTimes = new List<double>();    //  歌曲时长集合
        private List<string> songUrls = new List<string>();     //  歌曲url集合
        private FoundValue found;
        public PageFoundSongs(string value,FoundValue found)
        {
            InitializeComponent();
            this.value = value;
            this.found = found;
            initPage();
            initList();
        }

        private void initPage()
        {
            ValueText.Text = value;

            string url = "http://jungha.top/search?keywords=" + value + type + limit;

            result = HttpUtils.GetJsonResult(url);
            string songUrl1 = "http://jungha.top/song/url?id=";
            string songUrl2 = "http://jungha.top/song/detail?ids=";
            JsonFoundSongsObject json = JsonConvert.DeserializeObject<JsonFoundSongsObject>(result);
            songs = json.result.songs;
            for (int i = 0; i < songs.Count; i++)
            {
                SongModel s = new SongModel();
                s.SongId = songs[i].id.ToString();
                s.SongName = songs[i].name;
                songIds.Add(songs[i].id);
                
                for (int j = 0; j < songs[i].artists.Count; j++)
                {
                    s.SongAuthor += songs[i].artists[j].name;
                    if (j != songs[i].artists.Count - 1)
                    {
                        s.SongAuthor += "/";
                    }
                }

                s.SongAlbum = songs[i].album.name;
                string time = ((int)songs[i].duration / 1000 / 60).ToString().PadLeft(2, '0') + 
                    ":" + ((int)(((songs[i].duration / 1000 / 60) -
                    (int)(songs[i].duration / 1000 / 60)) * 60)).ToString().PadLeft(2, '0');
                s.SongTime = time;
                SongsList.Add(s);
            }
            string str = String.Join(",", songIds.ConvertAll<string>(new Converter<double, string>(m => m.ToString())).ToArray());

            songUrl1 += str;
            songUrl2 += str;

            string songUrlResult = HttpUtils.GetJsonResult(songUrl1);
            string songInfoResult = HttpUtils.GetJsonResult(songUrl2);

            JsonSongUrlInfoObject songUrlJson = JsonConvert.DeserializeObject<JsonSongUrlInfoObject>(songUrlResult);
            JsonSongDetailsInfoObject songInfoJson = JsonConvert.DeserializeObject<JsonSongDetailsInfoObject>(songInfoResult);
            for (int i = 0; i < songUrlJson.data.Count; i++)
            {
                SongsList[i].SongAlbumUrls = songInfoJson.songs[i].al.picUrl;
                for (int k = 0; k < songInfoJson.songs.Count; k++)
                {

                    if (SongsList[i].SongId == songUrlJson.data[k].id.ToString())
                        SongsList[i].SongPath = songUrlJson.data[k].url;
                }
            }
        }

        private void initList()
        {
            SongList.ItemsSource = SongsList;
        }

        private void MListBox_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            try
            {
                int index = SongList.SelectedIndex;
                SongModel songModel = new SongModel()
                {
                    SongName = SongsList[index].SongName,
                    SongAuthor = SongsList[index].SongAuthor,
                    SongAlbum = SongsList[index].SongAlbum,
                    SongTime = SongsList[index].SongTime,
                    SongPath = SongsList[index].SongPath,
                    SongAlbumUrls = SongsList[index].SongAlbumUrls
                };
                found(songModel);
            }
            catch{}
        }
    }
}
