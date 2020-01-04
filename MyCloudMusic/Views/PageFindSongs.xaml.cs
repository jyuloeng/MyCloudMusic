using MyCloudMusic.Models;
using MyCloudMusic.Models.JsonRecommendMVObject;
using MyCloudMusic.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
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
    /// PageFindSongs.xaml 的交互逻辑
    /// </summary>
    /// 
    public partial class PageFindSongs : Page
    {
       private MainWindow mainWindow;

        private int index = 0;  //  获得当前页
        private string result = "";

        private string GET_MV_URL = "http://jungha.top/personalized/mv";    //  推荐mv
        private string getMvResult = "";

        private List<StackPanel> stackPanels = new List<StackPanel>();  //  初始化所有的歌单的框
        private List<StackPanel> mvStackPanels = new List<StackPanel>();//  初始化所有的MV的框

        private List<Models.ResultItem> songs; //  推荐歌单返回的列表
        private List<MyCloudMusic.Models.JsonRecommendMVObject.ResultItem> mvs;   //  推荐mv返回的列表

        private List<double> mvIDs = new List<double>();    //  mv的id集合

        public string songsListNickName;
        public PageFindSongs(MainWindow mainWindow )
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            initPage();
        }

        //  初始化页面
        private void initPage()
        {
            result = HttpUtils.GetJsonResult(getUrl(index));

            JsonRecommendListObject json = JsonConvert.DeserializeObject<JsonRecommendListObject>(result);
            songs = json.result.ToList<Models.ResultItem>();

            getMvResult = HttpUtils.GetJsonResult(GET_MV_URL);

            JsonRecommendMVObject mvJson = JsonConvert.DeserializeObject<JsonRecommendMVObject>(getMvResult);
            mvs = mvJson.result.ToList<MyCloudMusic.Models.JsonRecommendMVObject.ResultItem>();

            initStackPanels();
        }

        //  为相关操作框绑定上下文数据
        private void initStackPanels()
        {
            stackPanels.Add(StackPanel1);
            stackPanels.Add(StackPanel2);
            stackPanels.Add(StackPanel3);
            stackPanels.Add(StackPanel4);
            stackPanels.Add(StackPanel5);
            stackPanels.Add(StackPanel6);
            stackPanels.Add(StackPanel7);
            stackPanels.Add(StackPanel8);
            stackPanels.Add(StackPanel9);
            stackPanels.Add(StackPanel10);

            for(int i = 0; i < stackPanels.Count; i++)
            {
                stackPanels[i].DataContext = new SongsListModel() { SongsListId = songs[i].id,
                    SongsListName = songs[i].name, SongsListUrl = songs[i].picUrl };
            }

            mvStackPanels.Add(mvStackPanel1);
            mvStackPanels.Add(mvStackPanel2);
            mvStackPanels.Add(mvStackPanel3);
            mvStackPanels.Add(mvStackPanel4);

            for (int i = 0; i < mvStackPanels.Count; i++)
            {
                mvStackPanels[i].DataContext = new MvInfoModel() { MvId = mvs[i].id,
                    MvName = mvs[i].name, MvArtist = mvs[i].artistName,
                    MvPlayCount = mvs[i].playCount,
                    MvImgUrl = mvs[i].picUrl, MvUrl = mvs[i].picUrl };
            }
        }

        //  根据页数来获得需要的推荐歌单数
        private string getUrl(int index)
        {
            string url = "http://jungha.top/personalized?limit=";
            url += ((index + 1) * 10);
            return url;
        }

        //  换一批推荐歌单
        private void Btn_ChangeSongsList_Click(object sender, RoutedEventArgs e)
        {
            index++;

            result = HttpUtils.GetJsonResult(getUrl(index));
            if (index == 12) index = 0; //  限制最大推荐的歌单数
            JsonRecommendListObject json = JsonConvert.DeserializeObject<JsonRecommendListObject>(result);
            songs = json.result.ToList<Models.ResultItem>();

            for (int i = 0; i < stackPanels.Count; i++)
            {
                stackPanels[i].DataContext = new SongsListModel() {
                    SongsListId = songs[i + index * 10].id,
                    SongsListName = songs[i + index * 10].name,
                    SongsListUrl = songs[i + index * 10].picUrl };
            }
        }

        //  根据歌单id获得歌单详情
        private void Get_List_Id(double listId)
        {
            string GET_LIST_URL = "http://jungha.top/playlist/detail?id=";
            string url= GET_LIST_URL + listId; //  拼接获取歌单详情的url`
            result = HttpUtils.GetJsonResult(url);
           
            JsonSongsListObject json = JsonConvert.DeserializeObject<JsonSongsListObject>(result);
            songsListNickName = json.playlist.creator.nickname;
        }

        private void ToSelectSongsList0(object sender, MouseButtonEventArgs e)
        {
            SongsListModel songs = (SongsListModel)stackPanels[0].DataContext;
            double songsListId = songs.SongsListId;

            Get_List_Id(songsListId);

            PageSongsList page = new PageSongsList(
                songsListId , 
                songsListNickName, 
                mainWindow.MyList_Play,
                mainWindow.All_Play);
            mainWindow.Change_Page.Content = new Frame()
            {
                Content = page
            };
        }

        private void ToSelectSongsList1(object sender, MouseButtonEventArgs e)
        {
            SongsListModel songs = (SongsListModel)stackPanels[1].DataContext;
            double songsListId = songs.SongsListId;
            Get_List_Id(songsListId);
            PageSongsList page = new PageSongsList(songsListId, songsListNickName, mainWindow.MyList_Play, mainWindow.All_Play);
            mainWindow.Change_Page.Content = new Frame()
            {
                Content = page
            };
        }

        private void ToSelectSongsList2(object sender, MouseButtonEventArgs e)
        {
            SongsListModel songs = (SongsListModel)stackPanels[2].DataContext;
            double songsListId = songs.SongsListId;
            Get_List_Id(songsListId);
            PageSongsList page = new PageSongsList(songsListId, songsListNickName, mainWindow.MyList_Play, mainWindow.All_Play);
            mainWindow.Change_Page.Content = new Frame()
            {
                Content = page
            };
        }

        private void ToSelectSongsList3(object sender, MouseButtonEventArgs e)
        {
            SongsListModel songs = (SongsListModel)stackPanels[3].DataContext;
            double songsListId = songs.SongsListId;
            Get_List_Id(songsListId);
            PageSongsList page = new PageSongsList(songsListId, songsListNickName, mainWindow.MyList_Play, mainWindow.All_Play);
            mainWindow.Change_Page.Content = new Frame()
            {
                Content = page
            };
        }

        private void ToSelectSongsList4(object sender, MouseButtonEventArgs e)
        {
            SongsListModel songs = (SongsListModel)stackPanels[4].DataContext;
            double songsListId = songs.SongsListId;
            Get_List_Id(songsListId);
            PageSongsList page = new PageSongsList(songsListId, songsListNickName, mainWindow.MyList_Play, mainWindow.All_Play);
            mainWindow.Change_Page.Content = new Frame()
            {
                Content = page
            };
        }

        private void ToSelectSongsList5(object sender, MouseButtonEventArgs e)
        {
            SongsListModel songs = (SongsListModel)stackPanels[5].DataContext;
            double songsListId = songs.SongsListId;
            Get_List_Id(songsListId);
            PageSongsList page = new PageSongsList(songsListId, songsListNickName, mainWindow.MyList_Play, mainWindow.All_Play);
            mainWindow.Change_Page.Content = new Frame()
            {
                Content = page
            };
        }

        private void ToSelectSongsList6(object sender, MouseButtonEventArgs e)
        {
            SongsListModel songs = (SongsListModel)stackPanels[6].DataContext;
            double songsListId = songs.SongsListId;
            Get_List_Id(songsListId);
            PageSongsList page = new PageSongsList(songsListId, songsListNickName, mainWindow.MyList_Play, mainWindow.All_Play);
            mainWindow.Change_Page.Content = new Frame()
            {
                Content = page
            };
        }

        private void ToSelectSongsList7(object sender, MouseButtonEventArgs e)
        {
            SongsListModel songs = (SongsListModel)stackPanels[7].DataContext;
            double songsListId = songs.SongsListId;
            Get_List_Id(songsListId);
            PageSongsList page = new PageSongsList(songsListId, songsListNickName, mainWindow.MyList_Play, mainWindow.All_Play);
            mainWindow.Change_Page.Content = new Frame()
            {
                Content = page
            };
        }

        private void ToSelectSongsList8(object sender, MouseButtonEventArgs e)
        {
            SongsListModel songs = (SongsListModel)stackPanels[8].DataContext;
            double songsListId = songs.SongsListId;
            Get_List_Id(songsListId);
            PageSongsList page = new PageSongsList(songsListId, songsListNickName, mainWindow.MyList_Play, mainWindow.All_Play);
            mainWindow.Change_Page.Content = new Frame()
            {
                Content = page
            };
        }

        private void ToSelectSongsList9(object sender, MouseButtonEventArgs e)
        {
            SongsListModel songs = (SongsListModel)stackPanels[9].DataContext;
            double songsListId = songs.SongsListId;
            Get_List_Id(songsListId);
            PageSongsList page = new PageSongsList(songsListId, songsListNickName, mainWindow.MyList_Play, mainWindow.All_Play);
            mainWindow.Change_Page.Content = new Frame()
            {
                Content = page
            };
        }

        private void ToSelectMV1(object sender, MouseButtonEventArgs e)
        {
            MvInfoModel mv = (MvInfoModel)mvStackPanel1.DataContext;
            PageVideoInfo page = new PageVideoInfo(mv);
            mainWindow.Change_Page.Content = new Frame()
            {
                Content = page
            };
        }

        private void ToSelectMV2(object sender, MouseButtonEventArgs e)
        {
            MvInfoModel mv = (MvInfoModel)mvStackPanel2.DataContext;
            PageVideoInfo page = new PageVideoInfo(mv);
            mainWindow.Change_Page.Content = new Frame()
            {
                Content = page
            };
        }

        private void ToSelectMV3(object sender, MouseButtonEventArgs e)
        {
            MvInfoModel mv = (MvInfoModel)mvStackPanel3.DataContext;
            PageVideoInfo page = new PageVideoInfo(mv);
            mainWindow.Change_Page.Content = new Frame()
            {
                Content = page
            };
        }

        private void ToSelectMV4(object sender, MouseButtonEventArgs e)
        {
            MvInfoModel mv = (MvInfoModel)mvStackPanel4.DataContext;
            PageVideoInfo page = new PageVideoInfo(mv);
            mainWindow.Change_Page.Content = new Frame()
            {
                Content = page
            };
        }       
    }
}
