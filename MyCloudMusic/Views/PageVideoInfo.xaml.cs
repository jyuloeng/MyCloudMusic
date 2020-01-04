using MyCloudMusic.Models;
using MyCloudMusic.Models.JsonMvInfoObject;
using MyCloudMusic.Utils;
using Newtonsoft.Json;
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
using System.Windows.Threading;

namespace MyCloudMusic.Views
{
    /// <summary>
    /// PageVideoInfo.xaml 的交互逻辑
    /// </summary>
    public partial class PageVideoInfo : Page
    {
        private MvInfoModel mvInfo; //  获得mv信息模型
        private string result = "";
        private Uri uri = null;

        private Boolean isPause = true; //  判断是否播放

        private DispatcherTimer dispatcherTimer;    //  滚动进度条的定时器

        public PageVideoInfo(MvInfoModel mvInfo)
        {
            InitializeComponent();
            this.mvInfo = mvInfo;

            initPage();
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = TimeSpan.FromSeconds(0.1);
        }

        //  定时器操作
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            //  将进度条的value值设置为player的当前秒数
            PositionSlider.Value = player.Position.TotalSeconds;
            sliderValueText.Text = ((int)PositionSlider.Value / 60).ToString().PadLeft(2, '0') 
                + ":" + ((int)PositionSlider.Value % 60).ToString().PadLeft(2, '0');

            //  循环播放
            if(player.Position == player.NaturalDuration)
            {
                player.Position = TimeSpan.FromSeconds(0);
                player.Play();
            }
        }

        //  初始化页面
        private void initPage()
        {
            string url = "http://jungha.top/mv/url?id=" + mvInfo.MvId;

            result = HttpUtils.GetJsonResult(url);
            JsonMvUrlInfoObject json = JsonConvert.DeserializeObject<JsonMvUrlInfoObject>(result);

            this.DataContext = mvInfo;

            uri = new Uri(json.data.url);
            player.Source = uri;
            player.Pause();
        }

        //  播放暂停
        private void Btn_PlayVideo_Click(object sender, RoutedEventArgs e)
        {
            if (isPause)
            {
                player.Position = TimeSpan.FromSeconds(PositionSlider.Value);
                PositionSlider.Maximum = player.NaturalDuration.TimeSpan.TotalSeconds;

                totalTimeText.Text = player.NaturalDuration.TimeSpan.Minutes.ToString().PadLeft(2, '0') + 
                    ":" + player.NaturalDuration.TimeSpan.Seconds.ToString().PadLeft(2, '0');
                Image_Btn_PlayVideo.Source = new BitmapImage(
                    new Uri("/MyCloudMusic;component/Images/pause.png", UriKind.Relative));
                player.Play();
                
                dispatcherTimer.Start();
            }
            else
            {
                Image_Btn_PlayVideo.Source = new BitmapImage(
                    new Uri("/MyCloudMusic;component/Images/play.png", UriKind.Relative));
                player.Pause();
                dispatcherTimer.Stop();
            }
            isPause = !isPause;
        }

        //  改变声音
        private void changeVolume(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            player.Volume = VolumeSlider.Value;
        }

        //  改变进度条
        private void changePosition(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            player.Position = TimeSpan.FromSeconds(PositionSlider.Value);
        }
    }
}
