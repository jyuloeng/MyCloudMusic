using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MyCloudMusic.Models;
using MyCloudMusic.Utils;
using Newtonsoft;
using Newtonsoft.Json;

namespace MyCloudMusic
{
    /// <summary>
    /// LoginWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LoginWindow : Window
    {
        private string url;         //  调用api的地址
        private string result;      //  api返回的结果字符串
        private double id;  
        private string nickname = "";    //  获取的用户名
        private string avatarUrl = "";   //  获取的用户头像url(网路图片)

        public LoginWindow()
        {
            InitializeComponent();
        }

        //  点击右上角的x按钮时的事件
        private void closeLoginWindowEvent(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 登陆按钮操作
        /// </summary>
        private void Login(object sender, RoutedEventArgs e)
        {
            //  获取用户手机或邮箱
            string userName = userNameText.Text.Trim();
            //  获取用户密码
            string userPassword = passwordText.Password.Trim();

            //  判空操作
            if (userName.Equals(string.Empty) || userName == "请输入手机号或邮箱")
            {
                TipsText.Text = "请输入手机号或邮箱!";
                return;
            }
            if (userPassword.Equals(string.Empty))
            {
                TipsText.Text = "请输入用户密码!";
                return;
            }

            //  拼接url
            if (LoginUtils.IsUsePhoneLogin(userName))
            {
                url = "http://jungha.top/login/cellphone?phone=" + userName + "&password=" + userPassword;
                GetResult();
            }
            else if (LoginUtils.IsUseEmailLogin(userName))
            {
                url = "http://jungha.top/login?email=" + userName + "&password=" + userPassword;
                GetResult();
            }
            else
            {
                TipsText.Text = "请输入正确的手机号或邮箱!";
                return;
            }

        }

        /// <summary>
        /// 得到json
        /// </summary>
        private void GetResult()
        {
            try
            {
                //  获得返回结果
                result = HttpUtils.GetJsonResult(url);

                //  解析返回的json数据
                JsonLoginObject json =  JsonConvert.DeserializeObject<JsonLoginObject>(result);

                //  设置用户名和用户头像url
                id = json.profile.userId;
                nickname = json.profile.nickname;
                avatarUrl = json.profile.avatarUrl;

                if (json.profile.nickname != null)
                {
                    MainWindow mainWindow = new MainWindow(id, nickname, avatarUrl);
                    mainWindow.Show();
                    this.Close();
                }
            }
            catch
            {
                TipsText.Text = "账号或密码错误!";
            }
        }

        //  输入账号框焦点事件
        private void UserNameText_GotFocus(object sender, RoutedEventArgs e)
        {
            TipsText.Text = "";
            if (userNameText.Text == "请输入手机号或邮箱")
            {
                userNameText.Text = "";
            }
        }

        //  输入密码框焦点事件
        private void PasswordText_GotFocus(object sender, RoutedEventArgs e)
        {
            TipsText.Text = "";
            if (userNameText.Text == "")
            {
                userNameText.Text = "请输入手机号或邮箱";
            }
        }
        /// <summary>
        /// 注册按钮操作
        /// </summary>
        private void Register(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://music.163.com/");
        }

        
    }
}
