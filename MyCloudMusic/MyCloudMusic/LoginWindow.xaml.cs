using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
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
using Newtonsoft;
using Newtonsoft.Json;

namespace MyCloudMusic
{
    /// <summary>
    /// LoginWindow.xaml 的交互逻辑
    /// </summary>
    /// 

    public partial class LoginWindow : Window
    {
        private string url;         //  调用api的地址
        private string result;      //  api返回的结果字符串

        private string nickname;    //  获取的用户名
        private string avatarUrl;   //  获取的用户头像url(网路图片)
        private double id;
        public JsonLoginObject json;
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void closeLoginWindowEvent(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 登陆按钮操作
        /// </summary>
        /// 
        public static bool IsEmail(string inputData)
        {
            Regex RegEmail = new Regex("^[\\w-]+@[\\w-]+\\.(com|net|org|edu|mil|tv|biz|info)$");//w 英文字母或数字的字符串，和 [a-zA-Z0-9] 语法一样 
            Match m = RegEmail.Match(inputData);
            return m.Success;
        }
        public static bool IsPhone(string inputData)
        {
            Regex reg = new Regex(@"^(13[0-9]|14[5|7]|15[0|1|2|3|5|6|7|8|9]|18[0|1|2|3|5|6|7|8|9])\d{8}$");
            Match m = reg.Match(inputData);
            return m.Success;
        }
        private void User(object sender, RoutedEventArgs e)
        {
            if (phoneText.Text == "请输入手机号或邮箱")
                phoneText.Text = "";
            if (passwordText.Text == "")
            {
                passwordText.Text = "请输入密码";
            }

        }
        private void Userpassword(object sender, RoutedEventArgs e)
        {
            if (passwordText.Text == "请输入密码")
                passwordText.Text = "";
            if (phoneText.Text == "")
            {
                phoneText.Text = "请输入手机号或邮箱";
            }
        }
        private void Login(object sender, RoutedEventArgs e)
        {
            //  获取用户手机号
            string user = phoneText.Text.Trim();
            //  获取用户密码
            string userPassword = passwordText.Text.Trim();

            //  判空操作
            if (user.Equals(string.Empty) || user == "请输入手机号或邮箱")
            {
                MessageBox.Show("请输入手机号或邮箱！");
                return;
            }
            if (userPassword.Equals(string.Empty) || userPassword == "请输入密码")
            {
                MessageBox.Show("请输入用户密码！");
                return;
            }

            //  拼接url
            if (IsPhone(user))
            {
                //url = "http://jungha.top/login/cellphone?phone=" + user + "&password=" + userPassword;
                url = "http://jungha.top/login/cellphone?phone=13544269603&password=zqa8525jd";
                //  开启线程异步加载
                //Thread t = new Thread(new ThreadStart(this.getResult));
                //t.Start();
                getResult();
            }
            else
            if (IsEmail(user))
            {
                url = "http://jungha.top/login?email=" + user + "&password=" + userPassword;
                //Thread t = new Thread(new ThreadStart(this.getResult));
                //t.Start();
                getResult();
            }
            else
            {
                MessageBox.Show("请输入正确的手机号或邮箱!");
            }
        }
        public static string ReplaceString(string JsonString)
        {
            if (JsonString == null) { return JsonString; }
            if (JsonString.Contains("\\"))
            {
                JsonString = JsonString.Replace("\\", "\\\\");
            }
            if (JsonString.Contains("\'"))
            {
                JsonString = JsonString.Replace("\'", "\\\'");
            }
            if (JsonString.Contains("\""))
            {
                JsonString = JsonString.Replace("\"", "\\\"");
            }
            //去掉字符串的回车换行符
            JsonString = Regex.Replace(JsonString, @"[\n\r]", "");
            JsonString = JsonString.Trim();
            return JsonString;
        }

        /// <summary>
        /// 网络操作
        /// </summary>
         public static object JsonToObject(string jsonString, object obj)
         {
                return JsonConvert.DeserializeObject(jsonString, obj.GetType());
            }
        public void getResult()
        {
            //try
            //{
                //  获得返回结果
                //  用这个如果返回400就会抛异常(用户名或密码输错就会返回400)，我今晚才看看  但这个我昨晚成功看到了返回的结果
                //  这个用的是我封装好的HttpRequestHelper里的方法，在Utils包，原理和下面那个差不多
                //  result = HttpRequestHelper.GetResponseString(HttpRequstHelper.CreateGetHttpResponse(url));
                 Console.WriteLine(url);
            //  创建Http请求
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            //  设置请求方法
            httpWebRequest.Method = "GET";
            //  请求超时时间
            httpWebRequest.Timeout = 20000;
            //  发送请求
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            //  利用Stream流读取返回数据
            StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.UTF8);
            //  获得返回结果
            result = streamReader.ReadToEnd();
            //  关闭网络
            streamReader.Close();
            httpWebResponse.Close();

            //  解析返回的json数据
            JsonLoginObject json = JsonConvert.DeserializeObject<JsonLoginObject>(result);

            if (json.profile.nickname == null)
                    Console.WriteLine(result);
                //  设置用户名和用户头像url
                Console.WriteLine("b");
                MainWindow mainWindow = new MainWindow(json);
                mainWindow.Show();
                this.Close();
                Console.WriteLine("a");

                //Console.WriteLine(this.nickname);
            //    // Console.WriteLine(avatarUrl);
            //}
            //catch 
            //{
            //    MessageBox.Show("账号或密码错误");
            //}



            //  解析返回的json数据

            

        }
    }
}
