using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyCloudMusic.Utils
{
    public class LoginUtils
    {
        /// <summary>
        /// 判断用户是否使用邮箱登陆
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static bool IsUseEmailLogin(string inputData)
        {
            Regex RegEmail = new Regex("^[\\w-]+@[\\w-]+\\.(com|net|org|edu|mil|tv|biz|info)$");//w 英文字母或数字的字符串，和 [a-zA-Z0-9] 语法一样 
            Match m = RegEmail.Match(inputData);
            return m.Success;
        }

        /// <summary>
        /// 判断用户是否使用手机登陆
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static bool IsUsePhoneLogin(string inputData)
        {
            Regex reg = new Regex(@"^(13[0-9]|14[5|7]|15[0|1|2|3|5|6|7|8|9]|18[0|1|2|3|5|6|7|8|9])\d{8}$");
            Match m = reg.Match(inputData);
            return m.Success;
        }
    }
}
