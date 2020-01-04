using ID3;
using LanguageExt.TypeClasses;
using MyCloudMusic.Models;
using Shell32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
using TestListDemo;

namespace MyCloudMusic.Views
{
    /// <summary>
    /// PageLocalSongs.xaml 的交互逻辑
    /// </summary>
    public delegate void DelSendValue(MusicInfoModel str);
    public partial class PageLocalSongs : Page
    {
        private List<string> listPath = new List<string>();
        private ObservableCollection<MusicInfoModel> mList = new ObservableCollection<MusicInfoModel>();
        private ObservableCollection<MusicInfoModel> list = new ObservableCollection<MusicInfoModel>();
        private string[] path;
        private int num = 0;
        public delegate void SendMessage(string value);
        public SendMessage sendMessage;
        public string url;
        private DelSendValue delMethod;
        public  PageLocalSongs(DelSendValue del)
        {
            this.delMethod = del;
            InitializeComponent();
            this.DataContext = new Music_Num { Num = this.num.ToString() };

        }
        private void initList()
        {
            int flag = 0;
            for (int i = 0; i < path.Length; i++)
            {
                flag = 0;
                TagLib.File t = TagLib.File.Create(path[i]);    //  用taglib获取歌曲标题，歌手，专辑
                string musicName = t.Tag.Title;
                string musicArtists = t.Tag.Artists[0];
                string musicAlbum = t.Tag.Album;

                ShellClass sh = new ShellClass();   //  用ShellClass获取歌曲时常，大小
                Folder dir = sh.NameSpace(System.IO.Path.GetDirectoryName(path[i]));
                FolderItem item = dir.ParseName(System.IO.Path.GetFileName(path[i]));
                string musicDuration = dir.GetDetailsOf(item, 27);
                string musicSize = dir.GetDetailsOf(item, 1);

                MusicInfoModel s = new MusicInfoModel(musicName,musicArtists,
                    musicAlbum,musicDuration,musicSize,path[i]);

                foreach (MusicInfoModel a in mList)
                {
                    if (a.MusicPath == s.MusicPath)
                    {
                        flag = 1;
                    }
                        
                }
                if (flag == 1)
                    continue;
                

                s.musicId = (mList.Count()+1).ToString();
                mList.Add(s);
                list.Add(s);
                num = mList.Count();
                
            }
            this.DataContext = new Music_Num() { Num = this.num.ToString() };
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "mp3文件|*.mp3|wav文件|*.wav|*|*";
            ofd.Title = "请选择音乐文件";
            ofd.Multiselect = true;

            DialogResult dr = ofd.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                //获得选中文件的全路径
                path = ofd.FileNames;
                for (int i = 0; i < path.Length; i++)
                {
                    // 将音乐文件的全路径加载到存储的泛型集合中
                    listPath.Add(path[i]);
                }
                for (int i = 0; i < path.Length; i++)
                {
                    //Console.WriteLine(path[i]);
                }
                initList();

                mListBox.ItemsSource = mList;
            }
        }
        private void Del_Click(object sender, RoutedEventArgs e)
        {
            
            int index = mListBox.SelectedIndex;
            if (index < 0)
                return;
            mList.Clear();
            list.RemoveAt(index);

            foreach (MusicInfoModel a in list)
            {
                a.musicId = (mList.Count() + 1).ToString();
                mList.Add(a);
            }
            num = mList.Count();
            this.DataContext = new Music_Num() { Num = this.num.ToString() };
            search.Focus();
        }
        private void Search_Focus(object sender, RoutedEventArgs e)
        {
            if (search.Text == "搜索本地音乐")
                search.Text = "";
        }
        private void Search_TextChanged(object sender, RoutedEventArgs e)
        {

            if (search.Text == "")
            {
                mList.Clear();
                foreach (MusicInfoModel m in list)
                {
                    m.musicId = (mList.Count() + 1).ToString();
                    mList.Add(m);
                }
                return;
            }
            mList.Clear();
            foreach (MusicInfoModel m in list)
            {
                if (m.MusicName.Contains(search.Text) ||
                    m.MusicArtists.Contains(search.Text) || 
                    m.MusicAlbum.Contains(search.Text))
                {
                    m.musicId = (mList.Count()+1).ToString();
                    mList.Add(m);
                }
            }
        }

        private void MListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            try
            {
                int index = mListBox.SelectedIndex;
                url = mList[index].MusicPath;
                MusicInfoModel musicInfoModel = mList[index];
                this.delMethod(musicInfoModel);
            }
            catch{}
        }
    }
}
