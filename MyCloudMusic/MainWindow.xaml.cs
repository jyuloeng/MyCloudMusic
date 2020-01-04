using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using MyCloudMusic.Views;
using MyCloudMusic.Models;
using System.Threading;
using System.Net;
using System.IO;
using System.Drawing;
using System.Windows.Controls;
using MyCloudMusic.Utils;
using System.Windows.Threading;
using TestListDemo;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace MyCloudMusic
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<SongModel> SongsList 
            = new ObservableCollection<SongModel>();  //  歌单的歌曲集合
        private ObservableCollection<SongModel> list 
            = new ObservableCollection<SongModel>();
        //  初始化的url链接
        private string SongUrl = "http://m7.music.126.net/20191023225730/ff18700bffa" + 
            "8982365a0b119118cb5fb/ymusic/a523/daf6/97d0/fd67e66a17becfca2b1ed353510427dd.mp3";

        private CopyRightWindow copyRightWindow = null;    //  版权提醒

        private int state = 0;  //  判断是什么播放状态（列表=0、随机=1、单曲=2）
        
        private MusicPlayer player; //  封装好的音乐播放类
  
        private DispatcherTimer dispatcherTimer;    //  定时器
        private DispatcherTimer timer;    //  版权信息定时器

        //  四个菜单点击页面
        public static PageLocalSongs pageLocalSongs = null;
        public static PageManageSongs pageManageSongs = null;
        public static PageFindSongs pageFindSongs = null;
        public static PageSongsList pageSongsList = null;

        private string nickname;    //  用户名
        private string avatarUrl;  //  用户头像
        private double id;
        private double loveSongsListId;
        private Boolean isPause = false;
        private static bool ST = false;

        private int Index = 0;

        public MainWindow(){}
        public MainWindow(double id, string nickname, string avatarUrl)
        {
            InitializeComponent();
            this.nickname = nickname;
            this.avatarUrl = avatarUrl;
            this.id = id;
            this.DataContext = new UserModel() { UserName = this.nickname, AvatarUrl = this.avatarUrl };

            initPage();
            initPlayer();
            initSongsList();
        }

        //  进来时直接加载发现音乐界面
        private void initPage()
        {
            if (pageFindSongs == null)
            {
                pageFindSongs = new PageFindSongs(this);
            }
            Change_Page.Content = new Frame()
            {
                Content = pageFindSongs
            };

            Btn_FindSongs.IsChecked = true;
            nickNameTextBox.Text = nickname;
            nickNameTextBox2.Text = nickname;
            Uri uri = new Uri(avatarUrl, UriKind.Absolute);
            AvatorImg1.ImageSource = new BitmapImage(uri);
            AvatorImg2.ImageSource = new BitmapImage(uri);
        }

        //  初始化用户歌单
        private void initSongsList()
        {
            string GET_USER_LIST_URL = "http://jungha.top/user/playlist?uid=";
            GET_USER_LIST_URL += id;
            string result = HttpUtils.GetJsonResult(GET_USER_LIST_URL);
            JsonUserSongsListObject json = JsonConvert.DeserializeObject<JsonUserSongsListObject>(result);

            //  获得用户所有的歌单
            List<PlaylistItem> mlist = json.playlist.ToList<PlaylistItem>();
            loveSongsListId = mlist[0].id;
        }
        
        //  初始化播放器组件
        private void initPlayer()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = TimeSpan.FromSeconds(0.1);

            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = TimeSpan.FromSeconds(1);

            player = MusicPlayer.ResetInstance(SongUrl);
            player = MusicPlayer.GetInstance(SongUrl);

            VolumeSlider.Value = 0.5;
        }

        //  定时器操作
        private void timer_Tick(object sender, EventArgs e)
        {
            if (copyRightWindow != null)
            {
                copyRightWindow.Close();
                timer.Stop();
            }
        }

        //  定时器操作
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (SongUrl != "")
            {
                PositionSlider.Value = player.GetPosition().TotalSeconds;
                SliderValueText.Text = ((int)PositionSlider.Value / 60).ToString().PadLeft(2, '0') + 
                    ":" + ((int)PositionSlider.Value % 60).ToString().PadLeft(2, '0');
            }
        }

        // 关闭程序
        private void closeWindowEvent(object sender, RoutedEventArgs e)
        {
            CloseWindow closeWindow = new CloseWindow(this);
            closeWindow.Show();
        }

        //  最小化程序
        private void miniEvent(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        // 打开本地音乐页面
        private void Btn_LocalSongs_Click(object sender, RoutedEventArgs e)
        {
            if(pageLocalSongs == null)
            {
                pageLocalSongs = new PageLocalSongs(Local_Play);
            }
            Change_Page.Content = new Frame()
            {
                Content = pageLocalSongs
            };
        }

        // 打开发现mv界面
        private void Btn_ManageSongs_Click(object sender, RoutedEventArgs e)
        {
            if (pageManageSongs == null)
            {
                pageManageSongs = new PageManageSongs(this);
            }
            Change_Page.Content = new Frame()
            {
                Content = pageManageSongs
            };
        }
        
        // 打开我喜爱的音乐页面
        private void Btn_SongsList_Click(object sender, RoutedEventArgs e)
        {
            if (pageSongsList == null)
            {
                pageSongsList = new PageSongsList(loveSongsListId,nickname, MyList_Play,All_Play);
            }
            Change_Page.Content = new Frame()
            {
                Content = pageSongsList
            };
        }

        // 打开发现音乐页面
        private void Btn_FindSongs_Click(object sender, RoutedEventArgs e)
        {
            if (pageFindSongs == null)
            {
                pageFindSongs = new PageFindSongs(this);
            }
            Change_Page.Content = new Frame()
            {
                Content = pageFindSongs
            };
        }
        
        // 播放暂停按钮操作
        private void Btn_PlaySongs_Click(object sender, RoutedEventArgs e)
        {
            if (ST == false) return;

            if (!isPause)
            {
                Uri uri = new Uri("Images/Pause.png", UriKind.Relative);
                Image_BtnPlaySongs.Source = new BitmapImage(uri);
                //  播放
                player.Play();

                //  进度条跟着走
                PositionSlider.Maximum = player.GetDuration();
                dispatcherTimer.Start();
            }
            else
            {
                Uri uri = new Uri("Images/play.png", UriKind.Relative);
                Image_BtnPlaySongs.Source = new BitmapImage(uri);
                //  暂停
                player.Pause();
                //  进度条停止
                dispatcherTimer.Stop();
            }
            isPause = !isPause;
        }

        //  改变进度条时
        private void ChangePositon(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (SongUrl != "")
            {
                player.SetPosition(PositionSlider.Value);
                SliderValueText.Text = ((int)PositionSlider.Value / 60).ToString().PadLeft(2, '0') 
                    + ":" + ((int)PositionSlider.Value % 60).ToString().PadLeft(2, '0');
            }

            if (PositionSlider.Value == PositionSlider.Maximum)
            {
                PlayNextSongs();
            }
        }

        //  改变声音时
        private void ChangeVolume(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            player.SetVolume(VolumeSlider.Value);
        }

        public void Local_Play(MusicInfoModel m)
        {
            ST = true;
            isPause = false;
            SongUrl = m.MusicPath;
            Music_Name.Text = m.MusicName;
            Music_Author.Text = m.MusicArtists;

            player = MusicPlayer.ResetInstance(SongUrl);
            player = MusicPlayer.GetInstance(SongUrl);

            Uri uri = new Uri("Images/Pause.png", UriKind.Relative);
            Image_BtnPlaySongs.Source = new BitmapImage(uri);

            isPause = !isPause;

            //  睡一下再放
            Thread.Sleep(1000);
            player.Play();
            int isAdd = 1;

            SongModel s = new SongModel()
            {
                SongName = m.MusicName,
                SongAuthor = m.MusicArtists,
                SongAlbum = m.MusicAlbum,
                SongTime = m.MusicDuration,
                SongPath = m.MusicPath,
                SongAlbumUrls = m.MusicAlbumUrls
            };
            foreach (SongModel a in SongsList)
            {
                if (a.SongPath == s.SongPath)
                    isAdd = 0;

            }
            if (isAdd == 1)
            {
                SongsList.Add(s);
                list.Add(s);
                Index = SongsList.Count() - 1;
            }
            SongList.ItemsSource = SongsList;
            TotalTimeText.Text = m.MusicDuration.Substring(m.MusicDuration.Length-5);
           
            dispatcherTimer.Start();
            PositionSlider.Maximum = player.GetDuration();
        }

        public void MyList_Play(MusicInfoModel m)
        {
            ST = true;
            this.DataContext = new SongModel()
            {
                SongAlbumUrls = m.MusicAlbumUrls,
            };

            if (m.MusicPath == null)
            {
                Music_Name.Text = m.MusicName;
                Music_Author.Text = m.MusicArtists;            
                SliderValueText.Text = "00:00";
                PositionSlider.Value = 0;
                player.SetPosition(PositionSlider.Value);

                Uri uri1 = new Uri("Images/play.png", UriKind.Relative);
                Image_BtnPlaySongs.Source = new BitmapImage(uri1);

                TotalTimeText.Text = "00:00";
                Music_Name.Text = "";
                Music_Author.Text = "";
                SongUrl = "";
                Console.WriteLine("没版权1");
                //  弄弹窗
                copyRightWindow = new CopyRightWindow();
                copyRightWindow.Show();
                timer.Start();

                player = MusicPlayer.ResetInstance(SongUrl);

                return;
            }
            this.DataContext = new SongModel()
            {
                SongAlbumUrls = m.MusicAlbumUrls,
            };

            isPause = false;

            SongUrl = m.MusicPath;
            Music_Name.Text = m.MusicName;
            Music_Author.Text = m.MusicArtists;
           
            player = MusicPlayer.ResetInstance(SongUrl);
            player = MusicPlayer.GetInstance(SongUrl);
            Uri uri = new Uri("Images/Pause.png", UriKind.Relative);
            Image_BtnPlaySongs.Source = new BitmapImage(uri);
            isPause = !isPause;
           
            //  睡一下再放
            Thread.Sleep(1000);
            player.Play();
            int isAdd = 1;
            SongModel s = new SongModel()
            {
                SongName = m.MusicName,
                SongAuthor = m.MusicArtists,
                SongAlbum = m.MusicAlbum,
                SongTime = m.MusicDuration,
                SongPath = m.MusicPath,
                SongAlbumUrls = m.MusicAlbumUrls
            };
            foreach (SongModel a in SongsList)
            {
                if (a.SongPath == s.SongPath)
                    isAdd = 0;
            }
            if (isAdd == 1)
            {
                SongsList.Add(s);
                list.Add(s);
                Index = SongsList.Count() - 1;
            }
            SongList.ItemsSource = SongsList;
           
            TotalTimeText.Text = m.MusicDuration;
            dispatcherTimer.Start();
            PositionSlider.Maximum = player.GetDuration();
        }
        public void Found_Play(SongModel s)
        {
            ST = true;
            this.DataContext = new SongModel()
            {
                SongAlbumUrls = s.SongAlbumUrls,
            };

            if (s.SongPath == null)
            {
                Music_Name.Text = s.SongName;
                Music_Author.Text = s.SongAuthor;
                //  弄弹窗
                Console.WriteLine("没版权");
                copyRightWindow = new CopyRightWindow();
                copyRightWindow.Show();
                timer.Start();

                SliderValueText.Text = "00:00";
                PositionSlider.Value = 0;
                player.SetPosition(PositionSlider.Value);

                Uri uri1 = new Uri("Images/play.png", UriKind.Relative);
                Image_BtnPlaySongs.Source = new BitmapImage(uri1);

                TotalTimeText.Text = "00:00";
                Music_Name.Text = s.SongName;
                Music_Author.Text = s.SongAuthor;
                SongUrl = "";

                player = MusicPlayer.ResetInstance(SongUrl);
                player = MusicPlayer.GetInstance(SongUrl);

                return;
            }
            this.DataContext = new SongModel()
            {
                SongAlbumUrls = s.SongAlbumUrls,
            };

            isPause = false;
            this.DataContext = new SongModel()
            {
                SongAlbumUrls = s.SongAlbumUrls,

            };
            SongUrl = s.SongPath;
            Music_Name.Text = s.SongName;
            Music_Author.Text = s.SongAuthor;
            //Console.WriteLine(SongUrl);
            player = MusicPlayer.ResetInstance(SongUrl);
            player = MusicPlayer.GetInstance(SongUrl);
            Uri uri = new Uri("Images/Pause.png", UriKind.Relative);
            Image_BtnPlaySongs.Source = new BitmapImage(uri);
            isPause = !isPause;
            //Console.WriteLine(m.MusicDuration);
            //  睡一下再放
            Thread.Sleep(1000);
            player.Play();
            int isAdd = 1;
            //SongModel s = new SongModel(m.MusicName, m.MusicArtists, m.MusicAlbum, m.MusicDuration, m.MusicPath, m.MusicAlbumUrls);
            foreach (SongModel a in SongsList)
            {
                if (a.SongPath == s.SongPath)
                    isAdd = 0;

            }
            if (isAdd == 1)
            {
                SongsList.Add(s);
                list.Add(s);
                Index = SongsList.Count() - 1;
            }
            SongList.ItemsSource = SongsList;
            
            dispatcherTimer.Start();
            PositionSlider.Maximum = player.GetDuration();
        }

        //  打开搜索页
        private void Search_Music_Info(object sender, RoutedEventArgs e)
        {
            string value = Search_Text.Text.Trim();
            if (value.Equals("")) return;
            PageFoundSongs page = new PageFoundSongs(value,Found_Play);
            Change_Page.Content = new Frame()
            {
                Content = page
            };
        }

        //  设置弹窗
        private void Btn_Info_Click(object sender, RoutedEventArgs e)
        {
            PopupInfo.IsOpen = true;
        }

        //  退出登陆按钮事件
        private void Btn_Esc_Click(object sender, RoutedEventArgs e)
        {
            pageLocalSongs = null;
            pageManageSongs = null;
            pageFindSongs = null;
            pageSongsList = null;
            player.Pause();
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        private void Btn_Skin_Click(object sender, RoutedEventArgs e)
        {
            PopupSkin.IsOpen = true;
        }

        private void Btn_List_Click(object sender, RoutedEventArgs e)
        {
            PopupList.IsOpen = true;
            
        }

        //  切换播放状态
        private void Btn_Play_State_Click(object sender, RoutedEventArgs e)
        {
            switch (state)
            {
                case 0:
                    Btn_Play_Style_Img.Source = new BitmapImage(new Uri("Images/play_state_1.png", UriKind.Relative));
                    break;
                case 1:
                    Btn_Play_Style_Img.Source = new BitmapImage(new Uri("Images/play_state_2.png", UriKind.Relative));
                    break;
                case 2:
                    Btn_Play_Style_Img.Source = new BitmapImage(new Uri("Images/play_state_0.png", UriKind.Relative));
                    break;
            }
            if (state == 2)state=0;
            else state++;
        }

        private void ChangeSongs(int index)
        {
            if (ST == false) return;
            //player.Pause();
            Uri uri = new Uri("Images/Pause.png", UriKind.Relative);
            Image_BtnPlaySongs.Source = new BitmapImage(uri);
            SongModel s;
            s = SongsList[index];
            string SongAlbumUrls = s.SongAlbumUrls;
            ST = true;

            this.DataContext = new SongModel()
            {
                SongAlbumUrls = SongAlbumUrls,
            };

            isPause = false;
            SongUrl = s.SongPath;
            Music_Name.Text = s.SongName;
            Music_Author.Text = s.SongAuthor;

            player = MusicPlayer.ResetInstance(SongUrl);
            player = MusicPlayer.GetInstance(SongUrl);

            isPause = !isPause;
            player.Play();
            //  睡一下再放
            Thread.Sleep(1000);

            PositionSlider.Maximum = player.GetDuration();

            TotalTimeText.Text = s.SongTime;
            dispatcherTimer.Start();
            SongList.ItemsSource = SongsList;
        }
        //  下一首的事件
        private void BtnNextSongs_Click(object sender, RoutedEventArgs e)
        {
            PlayNextSongs();
        }

        //  播放下一首歌
        private void PlayNextSongs()
        {
            switch (state)
            {
                case 0:
                    if (Index == SongsList.Count - 1)
                        Index = -1;
                    int index = ++Index;
                    ChangeSongs(index);
                    break;
                case 1:
                    ChangeSongs(Index);
                    break;
                case 2:
                    int i;
                    do
                    {
                        i = new Random().Next(0, SongsList.Count - 1);
                    } while (i == Index);
                    ChangeSongs(i);
                    break;
            }
        }

        //  上一首的事件
        private void BtnPrevSongs_Click(object sender, RoutedEventArgs e)
        {
            switch (state)
            {
                case 0:
                    if (Index == 0)
                        Index = SongsList.Count;
                    int index = --Index;
                    ChangeSongs(index);
                    break;
                case 1:
                    ChangeSongs(Index);
                    break;
                case 2:
                    int i;
                    do
                    {
                        i = new Random().Next(0, SongsList.Count - 1);
                    } while (i == Index);
                    ChangeSongs(i);
                    break;
            }
        }

        //  搜索音乐清除
        private void Search_Text_GotFocus(object sender, RoutedEventArgs e)
        {
            
            if (Search_Text.Text == "搜索音乐")
            {
                Search_Text.Text = "";
            }
        }

        //  换炫酷黑
        private void Skin_Black_Click(object sender, MouseButtonEventArgs e)
        {
            Grid_Top.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(34, 34, 37));
            Grid_Bottom.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(34, 34, 37));
            Search_Text.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(22, 22, 24));
            Search_Text.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, 255));
            Search_Border.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(22, 22, 24));
            nickNameTextBox.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, 255));
            YiTiaoShuXian.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, 255));
            Img_Logo.Source = new BitmapImage(new Uri("Images/logo_black.png", UriKind.Relative));
            Uri uri = new Uri("Styles/SkinStyle_Black.xaml", UriKind.Relative);
            System.Windows.Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = uri });
            System.Windows.Application.Current.Resources.MergedDictionaries.RemoveAt(0);
        }

        //  换官方红
        private void Skin_Red_Click(object sender, MouseButtonEventArgs e)
        {
            Grid_Top.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(198, 47, 47));
            Grid_Bottom.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(246, 246, 248));
            Search_Text.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(168, 40, 40));
            Search_Text.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(199, 115, 115));
            Search_Border.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(168, 40, 40));
            nickNameTextBox.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(238, 193, 193));
            YiTiaoShuXian.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(168, 40, 40));
            Img_Logo.Source = new BitmapImage(new Uri("Images/logo_red.png", UriKind.Relative));
            Uri uri = new Uri("Styles/SkinStyle_Red.xaml", UriKind.Relative);
            System.Windows.Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = uri });
            System.Windows.Application.Current.Resources.MergedDictionaries.RemoveAt(0);
        }

        //  换可爱粉
        private void Skin_Pink_Click(object sender, MouseButtonEventArgs e)
        {
            Grid_Top.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(250, 126, 167));
            Grid_Bottom.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(246, 246, 248));
            Search_Text.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(228, 103, 148));
            Search_Text.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, 255));
            Search_Border.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(228, 103, 148));
            nickNameTextBox.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, 255));
            YiTiaoShuXian.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, 255));
            Img_Logo.Source = new BitmapImage(new Uri("Images/logo_pink.png", UriKind.Relative));
            Uri uri = new Uri("Styles/SkinStyle_Pink.xaml", UriKind.Relative);
            System.Windows.Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = uri });
            System.Windows.Application.Current.Resources.MergedDictionaries.RemoveAt(0);
        }

        //  换天际蓝
        private void Skin_Blue_Click(object sender, MouseButtonEventArgs e)
        {
            Grid_Top.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(70, 169, 248));
            Grid_Bottom.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(246, 246, 248));
            Search_Text.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(70, 139, 213));
            Search_Text.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, 255));
            Search_Border.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(70, 139, 213));
            nickNameTextBox.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, 255));
            YiTiaoShuXian.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, 255));
            Img_Logo.Source = new BitmapImage(new Uri("Images/logo_blue.png", UriKind.Relative));
            Uri uri = new Uri("Styles/SkinStyle_Blue.xaml", UriKind.Relative);
            System.Windows.Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = uri });
            System.Windows.Application.Current.Resources.MergedDictionaries.RemoveAt(0);
        }

        //  换清新绿
        private void Skin_Green_Click(object sender, MouseButtonEventArgs e)
        {
            Grid_Top.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(59, 184, 119));
            Grid_Bottom.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(246, 246, 248));
            Search_Text.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(70, 154, 128));
            Search_Text.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, 255));
            Search_Border.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(70, 154, 128));
            nickNameTextBox.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, 255));
            YiTiaoShuXian.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, 255));
            Img_Logo.Source = new BitmapImage(new Uri("Images/logo_green.png", UriKind.Relative));
            Uri uri = new Uri("Styles/SkinStyle_Green.xaml", UriKind.Relative);
            System.Windows.Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = uri });
            System.Windows.Application.Current.Resources.MergedDictionaries.RemoveAt(0);
        }

        //  换土豪金
        private void Skin_Gold_Click(object sender, MouseButtonEventArgs e)
        {
            Grid_Top.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(211, 142, 66));
            Grid_Bottom.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(246, 246, 248));
            Search_Text.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(198, 154, 95));
            Search_Text.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, 255));
            Search_Border.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(198, 154, 95));
            nickNameTextBox.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, 255));
            YiTiaoShuXian.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, 255));
            Img_Logo.Source = new BitmapImage(new Uri("Images/logo_gold.png", UriKind.Relative));
            Uri uri = new Uri("Styles/SkinStyle_Gold.xaml", UriKind.Relative);
            System.Windows.Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = uri });
            System.Windows.Application.Current.Resources.MergedDictionaries.RemoveAt(0);
        }
        
        //  定时
        public static System.Timers.Timer SetTimeout(Action action, double interval)
        {
            var timer = new System.Timers.Timer(interval);
            timer.Elapsed += (sender, e) =>
            {
                timer.Enabled = false;
                action();
            };
            timer.Enabled = true;
            return timer;
        }

        private void SongList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            int index = Index = SongList.SelectedIndex;
            string SongAlbumUrls = SongsList[index].SongAlbumUrls;
            ST = true;
            this.DataContext = new SongModel()
            {
                SongAlbumUrls = SongAlbumUrls,
            };
            isPause = false;
            SongUrl = SongsList[index].SongPath;
            Music_Name.Text = SongsList[index].SongName;
            Music_Author.Text = SongsList[index].SongAuthor;
           
            player = MusicPlayer.ResetInstance(SongUrl);
            player = MusicPlayer.GetInstance(SongUrl);
            Uri uri = new Uri("Images/Pause.png", UriKind.Relative);
            Image_BtnPlaySongs.Source = new BitmapImage(uri);
            isPause = !isPause;
            
            player.Play();
            SetTimeout(() => { PositionSlider.Maximum = player.GetDuration(); }, 1000);
            
            TotalTimeText.Text = SongsList[index].SongTime;
            dispatcherTimer.Start();
        }
        private void Btn_DelSong_Click(object sender, RoutedEventArgs e)
        {

            int index = SongList.SelectedIndex;
            if (SongsList[index].SongPath == SongUrl)
            {
                player.Pause();
                Music_Name.Text = "";
                Music_Author.Text = "";
                this.DataContext = new SongModel()
                {
                    SongAlbumUrls = ""
                };
                Uri uri = new Uri("Images/play.png", UriKind.Relative);
                Image_BtnPlaySongs.Source = new BitmapImage(uri);
                SliderValueText.Text = TotalTimeText.Text = "00:00";
                PositionSlider.Value = 0;
                SongUrl = "";
            }

            if (index < 0)
                return;
            SongsList.Clear();
            list.RemoveAt(index);

            foreach (SongModel a in list)
            {
                a.SongId = (SongsList.Count() + 1).ToString();
                if (a.SongPath == SongUrl)
                    Index = SongsList.Count;
                SongsList.Add(a);
            }

        }

        public void All_Play(ObservableCollection<MusicInfoModel> s)
        {
            foreach (MusicInfoModel m in s)
            {
                int flag = 1;
                foreach (SongModel a in SongsList)
                {
                    if (a.SongPath == m.MusicPath)
                    {
                        flag = 0;
                    }
                }
                if (flag == 1)
                {
                    if (m.MusicPath == null)
                        continue;
                    SongModel song = new SongModel()
                    {
                        SongName = m.MusicName,
                        SongAuthor = m.MusicArtists,
                        SongAlbum = m.MusicAlbum,
                        SongTime = m.MusicDuration,
                        SongPath = m.MusicPath,
                        SongAlbumUrls = m.MusicAlbumUrls
                    };
                    SongsList.Add(song);
                    list.Add(song);
                }

            }

            SongList.ItemsSource = SongsList;
        }
    }
}
