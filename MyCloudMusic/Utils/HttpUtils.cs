using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyCloudMusic.Utils
{
    public class HttpUtils
    {
        public static string GetJsonResult(string url)
        {
            Console.WriteLine(url);
            string result = "";

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

            return result;
        }
    }
}
