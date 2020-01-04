using MyCloudMusic.Models;
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

namespace MyCloudMusic.Views
{
    /// <summary>
    /// PageSongsList.xaml 的交互逻辑
    /// </summary>
    /// 

    public delegate void AllValue(ObservableCollection<MusicInfoModel> s);
    public delegate void SendValue(MusicInfoModel str);
    public partial class PageSongsList : Page
    {
        private SendValue Method;
        private AllValue all;

        private string nickname;
        private double listId;  //  该页歌单的id
        private List<string> listPath = new List<string>(); //  存放地址的集合
        private ObservableCollection<MusicInfoModel> SongsList = new ObservableCollection<MusicInfoModel>();  //  歌单的歌曲集合
        private ObservableCollection<MusicInfoModel> DynamicList = new ObservableCollection<MusicInfoModel>();    //  动态的歌曲集合

        private string songsListName;   // 歌单标题
        private string songsListUrl;   // 歌单封面url
        private double songsListCount;   // 歌单歌曲数
        private double songsListPlayCount;   // 歌单播放次数
        private double songsListCreateTime;   // 歌单创建时间；
        private string songsListNickName;   // 歌单创建者名
        private string songsListAvatarUrl;   // 歌单创建者头像url

        private List<double> songsId = new List<double>();   //  歌单歌曲id
        private List<string> songsUrl = new List<string>();  //  歌曲url集合
        private List<string> songNames = new List<string>();    //  歌曲名集合
        private List<string> songArtisits = new List<string>();    //  歌曲作者集合
        private List<string> songAlbums = new List<string>();    //  歌曲专辑集合
        private List<string> songAlbumUrls = new List<string>();    //  歌曲专辑封面集合
        private List<double> songTimes = new List<double>();    //  歌曲时长集合

        private double num;

        private static string GET_LIST_URL = "http://jungha.top/playlist/detail?id=";
       
        private string result;
        public PageSongsList(double listId,string nickname, SendValue del, AllValue all)
        {
            InitializeComponent();
            this.all = all;
            this.Method = del;
            this.listId = listId;
            this.nickname = nickname;
            mListBox.ItemsSource = SongsList;

            initPage();
            initList();
        }
        private void initPage()
        {
            string url = GET_LIST_URL + listId; //  拼接获取歌单详情的url
            Console.WriteLine(listId);
            result = HttpUtils.GetJsonResult(url);

            JsonSongsListObject json = JsonConvert.DeserializeObject<JsonSongsListObject>(result);

            songsListName = json.playlist.name;
            songsListUrl = json.playlist.coverImgUrl;
            songsListCount = json.playlist.trackCount;
            songsListPlayCount = json.playlist.playCount;
            songsListCreateTime = json.playlist.createTime;
            songsListNickName = json.playlist.creator.nickname;
            songsListAvatarUrl = json.playlist.creator.avatarUrl;

            this.DataContext = new SongsListModel()
            {
                SongsListName = songsListName,
                SongsListUrl = songsListUrl,
                SongsListCount = songsListCount,
                SongsListPlayCount = songsListPlayCount,
                SongsListCreateTime = songsListCreateTime,
                SongsListNickName = songsListName,
                SongsListAvatarUrl = songsListAvatarUrl,
                Nickname = nickname
            };

            //  获取歌单内所有歌曲的id
            List<PrivilegesItem> privileges = json.privileges;
            for (int i = 0; i < privileges.Count; i++)
            {
                songsId.Add(privileges[i].id);
                //Console.WriteLine(songsId[i]);
            }

            //  将所有Id拼接起来
            string str = String.Join(",", songsId.ConvertAll<string>(new Converter<double, string>(m => m.ToString())).ToArray());
            string GET_SONG_URL = "http://jungha.top/song/url?id=";
            string url1 = GET_SONG_URL + str;
            result = HttpUtils.GetJsonResult(url1);
            JsonSongInfoObject jsonSongsInfos = JsonConvert.DeserializeObject<JsonSongInfoObject>(result);

            //  获得该歌单所有歌曲的url地址
            for (int i = 0; i < jsonSongsInfos.data.Count; i++)
            {
                foreach (DataItem m in jsonSongsInfos.data)
                {
                    if(songsId[i] == m.id)
                        songsUrl.Add(m.url);
                }
            }

            num = json.playlist.tracks.Count;

            for (int i = 0; i < num; i++)
            {
                songNames.Add(json.playlist.tracks[i].name); //  歌曲名集合
                string alName = "";
                for (int j = 0; j < json.playlist.tracks[i].ar.Count; j++)
                {
                    alName += json.playlist.tracks[i].ar[j].name;
                    if (j != json.playlist.tracks[i].ar.Count - 1)
                    {
                        alName += "/";
                    }
                }
                songArtisits.Add(alName);   //  歌手集合
                songAlbums.Add(json.playlist.tracks[i].al.name);    //  歌曲专辑集合
                songAlbumUrls.Add(json.playlist.tracks[i].al.picUrl);   //  歌曲专辑封面集合
                songTimes.Add(json.playlist.tracks[i].dt);  //  歌曲时长
            }
            for (int i=0 ;i < songsId.Count;i++)
            {
                string s = ((int)songTimes[i] / 1000 / 60).ToString().PadLeft(2, '0') 
                    + ":" + ((int)(((songTimes[i] / 1000 / 60) 
                    - (int)(songTimes[i] / 1000 / 60))*60)).ToString().PadLeft(2, '0');
                MusicInfoModel m = new MusicInfoModel(songNames[i], songArtisits[i], songAlbums[i], s, songsUrl[i], songAlbumUrls[i],1);
                SongsList.Add(m);

            }
        }

        /// <summary>
        /// 初始化歌单列表
        /// </summary>
        private void initList()
        {
            for (int i = 0; i < num; i++)
            {
                string name = songNames[i];
                string artisits = songArtisits[i];
                string album = songAlbums[i];
                string albumUrl = songAlbumUrls[i];
                string time = songTimes[i].ToString();  //  时长

            }
            mListBox.ItemsSource = SongsList;
        }
        private void MListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                int index = mListBox.SelectedIndex;
                string s = ((int)songTimes[index] / 1000 / 60).ToString().PadLeft(2, '0')
                    + ":" + ((int)(((songTimes[index] / 1000 / 60)
                    - (int)(songTimes[index] / 1000 / 60)) * 60)).ToString().PadLeft(2, '0');
                MusicInfoModel m = new MusicInfoModel(songNames[index], songArtisits[index], 
                    songAlbums[index], s, songsUrl[index],songAlbumUrls[index],index);

                Console.WriteLine(m.MusicName);
                Console.WriteLine(m.MusicPath);
                Method(m);
            }
            catch{}
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            all(SongsList);
        }
    }
}
