﻿using System;
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

        private NotifyIcon icon = null;

        public CloseWindow()
        {
            InitializeComponent();
        }

        private void closeWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void closeAllWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
            System.Windows.Application.Current.MainWindow.Close();
        }

        private void miniWindowToCrtl(object sender, RoutedEventArgs e)
        {
            this.Close();
            System.Windows.Application.Current.MainWindow.Visibility = Visibility.Hidden;
            icon = new NotifyIcon();
            icon.Visible = true;
            icon.Icon = System.Drawing.Icon.ExtractAssociatedIcon(System.Windows.Forms.Application.ExecutablePath);
            icon.Text = "网易云音乐";
            icon.BalloonTipText = "网易云音乐";
        }
    }
}
