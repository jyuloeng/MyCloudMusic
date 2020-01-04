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
using MyCloudMusic.ViewModel;

namespace MyCloudMusic.Views
{
    /// <summary>
    /// PageManageSongs.xaml 的交互逻辑
    /// </summary>
    public partial class PageManageSongs : Page
    {
        public List<string> listPath = new List<string>();

        public PageManageSongs()
        {
            InitializeComponent();
            this.DataContext = new SongViewModel();
        }

        public void initList()
        {
            for (int i = 0; i < 10; i++)
            {
                //listBook.Add(new Book(0,123456, "testBook"+i, "Math", "qiaobus", "shanghai", "just a book", "none"));
                listView.Items.Add(new SongModel("0", "123456", "testBook" + i, 22, 22, "shanghai"));

            }

        }
          private void Btn_OpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "mp3文件|*.mp3|wav文件|*.wav";
            ofd.Title = "请选择音乐文件";
            ofd.Multiselect = true;

            DialogResult dr = ofd.ShowDialog();
            if(dr == DialogResult.OK)
            {

            }

        }
    }
}
