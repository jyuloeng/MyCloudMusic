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
using System.Windows.Shapes;
using System.Windows.Forms;
using System.Drawing;
namespace MyCloudMusic
{
    /// <summary>
    /// CloseWindow.xaml 的交互逻辑
    /// </summary>
    public partial class CloseWindow : Window
    {
        private Window window;
        private NotifyIcon icon = null;

        public CloseWindow(Window window)
        {
            InitializeComponent();
            this.window = window;
        }

        private void closeWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
        //  确认按钮操作
        private void Btn_CloseAllWindow_Click(object sender, RoutedEventArgs e)
        {
            if (BtnCloseAll.IsChecked == true)
            {
                this.Close();
                //  关闭主界面
                this.window.Close();
            }else if(BtnMiniWindowToCrtl.IsChecked == true)
            {
                this.Close();
                this.window.Visibility = Visibility.Hidden;
                icon = new NotifyIcon();
                icon.Visible = true;
                icon.Icon = System.Drawing.Icon.
                    ExtractAssociatedIcon(System.Windows.Forms.Application.ExecutablePath);
                icon.Text = "网易云音乐";
                icon.BalloonTipText = "网易云音乐后台运行中";
                icon.ShowBalloonTip(5);
                //  双击图标
                icon.MouseDoubleClick += OnMouseDoubleClickHandler;
            }
        }

        //  双击最小化托盘操作
        private void OnMouseDoubleClickHandler(object sender, EventArgs e)
        {
            icon.Visible = false;
            this.window.Show();
        }
    }
}
