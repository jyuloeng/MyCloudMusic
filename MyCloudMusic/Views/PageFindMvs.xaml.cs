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
using System.IO;
using System.Windows.Forms;
using MyCloudMusic.Models;
using MyCloudMusic.Utils;
using Newtonsoft.Json;
using MyCloudMusic.Models.JsonFoundMvObject;

namespace MyCloudMusic.Views
{
    /// <summary>
    /// PageManageSongs.xaml 的交互逻辑
    /// </summary>
    public partial class PageManageSongs : Page
    {
        private MainWindow mainWindow;
        private string area = "";   //  获得选中地区
        private string type = "";   //  获得选中类型
        private string order = "";  //  获得选中排序
        private int index = 0;  //  获得当前页

        private List<MvInfoModel> mvInfos = new List<MvInfoModel>();    //  mv详情的集合
        private List<StackPanel> stackPanels = new List<StackPanel>();  //  操作框集合

        public PageManageSongs(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            initRadioBtn();

            initPage();

            ChangeMv();
        }

        //  初始化页面
        private void initPage()
        {
            stackPanels.Add(mvStackPanel1);
            stackPanels.Add(mvStackPanel2);
            stackPanels.Add(mvStackPanel3);
            stackPanels.Add(mvStackPanel4);
            stackPanels.Add(mvStackPanel5);
            stackPanels.Add(mvStackPanel6);

        }

        //  根据页数获得url
        private string getUrl(string url,int index)
        {
            return url += ((index + 1) * 6); 
        }

        //  初始化多选按钮
        private void initRadioBtn()
        {
            RBtn_QuanBuDiQu.IsChecked = true;
            RBtn_QuanBuNeiXing.IsChecked = true;
            RBtn_ShangSheng.IsChecked = true;

            RBtn_QuanBuDiQu.Checked += new RoutedEventHandler(group1_radio_Checked);
            RBtn_NeiDi.Checked += new RoutedEventHandler(group1_radio_Checked);
            RBtn_GangTai.Checked += new RoutedEventHandler(group1_radio_Checked);
            RBtn_OuMei.Checked += new RoutedEventHandler(group1_radio_Checked);
            RBtn_HanGuo.Checked += new RoutedEventHandler(group1_radio_Checked);
            RBtn_RiBen.Checked += new RoutedEventHandler(group1_radio_Checked);

            RBtn_QuanBuNeiXing.Checked += new RoutedEventHandler(group2_radio_Checked);
            RBtn_GuanFang.Checked += new RoutedEventHandler(group2_radio_Checked);
            RBtn_YuanSheng.Checked += new RoutedEventHandler(group2_radio_Checked);
            RBtn_Live.Checked += new RoutedEventHandler(group2_radio_Checked);
            RBtn_WangYi.Checked += new RoutedEventHandler(group2_radio_Checked);

            RBtn_ShangSheng.Checked += new RoutedEventHandler(group3_radio_Checked);
            RBtn_ZuiRe.Checked += new RoutedEventHandler(group3_radio_Checked);
            RBtn_ZuiXing.Checked += new RoutedEventHandler(group3_radio_Checked);
        }

        private void group1_radio_Checked(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.RadioButton btn = sender as System.Windows.Controls.RadioButton;
            switch (btn.Name)
            {
                case "RBtn_QuanBuDiQu":
                    area = "全部";
                    ChangeMv();
                    break;
                case "RBtn_NeiDi":
                    area = "内地";
                    ChangeMv();
                    break;
                case "RBtn_GangTai":
                    area = "港台";
                    ChangeMv();
                    break;
                case "RBtn_OuMei":
                    area = "欧美";
                    ChangeMv();
                    break;
                case "RBtn_HanGuo":
                    area = "韩国";
                    ChangeMv();
                    break;
                case "RBtn_RiBen":
                    area = "日本";
                    ChangeMv();
                    break;
            }
        }

        private void group2_radio_Checked(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.RadioButton btn = sender as System.Windows.Controls.RadioButton;
            switch (btn.Name)
            {
                case "RBtn_QuanBuNeiXing":
                    type = "全部";
                    ChangeMv();
                    break;
                case "RBtn_GuanFang":
                    type = "官方版";
                    ChangeMv();
                    break;
                case "RBtn_YuanSheng":
                    type = "原声";
                    ChangeMv();
                    break;
                case "RBtn_Live":
                    type = "现场版";
                    ChangeMv();
                    break;
                case "RBtn_WangYi":
                    type = "网易出品";
                    ChangeMv();
                    break;
            }
        }

        private void group3_radio_Checked(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.RadioButton btn = sender as System.Windows.Controls.RadioButton;
            switch (btn.Name)
            {
                case "RBtn_ShangSheng":
                    order = "上升最快";
                    ChangeMv();
                    break;
                case "RBtn_GuanFang":
                    order = "最热";
                    ChangeMv();
                    break;
                case "RBtn_YuanSheng":
                    order = "最新";
                    ChangeMv();
                    break;
            }
        }

        //  换一批MV
        private void Btn_ChangeMv_Click(object sender, RoutedEventArgs e)
        {
            index++;
            if (index == 6) index = 0; //  限制最大推荐的歌单数
            ChangeMv();
        }

        //  更换Mv
        private void ChangeMv()
        {
            string baseUrl = "http://jungha.top/mv/all?area=" + area + "&type=" + type + "&order=" + order + "&limit=";
            string mvUrl = getUrl(baseUrl, index);

            string result = HttpUtils.GetJsonResult(mvUrl);
            JsonFoundMvObject json = JsonConvert.DeserializeObject<JsonFoundMvObject>(result);

            for (int i = 0; i < stackPanels.Count; i++)
            {
                stackPanels[i].DataContext = new MvInfoModel()
                {
                    MvId = json.data[i + index * 6].id,
                    MvName = json.data[i + index * 6].name,
                    MvArtist = json.data[i + index * 6].artistName,
                    MvImgUrl = json.data[i + index * 6].cover,
                    MvPlayCount = json.data[i + index * 6].playCount,
                };
            }
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

        private void ToSelectMV5(object sender, MouseButtonEventArgs e)
        {
            MvInfoModel mv = (MvInfoModel)mvStackPanel5.DataContext;
            PageVideoInfo page = new PageVideoInfo(mv);
            mainWindow.Change_Page.Content = new Frame()
            {
                Content = page
            };
        }

        private void ToSelectMV6(object sender, MouseButtonEventArgs e)
        {
            MvInfoModel mv = (MvInfoModel)mvStackPanel6.DataContext;
            PageVideoInfo page = new PageVideoInfo(mv);
            mainWindow.Change_Page.Content = new Frame()
            {
                Content = page
            };
        }
    }
}
