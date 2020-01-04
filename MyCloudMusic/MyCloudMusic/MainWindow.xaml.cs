using System;
using System.Collections.Generic;
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
using System.Windows.Forms;
using MyCloudMusic.Views;
using MyCloudMusic.Models;
using System.Data.Linq;

namespace MyCloudMusic
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window    {
        public PageLocalSongs pageLocalSongs = null;
        public PageManageSongs pageManageSongs = null;
        JsonLoginObject user;
        private Boolean isPause = true;
        public string nickname; //  获取的用户名
        public double id;

        public string avatarUrl;

        public MainWindow()
        {
            InitializeComponent();
        }
        public MainWindow(JsonLoginObject user)
        {
            this.nickname = user.profile.nickname;
            this.avatarUrl = user.profile.avatarUrl;
            this.id = user.account.id;
            this.DataContext = new UserModel() { UserName = nickname, AvatarUrl = avatarUrl };
            //Uri uri = new Uri(avatarUrl);
            //BitmapImage bitmap = new BitmapImage(uri);
            //image.ImageSource = bitmap;
            InitializeComponent();
        }
        // 关闭程序
        private void closeWindowEvent(object sender, RoutedEventArgs e)
        {
            CloseWindow closeWindow = new CloseWindow();
            closeWindow.Show();
        }

        private void miniEvent(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        // 播放暂停按钮操作
        private void playSongEvent(object sender, RoutedEventArgs e)
        {
            if (isPause)
            {
                isPause = !isPause;
            }
        }

        // 打开本地音乐页面
        private void Btn_LocalSongs_Click(object sender, RoutedEventArgs e)
        {
            if(pageLocalSongs == null)
            {
                pageLocalSongs = new PageLocalSongs();
            }
            Change_Page.Content = new Frame()
            {
                Content = pageLocalSongs
            };
        }

        // 打开下载管理页面
        private void Btn_ManageSongs_Click(object sender, RoutedEventArgs e)
        {
            if (pageManageSongs == null)
            {
                pageManageSongs = new PageManageSongs();
            }
            Change_Page.Content = new Frame()
            {
                Content = pageManageSongs
            };
        }
    }
}
