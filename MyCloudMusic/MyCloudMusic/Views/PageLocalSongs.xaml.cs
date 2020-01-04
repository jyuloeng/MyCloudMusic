using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyCloudMusic.Views
{
    /// <summary>
    /// PageLocalSongs.xaml 的交互逻辑
    /// </summary>
    public partial class PageLocalSongs : Page
    {
        public PageLocalSongs()
        {
            InitializeComponent();
        }

        private void Add_Music_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"C:\Users\Shinelon\Desktop\musicDemo\music";
            ofd.Filter = "音乐文件 |*.wav | MP3文件 | *.mp3 | 所有文件 | *.*";
            ofd.Title = "请选择音乐文件";
            ofd.Multiselect = true;
            ofd.ShowDialog();
            string[] path = ofd.FileNames;

        }
    }
}
